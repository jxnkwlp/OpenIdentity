using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OpenIdentity.Endpoints;

namespace OpenIdentity
{
    public static class ApplicationBuilderExtensions
    {

        private static async Task MappingEndpointHandle<T>(IApplicationBuilder app,HttpContext context) where T : IRouteEndpointHandler
        {
            using var scope = app.ApplicationServices.CreateScope();

            var endpoint = scope.ServiceProvider.GetRequiredService<T>();

            var request = context.Request;

            var response = await endpoint.HandleAsync(new RouteEndpointHandleRequest(request.Method, request.Query, request.Form));

            if (!string.IsNullOrWhiteSpace(response.RedirectUrl))
            {
                context.Response.Redirect(response.RedirectUrl);

                return;
            }

            context.Response.StatusCode = response.StatusCode;

            if (!string.IsNullOrWhiteSpace(response.Json))
                context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(response.Json);
        }

        public static IApplicationBuilder UseOpenIdentity(this IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet(ProtocolRoutePaths.Authorize, async (context) =>
            {
                await MappingEndpointHandle<AuthorizationEndpoint>(app, context);

            }).MapGet(ProtocolRoutePaths.Token,async (context) =>
            {
                await MappingEndpointHandle<TokenEndpoint>(app, context);
            });

            app.UseRouter(routeBuilder.Build());
            return app;
        }
    }
}
