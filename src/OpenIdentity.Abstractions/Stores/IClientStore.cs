using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenIdentity.Abstractions.Stores
{
    public interface IClientStore
    {
        Task<Client> FindByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
