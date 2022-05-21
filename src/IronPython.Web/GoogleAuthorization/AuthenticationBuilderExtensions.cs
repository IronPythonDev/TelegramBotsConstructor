using Microsoft.AspNetCore.Authentication;

namespace IronPython.Api.GoogleAuthorization
{
    public static class AuthenticationBuilderExtensions
    {
        public static string GoogleAuthScheme = "GoogleAuthScheme";

        public static AuthenticationBuilder AddIronGoogle(this AuthenticationBuilder builder) =>
            builder.AddScheme<GoogleAuthenticationSchemeOptions, GoogleAuthenticationHandler>("GoogleAuthScheme", op => { });
    }
}
