using Google.Apis.Auth;

namespace IronPython.Authorization.Core.Interfaces
{
    public interface IGoogleService
    {
        Task<GoogleJsonWebSignature.Payload> GetUserFromIdToken(string token);
    }
}
