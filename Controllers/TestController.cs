using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace KejaHUnt_PropertiesAPI.Controllers  // Project namespace
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet("test-db")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    return BadRequest("Connection string is null or empty");
                }

                // Now test the actual database connection
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                return Ok("Database connection successful!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Database connection failed: {ex.Message}");
            }
        }
    }
}
