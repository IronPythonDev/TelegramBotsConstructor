using Google.Apis.Auth;
using IronPython.Authorization.Core.Interfaces;
using IronPython.Authorization.Core.Responses;
using IronPython.Authorization.Infrastructure;
using IronPython.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace IronPython.Authorization.Controllers
{
    [Route("authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public AuthorizationController(AuthorizationContext authorizationContext, IConfiguration configuration, IGoogleService googleService)
        {
            AuthorizationContext = authorizationContext;
            Configuration = configuration;
            GoogleService=googleService;
        }

        public AuthorizationContext AuthorizationContext { get; }
        public IConfiguration Configuration { get; }
        public IGoogleService GoogleService { get; }

        [HttpPost("withGoogle")]
        public async Task<IActionResult> WithGoogle([FromBody] object idToken)
        {
            try
            {
                var googleUser = await GoogleService.GetUserFromIdToken((string)JToken.Parse(idToken.ToString()!)["idToken"]!);

                var claims = new List<Claim>()
                {
                    new Claim("googleToken", googleUser!.Email!)
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
            catch (InvalidJwtException ex)
            {
                return BadRequest(new BadRequestResponse(ex.Message));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
