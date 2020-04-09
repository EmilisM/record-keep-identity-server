using System.Reflection;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using record_keep_auth_service;
using record_keep_identity_server.DBO;
using record_keep_identity_server.DBO.User;
using record_keep_identity_server.Validator;

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

            services.AddDbContext<UserContext>(optionsBuilder =>
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("RecordKeep")));

            services.AddSingleton<IAuthService, AuthService>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

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