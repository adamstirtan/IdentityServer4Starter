using IdentityModel.Client;

namespace Starter.Web.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly DiscoveryDocumentResponse _discoveryDocumentResponse;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;

            using var client = new HttpClient();

            _discoveryDocumentResponse = client.GetDiscoveryDocumentAsync(configuration.GetValue<string>("DiscoveryUrl")).Result;

            if (_discoveryDocumentResponse.IsError)
            {
                throw new Exception(_discoveryDocumentResponse.Exception.Message);
            }
        }

        public async Task<TokenResponse> GetToken(string scope)
        {
            using var client = new HttpClient();

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = _configuration.GetValue<string>("IdentityServer:DiscoveryUrl"),
                ClientId = _configuration.GetValue<string>("IdentityServer:ClientId"),
                ClientSecret = _configuration.GetValue<string>("IdentityServer:ClientSecret"),
                Scope = scope
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Exception.Message);
            }

            return tokenResponse;
        }
    }
}
