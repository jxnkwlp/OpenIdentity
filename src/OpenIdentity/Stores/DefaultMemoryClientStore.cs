using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenIdentity.Abstractions;
using OpenIdentity.Abstractions.Stores;

namespace OpenIdentity.Stores
{
    public class DefaultMemoryClientStore : IClientStore
    {
        internal static List<Client> _store = new List<Client>();

        public static void AddClient(Client client)
        {
            // TODO Check client id exists.

            _store.Add(client);
        }

        public Task<Client> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
