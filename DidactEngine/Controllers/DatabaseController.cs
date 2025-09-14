using DidactCore.Entities;
using DidactEngine.Services.Contexts;
using DidactEngine.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DidactEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly DidactDbContext _dbContext;
        private readonly DatabaseInitializer _databaseInitializer;
        private readonly ILogger<DatabaseController> _logger;

        public DatabaseController(
            DidactDbContext dbContext,
            DatabaseInitializer databaseInitializer,
            ILogger<DatabaseController> logger)
        {
            _dbContext = dbContext;
            _databaseInitializer = databaseInitializer;
            _logger = logger;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetDatabaseStatus()
        {
            try
            {
                var isSqlite = _dbContext.Database.ProviderName?.Contains("Sqlite") ?? false;
                var databaseExists = await _dbContext.Database.CanConnectAsync();
                
                var status = new
                {
                    Provider = _dbContext.Database.ProviderName,
                    IsSqlite = isSqlite,
                    ConnectionString = isSqlite 
                        ? _dbContext.Database.GetConnectionString() 
                        : "[REDACTED]", // Don't expose SQL Server connection strings
                    DatabaseExists = databaseExists,
                    FlowCount = await _dbContext.Flows.CountAsync(),
                    FlowRunCount = await _dbContext.FlowRuns.CountAsync(),
                    OrganizationCount = await _dbContext.Organizations.CountAsync()
                };
                
                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting database status");
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("initialize")]
        public async Task<IActionResult> InitializeDatabase()
        {
            try
            {
                await _databaseInitializer.InitializeAsync();
                return Ok(new { Message = "Database initialized successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initializing database");
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("seed-test-data")]
        public async Task<IActionResult> SeedTestData()
        {
            try
            {
                // Create a test organization if needed
                if (!await _dbContext.Organizations.AnyAsync(o => o.Name == "Test Organization"))
                {
                    _dbContext.Organizations.Add(new Organization
                    {
                        Name = "Test Organization",
                        Active = true,
                        Created = DateTime.UtcNow,
                        CreatedBy = "Test User",
                        LastUpdated = DateTime.UtcNow,
                        LastUpdatedBy = "Test User"
                    });
                    
                    await _dbContext.SaveChangesAsync();
                }
                
                // Get the organization ID
                var organization = await _dbContext.Organizations.FirstAsync(o => o.Name == "Test Organization");
                
                // Create some test flows
                for (int i = 1; i <= 5; i++)
                {
                    var flowName = $"Test Flow {i}";
                    
                    if (!await _dbContext.Flows.AnyAsync(f => f.Name == flowName))
                    {
                        var flow = new Flow
                        {
                            Name = flowName,
                            OrganizationId = organization.OrganizationId,
                            Description = $"Test flow {i} description",
                            AssemblyName = "DidactCore",
                            TypeName = $"DidactCore.Flows.TestFlow{i}",
                            ConcurrencyLimit = 1,
                            Created = DateTime.UtcNow,
                            CreatedBy = "Test User",
                            LastUpdated = DateTime.UtcNow,
                            LastUpdatedBy = "Test User",
                            Active = true
                        };
                        
                        _dbContext.Flows.Add(flow);
                    }
                }
                
                await _dbContext.SaveChangesAsync();
                
                return Ok(new { Message = "Test data seeded successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error seeding test data");
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}