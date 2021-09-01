using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public interface IUserService
    {
        Task<bool> VerifyAsync(string userName, string password, UserVerifyRequest userVerifyRequest = null,CancellationToken cancellationToken = default);
    }
}
