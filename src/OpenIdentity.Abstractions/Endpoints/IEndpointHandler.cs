using System.Threading.Tasks;
using OpenIdentity.Endpoints.Results;

namespace OpenIdentity.Endpoints
{
    public interface IEndpointHandler
    {
        Task<IEndpointHandleResult> HandleAsync(EndpointHandleContext context);
    }
}
