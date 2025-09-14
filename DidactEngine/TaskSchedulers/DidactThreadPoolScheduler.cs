using System.Collections.Concurrent;

namespace DidactEngine.TaskSchedulers
{
    public class DidactThreadPoolScheduler : TaskScheduler
    {
        private readonly ILogger<DidactThreadPoolScheduler> _logger;

        private readonly ThreadLocal<bool> _currentThreadIsExecuting = new(false);        private readonly ThreadLocal<string> _currentThreadName = new();

        private readonly Thread[] _threads;

        private readonly ConcurrentQueue<Task> _tasks;

        private readonly AutoResetEvent _workAvailable = new(false);

        private volatile bool _shutdown = false;        public DidactThreadPoolScheduler(ILogger<DidactThreadPoolScheduler> logger, int maxDegreeOfParallelism)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (maxDegreeOfParallelism <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxDegreeOfParallelism));

            _tasks = new ConcurrentQueue<Task>();
            _threads = new Thread[maxDegreeOfParallelism];

            // Configure each thread
            for (int i = 0; i < maxDegreeOfParallelism; i++)
            {
                _threads[i] = new Thread(() => ThreadExecutionLoop())
                {
                    IsBackground = true,
                    // Might need to modify this later to include MachineName and/or ProcessId for distributed environments.
                    // That should only matter if saving logs in persistent storage. Otherwise, we won't worry about it for now.
                    Name = $"{nameof(DidactThreadPoolScheduler)} Thread {i}"
                };
            }

            // Start each thread
            _threads.ToList().ForEach(t => t.Start());
        }        private void ThreadExecutionLoop()
        {
            _currentThreadIsExecuting.Value = true;
            _currentThreadName.Value = Thread.CurrentThread.Name!;

            while (!_shutdown)
            {
                try
                {
                    var taskDequeued = _tasks.TryDequeue(out var task);
                    if (taskDequeued)
                    {
                        TryExecuteTask(task!);
                    }
                    else
                    {
                        // No tasks available - wait for signal that work is available
                        // This blocks the thread instead of busy-waiting, dramatically reducing CPU usage
                        _workAvailable.WaitOne(1000); // Wait up to 1 second for work
                    }
                }                catch (ThreadInterruptedException ex)
                {
                    _logger.LogCritical(ex, "A {ExceptionName} occurred on thread {ThreadName}", nameof(ThreadInterruptedException), _currentThreadName.Value);
                    break; // Exit loop on thread interruption
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex, "An unhandled exception occurred on thread {ThreadName}", _currentThreadName.Value);
                    // Continue execution for other exceptions
                }
            }
        }        protected sealed override void QueueTask(Task task)
        {
            _tasks.Enqueue(task);
            // Signal that work is available to wake up waiting threads
            _workAvailable.Set();
        }

        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // IMPORTANT: This was a difficult requirement that was not intuitive to me.
            // We have to PREVENT .NET ThreadPool threads from executing inline Tasks, so check if the CurrentThread is a Didact thread.
            // If it is not, stop it from executing by returning false.
            if (_threads.SingleOrDefault(t => t == Thread.CurrentThread) is null) return false;

            // If the task was previously enqueued, we can't arbitrarily remove it from the FIFO queue.
            // So we just have to wait for it to be executed.
            if (taskWasPreviouslyQueued)
            {
                return false;
            }
            // If the task was not previously enqueued, go ahead and inline execute it and skip the FIFO queue.
            else
            {
                return TryExecuteTask(task);
            }
        }

        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks.ToArray();
        }

        // Add proper disposal to shutdown threads gracefully
        public void Shutdown()
        {
            _shutdown = true;
            _workAvailable.Set(); // Wake up all waiting threads so they can exit

            // Wait for all threads to complete
            foreach (var thread in _threads)
            {
                if (thread.IsAlive)
                {
                    thread.Join(5000); // Wait up to 5 seconds for each thread
                }
            }

            _workAvailable.Dispose();
        }        ~DidactThreadPoolScheduler()
        {
            Shutdown();
        }
    }
}
