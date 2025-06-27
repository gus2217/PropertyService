using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace KejaHUnt_PropertiesAPI.Controllers  
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly string _connectionString;

        public TestController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet("test-db")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                return Ok("Connection successful");
            }
            catch (Exception ex)
            {
                return BadRequest($"Connection failed: {ex.Message}");
            }
        }
    }
}
