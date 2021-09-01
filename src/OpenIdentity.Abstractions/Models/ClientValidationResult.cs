using OpenIdentity.Abstractions;

namespace OpenIdentity.Models
{
    public class ClientValidationResult : ValidationResult
    {
        public Client Client { get; set; }

        public ClientSecret ClientSecret { get; set; }
    } 
}
