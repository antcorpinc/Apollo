using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apollo.Api.UserManagement.MappingConfig;
using Apollo.Data;
using Apollo.Data.DataRepository;
using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Domain.DTO.Base;
using Apollo.Domain.Entity;
using Apollo.Service.UserManagement;
using Apollo.Service.UserManagement.Interface;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Apollo.Api.UserManagement
{
    public class Startup
    {
        public static IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddCors();
            services.AddDbContext<ApolloContext>(
                options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("ApolloContextConnection"));
                });
            services.AddTransient<ApolloContextSeedData>();
            services.AddIdentity<ApolloUser, ApolloRole>()
                    .AddEntityFrameworkStores<ApolloContext>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.Authority = Configuration["BaseUrls:Sts"];
                       options.RequireHttpsMetadata = false;
                       options.Audience = "apollo.api.usermanagement";
                   });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IUserAppRoleMappingRepository, UserAppRoleMappingRepository>();
            services.AddScoped<ICustomSocietyUserRepository, CustomSocietyUserRepository>();
            services.AddScoped<ICustomRoleRepository, CustomRoleRepository>();
            services.AddScoped<ICustomApplicationRepository, CustomApplicationRepository>();
            services.AddScoped<ICustomFeatureRepository, CustomFeatureRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISupportUserService, SupportUserService>();
            services.AddScoped<ISocietyUserService, SocietyUserService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFeatureService, FeatureService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "User Management API", Version = "v1" });
            });

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseExceptionHandler(appBuilder  =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }
           
            // Todo: Need to be more specific for the CORS policy - Refer PS of Brian Noyes 

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API V1");
            });
            // Todo: Need to add the content security policy (CSP) - Refer PS of Brian Noyes 
            app.UseAuthentication();
            app.UseMvc();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new UserMgmtMappingProfile());
            });
            
            // Do it in the last Seed Data only in Development
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<ApolloContextSeedData>();
                    // Make it like Sync        
                    seeder.SeedAsync().Wait();                   
                }
            }
        }
    }
}
