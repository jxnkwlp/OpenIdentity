using System.Threading.Tasks;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public interface ISecurityTokenService
    {
        Task<string> SignTokenAsync(Token token);

        Task<string> EncryptTokenAsync(Token token);

        Task<TokenValidationResult> ValidateAsync(string token, string issuer, string audience, bool validateLifetime = true);

    }
}
