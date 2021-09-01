namespace OpenIdentity.Endpoints
{
    public class EndpointResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string RedirectUrl { get; set; }
        public string Error { get; set; }
        public string Json { get; set; }
    }
}
