using System.Threading.Tasks;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public interface ITokenService
    {
        Task<Token> CreateAccessTokenAsync(TokenSource token);

        Task<Token> CreateIdentityTokenAsync(TokenSource token);

        Task<string > CreateRefreshTokenAsync(TokenSource token);

        Task<string> CreateSecurityTokenAsync(Token token);

    }
}
