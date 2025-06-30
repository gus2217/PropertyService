using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace KejaHUnt_PropertiesAPI.Controllers
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
                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    return BadRequest("Connection string is null or empty");
                }

                // Test the actual database connection
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();

                // If we get here, connection worked
                return Ok("Database connection successful!");
            }
            catch (SqlException sqlEx)
            {
                return BadRequest($"SQL Error: {sqlEx.Message} | Error Number: {sqlEx.Number}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Connection Error: {ex.Message}");
            }
        }
    }
}
