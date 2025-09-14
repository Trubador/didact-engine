using DidactCore.Entities;
using DidactCore.Exceptions;
using DidactEngine.Services.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DidactCore.Flows
{
    public class FlowRepository : IFlowRepository
    {
        private readonly DidactDbContext _context;

        public FlowRepository(DidactDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task ActivateFlowByIdAsync(long flowId)
        {
            var flow = await _context.Flows.Where(f => f.FlowId == flowId).FirstOrDefaultAsync();
            if (flow != null)
            {
                flow.Active = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeactivateFlowByIdAsync(long flowId)
        {
            var flow = await _context.Flows.Where(f => f.FlowId == flowId).FirstOrDefaultAsync();
            if (flow != null)
            {
                flow.Active = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Flow>> GetAllFlowsFromStorageAsync()
        {
            var flows = await _context.Flows.ToListAsync();
            return flows;
        }

        public async Task<IEnumerable<Flow>> GetAllOrganizationFlowsFromStorageAsync(int organizationId)
        {
            var flows = await _context.Flows.Where(f => f.OrganizationId == organizationId).ToListAsync();
            return flows;
        }

        public async Task<Flow> GetFlowByIdAsync(long flowId)
        {
            var flow = await _context.Flows.Where(f => f.FlowId == flowId).FirstOrDefaultAsync();        
            return flow;
        }

        public async Task<Flow> GetFlowByNameAsync(string name)
        {
            var flow = await _context.Flows.Where(f => f.Name == name).FirstOrDefaultAsync();
            return flow;
        }

        public async Task<Flow> GetFlowByTypeNameAsync(string flowTypeName)
        {
            var flow = await _context.Flows.Where(f => f.TypeName == flowTypeName).FirstOrDefaultAsync();
            return flow;        }

        public async Task SaveConfigurationsAsync(IFlowConfigurator flowConfigurator)
        {
            // Check if flow already exists by TypeName to avoid duplicates
            var existingFlow = await _context.Flows.Where(f => f.TypeName == flowConfigurator.TypeName).FirstOrDefaultAsync();
            if (existingFlow != null)
            {
                // Update existing flow with new configuration
                existingFlow.Name = flowConfigurator.Name;
                existingFlow.Description = flowConfigurator.Description;
                // Note: Version, QueueType, QueueName, CronExpression are stored in related tables
                existingFlow.LastUpdated = DateTime.Now;
                existingFlow.LastUpdatedBy = "System";
                existingFlow.Active = true;
            }
            else
            {
                // Create a new Flow entity using actual configurator values
                var flow = new Flow
                {
                    Name = flowConfigurator.Name,
                    Description = flowConfigurator.Description,
                    TypeName = flowConfigurator.TypeName,
                    // Note: Version, QueueType, QueueName, CronExpression are stored in related tables
                    OrganizationId = 1,
                    ExecutionModeId = 1, // Default to Auto execution mode
                    AssemblyName = "DidactCore", // Use actual assembly name
                    ConcurrencyLimit = 1,
                    Created = DateTime.Now,
                    CreatedBy = "System",
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = "System",
                    Active = true,
                    RowVersion = new byte[] { 0 } // Initialize RowVersion with a single byte for SQLite
                };

                _context.Flows.Add(flow);
            }

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you would normally inject a logger)
                Console.WriteLine($"An error occurred while saving the flow configurations: {ex.Message}");
                throw new SaveFlowConfigurationsException("Failed to save the flow configurations.", ex);
            }
        }
    }
}