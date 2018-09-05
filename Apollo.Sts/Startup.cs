using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apollo.Data;
using Apollo.Domain.Entity;
using Apollo.Sts.Configuration;
using Apollo.Sts.Settings;
using IdentityServer4.Quickstart.UI;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Apollo.Sts
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApolloContext>(
                options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("ApolloContextConnection"));
                });
            services.AddIdentity<ApolloUser, ApolloRole>()
                .AddEntityFrameworkStores<ApolloContext>()
                .AddDefaultTokenProviders();
            services.AddOptions();
            services.Configure<AppSettings>(Configuration);

            services.AddMvc();

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential() // Todo Change to PROD certificate
                    .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                    .AddAspNetIdentity<ApolloUser>()
                    .AddProfileService<ApolloProfileService>()
                    .AddClientStore<ApolloClientStore>();

            services.AddScoped<IProfileService, ApolloProfileService>();
            services.AddSingleton<IClientStore, ApolloClientStore>();

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            AccountOptions.ShowLogoutPrompt = false;
            AccountOptions.AutomaticRedirectAfterSignOut = true;

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });

            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();

        }
    }
}
