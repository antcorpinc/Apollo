﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apollo.Api.BackOffice.MappingConfig;
using Apollo.Data;
using Apollo.Data.DataRepository;
using Apollo.Data.Interface;
using Apollo.Service.Common;
using Apollo.Service.Common.Interface;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Apollo.Api.BackOffice
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
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                  .AddIdentityServerAuthentication(options =>
                  {
                      options.Authority = Configuration["BaseUrls:Sts"];
                      options.RequireHttpsMetadata = false;
                      options.ApiName = "apollo.api.backoffice";
                  });
            services.AddScoped<IStateRepository, StateRepository>();

            services.AddScoped<IStateService, StateService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BackOffice Management API", Version = "v1" });
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
            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Society Management API V1");
            });
            // Todo: Need to add the content security policy (CSP) - Refer PS of Brian Noyes 
            app.UseAuthentication();
            app.UseMvc();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new BackOfficeMgmtMappingProfile());
            });
        }
    }
}
