using IronPython.Authorization.Core.Responses;
using IronPython.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IronPython.Authorization.Controllers
{
    [Route("authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public AuthorizationController(AuthorizationContext authorizationContext, IConfiguration configuration)
        {
            AuthorizationContext = authorizationContext;
            Configuration = configuration;
        }

        public AuthorizationContext AuthorizationContext { get; }
        public IConfiguration Configuration { get; }

        [HttpPost("withGoogle")]
        public IActionResult WithGoogle()
        {
            var claims = new List<Claim>()
            {
                new Claim("googleToken", "vlad1234")
            };

            var accessJWT = new JwtSecurityToken(
                    issuer: Configuration["JWTConfig:Issuer"],
                    audience: Configuration["JWTConfig:Audience"],
                    expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                    claims: claims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTConfig:Key"])), SecurityAlgorithms.HmacSha256));

            return Ok(new JWTResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessJWT),
                RefreshToken = "vlad1234"
            });
        }
    }
}
