using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public class UserService : IUserService
    {
        public Task<bool> VerifyAsync(string userName, string password, UserVerifyRequest userVerifyRequest, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(false);
        }
    }
}
