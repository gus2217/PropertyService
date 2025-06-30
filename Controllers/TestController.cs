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
                // Step 1: Check if connection string exists
                if (string.IsNullOrEmpty(_connectionString))
                {
                    return BadRequest("Connection string 'DefaultConnection' is null or empty");
                }

                // Step 2: Show the connection string (first 60 characters for security)
                var preview = _connectionString.Length > 60 ? 
                    _connectionString.Substring(0, 60) + "..." : 
                    _connectionString;
                
                return Ok($"Connection string found: {preview}");

                // We'll test the actual connection in the next step
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
