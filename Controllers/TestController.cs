using Microsoft.AspNetCore.Mvc;

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
                // Multiple ways to get the connection string
                var method1 = _configuration.GetConnectionString("DefaultConnection");
                var method2 = _configuration["ConnectionStrings:DefaultConnection"];
                var method3 = _connectionString; // from constructor

                // Environment check
                var environment = _configuration["ASPNETCORE_ENVIRONMENT"];
                var isDevelopment = environment == "Development";

                var debugInfo = new
                {
                    Method1_GetConnectionString = method1 ?? "NULL",
                    Method2_DirectAccess = method2 ?? "NULL",
                    Method3_Constructor = method3 ?? "NULL",
                    Environment = environment ?? "NULL",
                    ConnectionStringLength = method1?.Length ?? 0,
                    FirstChars = method1?.Length > 0 ? method1.Substring(0, Math.Min(20, method1.Length)) : "EMPTY"
                };

                return Ok(debugInfo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Debug Error: {ex.Message}");
            }
        }
    }
}
