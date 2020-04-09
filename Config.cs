using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using ApiResource = IdentityServer4.Models.ApiResource;
using Client = IdentityServer4.Models.Client;
using IdentityResource = IdentityServer4.EntityFramework.Entities.IdentityResource;

namespace record_keep_identity_server
{
    public static class Config
    {
        public static void ConfigurationDbContextSeed(this ModelBuilder modelBuilder)
        {
            var clientGrantTypeEntity = new ClientGrantType
            {
                Id = -1,
                GrantType = GrantType.ResourceOwnerPassword,
                ClientId = -1,
            };

            var clientScopes = new[]
            {
                new ClientScope
                {
                    ClientId = -1,
                    Id = -1,
                    Scope = "record-keep-api"
                },
                new ClientScope
                {
                    ClientId = -1,
                    Id = -2,
                    Scope = IdentityServerConstants.StandardScopes.OpenId
                },
                new ClientScope
                {
                    ClientId = -1,
                    Id = -3,
                    Scope = IdentityServerConstants.StandardScopes.Profile
                }
            };

            var clientSecretsEntity = new ClientSecret
            {
                Id = -1,
                ClientId = -1,
                Value = "record-keep-secret".Sha256()
            };

            var client = new Client
            {
                ClientId = "record-keep",
                AccessTokenType = AccessTokenType.Jwt,
            };

            var clientEntity = client.ToEntity();
            clientEntity.Id = -1;

            var apiSecretEntity = new ApiSecret
            {
                Id = -1,
                ApiResourceId = -1,
                Value = "record-keep-api-secret".Sha256()
            };

            var apiResourceClaimEntity = new ApiResourceClaim
            {
                Id = -1,
                ApiResourceId = -1,
                Type = JwtClaimTypes.Name
            };

            var apiResourceScopesEntity = new ApiScope
            {
                Name = "record-keep-api",
                Id = -1,
                DisplayName = "Record Keep API",
                ApiResourceId = -1,
            };

            var apiResource = new ApiResource
            {
                Name = "record-keep-api",
                DisplayName = "Record Keep API"
            };

            var apiResourceEntity = apiResource.ToEntity();
            apiResourceEntity.Id = -1;

            var openIdIdentity = new IdentityResources.OpenId().ToEntity();
            var profileIdentity = new IdentityResources.Profile().ToEntity();

            openIdIdentity.Id = -1;
            profileIdentity.Id = -2;

            var identityClaimOpenId = new IdentityClaim
            {
                Id = -1,
                Type = JwtClaimTypes.Subject,
                IdentityResourceId = -1
            };

            var identityClaims = new List<IdentityClaim>
            {
                identityClaimOpenId
            };

            var index = -2;
            foreach (var claims in profileIdentity.UserClaims)
            {
                identityClaims.Add(new IdentityClaim
                {
                    Id = index,
                    Type = claims.Type,
                    IdentityResourceId = -2,
                });

                index--;
            }

            openIdIdentity.UserClaims = new List<IdentityClaim>();
            profileIdentity.UserClaims = new List<IdentityClaim>();

            modelBuilder.Entity<ClientGrantType>().HasData(clientGrantTypeEntity);
            modelBuilder.Entity<ClientScope>().HasData(clientScopes);
            modelBuilder.Entity<ClientSecret>().HasData(clientSecretsEntity);
            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.Client>().HasData(clientEntity);

            modelBuilder.Entity<ApiSecret>().HasData(apiSecretEntity);
            modelBuilder.Entity<ApiResourceClaim>().HasData(apiResourceClaimEntity);
            modelBuilder.Entity<ApiScope>().HasData(apiResourceScopesEntity);
            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResource>().HasData(apiResourceEntity);

            modelBuilder.Entity<IdentityResource>().HasData(openIdIdentity, profileIdentity);
            modelBuilder.Entity<IdentityClaim>().HasData(identityClaims);
        }
    }
}