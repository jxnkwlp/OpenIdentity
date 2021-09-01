using System;
using System.Collections.Generic;

namespace OpenIdentity.Abstractions
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Enabled { get; set; }
        public bool ConsentRequired { get; set; }

        public string[] AllowedGrantTypes { get; set; }
        public string[] AllowedScopes { get; set; }

        public Uri[] PostLogoutRedirectUris { get; set; }
        public Uri[] RedirectUris { get; set; }

        public ClientSecret[] ClientSecrets { get; set; }
        public bool RequireSecret { get; set; }

        public Dictionary<string, object> Properties { get; set; }

    }
}
