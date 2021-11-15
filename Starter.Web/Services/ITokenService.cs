using IdentityModel.Client;

namespace Starter.Web.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
