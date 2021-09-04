using System;
using System.Security.Cryptography;
using AspNet_5_0_Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenIdentity;
using OpenIdentity.Abstractions;

namespace AspNet_5_0_Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddOpenIdentity(options =>
            {

            }).AddUserService<UserService>()
            .AddClient(new Client()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "my mvc",
                ClientSecrets = new ClientSecret[]{ new ClientSecret() { Type = SecretType.Sha256, Value = "123456" } },
                Enabled = true,
                AllowedGrantTypes = new string[] { "password"},
                AllowedScopes = new string[] { "api"},
                
            });
            // .AddClients(new Client(),new Client())
            // .AddDbContext<>()
            // .AddClientStore<>();
            // 
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseOpenIdentity();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
