using System;
using System.Collections.Generic;
using System.Security.Claims;
using OpenIdentity.Abstractions;

namespace OpenIdentity.Models
{
    public interface ITokenMetadata
    {
        string Audience { get; set; }

        string Issuer { get; set; }

        DateTimeOffset CreationTime { get; set; }

        int Lifetime { get; set; }

        string Type { get; set; }

        Client Client { get; set; }

        List<Claim> Claims { get; set; }

    }
}
