using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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

            string realToken = GenerateJwtToken(request.Username, token);

            var successResponse = new ApiResponse<string>
            {
                IsSuccess = true,
                Data = realToken,
                ErrorMessage = null

            };

            return Ok(successResponse);
        }

        private string GenerateJwtToken(string username, string secretKey)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "MiniWalletSystem",
                audience: "MiniWalletUser",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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