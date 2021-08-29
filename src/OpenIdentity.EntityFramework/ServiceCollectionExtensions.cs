using OpenIdentity.EntityFramework;
using OpenIdentity.EntityFramework.Stores;

namespace OpenIdentity
{
    public static class ServiceCollectionExtensions
    {
        public static OpenIdentityOptionsBuilder AddDbContext<TDbContext>(this OpenIdentityOptionsBuilder builder) where TDbContext : IdentityDbContext
        {
            builder.RegisterClientStore<ClientStore>();

            return builder;
        }
    }
}
