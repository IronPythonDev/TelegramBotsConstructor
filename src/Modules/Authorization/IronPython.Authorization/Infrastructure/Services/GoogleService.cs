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
        public GoogleService(HttpClient httpClient, IConfiguration configuration)
        {
            HttpClient=httpClient;
            Configuration=configuration;
        }

        public HttpClient HttpClient { get; }
        public IConfiguration Configuration { get; }

        public async Task<string> GetTokenFromAuthCode(string authCode)
        {
            var content = new MultipartFormDataContent();

            var longUrl = "https://accounts.google.com/o/oauth2/token";
            var uriBuilder = new UriBuilder(longUrl);
            var query = HttpUtility.ParseQueryString(longUrl);

            query["client_id"] = Configuration["GoogleCloudConfig:ClientId"];
            query["client_secret"] = Configuration["GoogleCloudConfig:ClientSecret"];
            query["grant_type"] = "authorization_code";
            query["redirect_uri"] = "postmessage";
            query["code"] = authCode;

            uriBuilder.Query = query.ToString();

            var response = await HttpClient.PostAsync(uriBuilder.Uri, content);
            
            return (string)JToken.Parse(await response.Content.ReadAsStringAsync())["access_token"];
        }

        public async Task<GoogleUserInfo?> GetUserInfo(string accessToken)
        {
            var response = await HttpClient.GetAsync($"https://www.googleapis.com/oauth2/v1/userinfo?access_token={accessToken}");

            return JsonConvert.DeserializeObject<GoogleUserInfo>(await response.Content.ReadAsStringAsync());
        }
    }
}
