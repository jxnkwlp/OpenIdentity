using System.Security.Claims;

namespace OpenIdentity.Models
{
    public class UserValidationResult : ValidationResult
    {
        public ClaimsPrincipal Principal { get; set; }
    }
}
