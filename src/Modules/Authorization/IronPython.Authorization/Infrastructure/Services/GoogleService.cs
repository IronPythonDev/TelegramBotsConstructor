using Google.Apis.Auth;
using IronPython.Authorization.Core;
using IronPython.Authorization.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;

namespace IronPython.Authorization.Infrastructure.Services
{
    public class GoogleService : IGoogleService
    {
        public GoogleService(IConfiguration configuration)
        {
            Configuration=configuration;
        }

        public IConfiguration Configuration { get; }


        public async Task<GoogleJsonWebSignature.Payload> GetUserFromIdToken(string token) => await GoogleJsonWebSignature.ValidateAsync(token);
    }
}
