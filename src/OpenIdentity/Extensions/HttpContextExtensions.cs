using System;
using Microsoft.AspNetCore.Http;

namespace OpenIdentity.Extensions
{
    public static class HttpContextExtensions
    {
        private static string TryFindValue(HttpContext context, string key)
        {
            var request = context.Request;

            if (request.Query.TryGetValue(key, out var value))
            {
                return value.ToString();
            }

            // TODO
            throw new NotImplementedException();
        }

        public static string GetClientId(this HttpContext context)
        {
            return TryFindValue(context, "client_id");
        }

        public static string GetClientSecret(this HttpContext context)
        {
            return TryFindValue(context, "client_secret");
        }

        public static string GetGrantType(this HttpContext context)
        {
            return TryFindValue(context, "grant_type");
        }


        public static string Get(this IFormCollection forms, string key)
        {
            if (forms.TryGetValue(key, out var value))
            {
                return value.ToString();
            }
            return null;
        }
    }
}
