namespace OpenIdentity.Models
{
    public class ValidationResult
    {
        public bool Success => !string.IsNullOrEmpty(Error);

        public string ErrorDescription { get; set; }

        public string Error { get; set; }

    }
}
