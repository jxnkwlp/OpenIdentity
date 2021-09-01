using System.Collections.Generic;

namespace OpenIdentity.Models
{
    public class UserValidationRequest
    {
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Dictionary<string, object> Additionals { get; set; }
    }
}
