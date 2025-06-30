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
                // Debug all configuration sources
                var allConfig = new Dictionary<string, string>();
                foreach (var item in _configuration.AsEnumerable())
                {
                    allConfig[item.Key] = item.Value;
                }

                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    return BadRequest($"Connection string is null. Available keys: {string.Join(", ", allConfig.Keys.Where(k => k.Contains("Connection")))}");
                }

                // Show actual connection string details (safely)
                var parts = connectionString.Split(';');
                var safeParts = parts.Select(p => p.Contains("Password") ? "Password=***" : p);

                return Ok($"Connection string parts: {string.Join("; ", safeParts)}");

                // Comment out actual connection test for now
                // using var connection = new SqlConnection(connectionString);
                // await connection.OpenAsync();
                // return Ok("Database connection successful!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message} | StackTrace: {ex.StackTrace}");
            }
        }
    }
}
