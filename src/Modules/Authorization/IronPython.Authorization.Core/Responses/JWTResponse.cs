using System.Text.Json.Serialization;

namespace IronPython.Authorization.Core.Responses
{
    public class JWTResponse
    {
        [JsonPropertyName("access_token")] public string AccessToken { get; set; }
        [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; }
    }
}
