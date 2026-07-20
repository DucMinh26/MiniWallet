using Microsoft.AspNetCore.Mvc;

namespace MiniWalletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username != "admin" || request.Password != "admin")
            {
                var errorMessage = new ApiResponse<string>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = "sai tai khoang hoac mat khau"
                };

                return Unauthorized(errorMessage);
            }

            string token = _config["JwtSecret"];

            Console.WriteLine($"[TEST] Secret Key cua he thong la: {token}");

            var successResponse = new ApiResponse<string>
            {
                IsSuccess = true,
                Data = token,
                ErrorMessage = null

            };

            return Ok(successResponse);
        }

    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}