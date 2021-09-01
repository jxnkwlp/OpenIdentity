using System;
using System.Threading.Tasks;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public class UserService : IUserService
    {
        public Task<UserValidationResult> ValidateAsync(UserValidationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
