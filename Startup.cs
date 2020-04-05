// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using record_keep_identity_server.DBO;

namespace record_keep_identity_server
{
    public class Startup
    {
        private IWebHostEnvironment Environment { get; }
        private IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            var connectionStringIdentity = Configuration.GetConnectionString("RecordKeepIdentity");

            var builder = services.AddIdentityServer()
                .AddTestUsers(Config.GetTestUsers())
                .AddJwtBearerClientAuthentication()
                .AddConfigurationStore<CustomConfigurationDbContext>(options =>
                {
                    options.ConfigureDbContext = optionsBuilder =>
                        optionsBuilder.UseNpgsql(connectionStringIdentity,
                            contextOptionsBuilder => contextOptionsBuilder.MigrationsAssembly(migrationsAssembly));
                }).AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = optionsBuilder => optionsBuilder.UseNpgsql(connectionStringIdentity,
                        contextOptionsBuilder => contextOptionsBuilder.MigrationsAssembly(migrationsAssembly));
                    options.EnableTokenCleanup = true;
                });

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
        }
    }
}