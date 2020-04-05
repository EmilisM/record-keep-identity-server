using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace record_keep_identity_server.DBO
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CustomConfigurationDbContext : ConfigurationDbContext<CustomConfigurationDbContext>
    {
        public CustomConfigurationDbContext(DbContextOptions<CustomConfigurationDbContext> options,
            ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurationDbContextSeed();
        }
    }
}