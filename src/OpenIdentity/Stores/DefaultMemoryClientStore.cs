using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenIdentity.Abstractions;
using OpenIdentity.Abstractions.Stores;
using System.Linq;

namespace OpenIdentity.Stores
{
    public class DefaultMemoryClientStore : IClientStore
    {
        internal static List<Client> _store = new List<Client>();

        public void AddClient(Client client)
        {
            // TODO Check client id exists.
            if (_store.Where(s=>s.Id.Equals(client.Id, System.StringComparison.OrdinalIgnoreCase)
            || s.Name.Equals(client.Name, System.StringComparison.OrdinalIgnoreCase)).Count() != 0)
            {
                throw new System.Exception("add duplicate client id or name");
            }
            _store.Add(client);
        }

        public Task<Client> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_store.FirstOrDefault(s => s.Id == id));
        }

        public Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_store.AsEnumerable());
        }
    }
}
