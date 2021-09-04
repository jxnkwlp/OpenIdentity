using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet_5_0_Server.Models;
using OpenIdentity.Models;
using OpenIdentity.Services;

namespace AspNet_5_0_Server.Services
{
    public class UserService : IUserService
    {
        private static List<User> _users = new List<User>() { new User() { UserName="admin", Password = "123" } };
        public Task<UserValidationResult> ValidateAsync(UserValidationRequest request)
        {
            UserValidationResult userValidationResult = new UserValidationResult();

            var user = _users.FirstOrDefault(s => s.UserName == request.UserName && s.Password == request.Password);

            if (user == null)
            {
                userValidationResult.Error = "user not found";
            }
            
            return Task.FromResult(userValidationResult);
        }
    }
}
