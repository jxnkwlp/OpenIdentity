namespace OpenIdentity
{
    public static class ProtocolRoutePaths
    {
        public const string DiscoveryConfiguration = ".well-known/openid-configuration";
        public const string DiscoveryWebKeys = DiscoveryConfiguration + "/jwks";
        public const string Authorize = "connect/authorize";
        public const string AuthorizeCallback = Authorize + "/callback";
        public const string Token = "connect/token";
        public const string Revocation = "connect/revocation";
        public const string UserInfo = "connect/userinfo";
        public const string Introspection = "connect/introspect";
        public const string CheckSession = "connect/checksession";
        public const string EndSession = "connect/endsession";
        public const string EndSessionCallback = EndSession + "/callback";

        public static readonly string[] CorsPaths =
        {
            DiscoveryConfiguration,
            DiscoveryWebKeys,
            Token,
            UserInfo,
            Revocation
        };



    }

    public class GrandTypes
    {
        public const string Password = "password";
        public const string AuthorizationCode = "authorization_code";
        public const string ClientCredentials = "client_credentials";
        public const string RefreshToken = "refresh_token";
        public const string Implicit = "implicit";
        public const string DeviceCode = "urn:ietf:params:oauth:grant-type:device_code";
    }
}
