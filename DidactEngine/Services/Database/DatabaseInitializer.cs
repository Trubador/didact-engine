using DidactEngine.Services.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DidactEngine.Services.Database
{
    public class DatabaseInitializer
    {
        private readonly ILogger<DatabaseInitializer> _logger;
        private readonly DidactDbContext _dbContext;

        public DatabaseInitializer(ILogger<DatabaseInitializer> logger, DidactDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }        public async Task InitializeAsync()
        {
            try
            {
                _logger.LogInformation("Initializing the database...");
                
                // Use migrations for all database providers
                await _dbContext.Database.MigrateAsync();
                _logger.LogInformation("Database migrations applied successfully");
                
                // Seed initial data if needed
                await SeedInitialDataAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database");
                throw;
            }
        }

        private async Task SeedInitialDataAsync()
        {            // Add any initial seeding logic here
            // For example, ensure there's at least one organization            if (!await _dbContext.Organizations.AnyAsync())
            {                _dbContext.Organizations.Add(new DidactCore.Entities.Organization
                {
                    Name = "Default Organization",
                    Active = true,
                    Created = DateTime.UtcNow,
                    CreatedBy = "System",
                    LastUpdated = DateTime.UtcNow,
                    LastUpdatedBy = "System",
                    RowVersion = new byte[8] // Explicitly set RowVersion for SQLite compatibility
                });
                
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Default organization seeded successfully");
            }

            // Seed ExecutionModes if they don't exist
            if (!await _dbContext.ExecutionModes.AnyAsync())
            {
                var executionModes = new[]
                {
                    new DidactCore.Entities.ExecutionMode
                    {
                        Name = DidactCore.Constants.ExecutionModes.Auto,
                        Description = "Automatically execute flow runs when triggered",
                        Active = true,
                        Created = DateTime.UtcNow,
                        CreatedBy = "System",
                        LastUpdated = DateTime.UtcNow,
                        LastUpdatedBy = "System",
                        RowVersion = new byte[8]
                    },
                    new DidactCore.Entities.ExecutionMode
                    {
                        Name = DidactCore.Constants.ExecutionModes.Deferred,
                        Description = "Queue flow runs for deferred execution",
                        Active = true,
                        Created = DateTime.UtcNow,
                        CreatedBy = "System",
                        LastUpdated = DateTime.UtcNow,
                        LastUpdatedBy = "System",
                        RowVersion = new byte[8]
                    },
                    new DidactCore.Entities.ExecutionMode
                    {
                        Name = DidactCore.Constants.ExecutionModes.Manual,
                        Description = "Require manual trigger to execute flow runs",
                        Active = true,
                        Created = DateTime.UtcNow,
                        CreatedBy = "System",
                        LastUpdated = DateTime.UtcNow,
                        LastUpdatedBy = "System",
                        RowVersion = new byte[8]
                    }
                };

                _dbContext.ExecutionModes.AddRange(executionModes);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("ExecutionModes seeded successfully");
            }
            
            // Add more seeding as needed for other required data
        }
    }
}