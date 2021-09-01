using System.Threading.Tasks;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public interface ITokenService
    {
        Task<Token> SigningAsync(TokenSource token);

    }
}
