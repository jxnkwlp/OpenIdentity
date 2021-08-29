using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenIdentity.Abstractions;
using OpenIdentity.Abstractions.Stores;

namespace OpenIdentity.EntityFramework.Stores
{
    public class ClientStore : IClientStore
    {
        public Task<Client> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
