using System.Threading.Tasks;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public interface IUserService
    {
        Task<UserValidationResult> ValidateAsync(UserValidationRequest request);
    }
}
