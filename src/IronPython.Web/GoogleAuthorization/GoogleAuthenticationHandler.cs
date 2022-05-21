using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace IronPython.Api.GoogleAuthorization
{
    public class GoogleAuthenticationHandler : AuthenticationHandler<GoogleAuthenticationSchemeOptions>
    {
        public GoogleAuthenticationHandler(
            IOptionsMonitor<GoogleAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                if (!Request.Headers.ContainsKey("Authorization"))
                    return AuthenticateResult.NoResult();

                var header = Request.Headers["Authorization"].ToString();

                var googleUser = await GoogleJsonWebSignature.ValidateAsync(header);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, googleUser.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, nameof(GoogleAuthenticationHandler));

                var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Exception");
            }
        }
    }
}
