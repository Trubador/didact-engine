using DidactCore.Entities;
using DidactCore.Exceptions;
using DidactCore.Flows;
using DidactEngine.Services.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DidactEngine.Services
{
    public class FlowRunRepository: IFlowRunRepository
    {
        private readonly DidactDbContext _context;

        public FlowRunRepository(DidactDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<FlowRun> GetFlowRunAsync(long flowRunId)
        {
            var flowRun = await _context.FlowRuns.Where(f => f.FlowRunId == flowRunId).FirstOrDefaultAsync();
            return flowRun;

        }

        public async Task<FlowRun> GetFlowRunByNameAsync(string name)
        {
            var flowRun = await _context.FlowRuns.Where(f => f.Name == name).FirstOrDefaultAsync();
            return flowRun;
        }

        public async Task<FlowRun> GetFlowRunByDescriptionAsync(string description)
        {
            var flowRun = await _context.FlowRuns.Where(f => f.Description == description).FirstOrDefaultAsync();
            return flowRun;
        }

        public async Task<FlowRun> CreateAndEnqueueFlowRunAsync(FlowRun flowRun)
        {
            await _context.FlowRuns.AddAsync(flowRun);
            await _context.SaveChangesAsync();
            return flowRun;
        }

        public async Task<FlowRun> CreateAndExecuteFlowRunAsync(FlowRun flowRun)
        {
            await _context.FlowRuns.AddAsync(flowRun);
            await _context.SaveChangesAsync();
            return flowRun;
        }

        public async Task<FlowRun> UpdateFlowRunAsync(long flowRunId, FlowRun flowRun)
        {
            var existingFlowRun = await _context.FlowRuns.FindAsync(flowRunId);
            if (existingFlowRun != null)
            {
                _context.Entry(existingFlowRun).CurrentValues.SetValues(flowRun);
                await _context.SaveChangesAsync();
            }
            return flowRun;
        }

        public async Task DeleteFlowRunAsync(long flowRunId)
        {
            await _context.FlowRuns.Where(f => f.FlowRunId== flowRunId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return;
        }
    }

    
}
