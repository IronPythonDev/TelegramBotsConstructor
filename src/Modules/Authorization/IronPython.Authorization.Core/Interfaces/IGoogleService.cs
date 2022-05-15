using System.Text.Json.Serialization;

namespace IronPython.Authorization.Core.Interfaces
{
    public interface IGoogleService
    {
        Task<string> GetTokenFromAuthCode(string authCode);
        Task<GoogleUserInfo?> GetUserInfo(string accessToken);
    }
}
