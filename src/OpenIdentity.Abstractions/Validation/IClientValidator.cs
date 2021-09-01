using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OpenIdentity.Models;

namespace OpenIdentity.Validation
{
    public interface IClientValidator
    {
        /// <summary>
        ///  Validate the http request.
        /// </summary> 
        Task<ClientValidationResult> ValidateAsync(HttpContext httpContext);
    }
}
