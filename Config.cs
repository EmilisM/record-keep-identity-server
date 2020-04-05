// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.EntityFrameworkCore;
using ApiResource = IdentityServer4.Models.ApiResource;
using Client = IdentityServer4.Models.Client;

namespace record_keep_identity_server
{
    public static class Config
    {
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "admin",
                    Password = "admin",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Test")
                    }
                }
            };
        }

        public static void ConfigurationDbContextSeed(this ModelBuilder modelBuilder)
        {
            var clientGrantTypeEntity = new ClientGrantType
            {
                Id = -1,
                GrantType = GrantType.ResourceOwnerPassword,
                ClientId = -1
            };

            var clientScopesEntity = new ClientScope
            {
                ClientId = -1,
                Id = -1,
                Scope = "record-keep-api"
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

            var apiResourceClaimEntity = new ApiResourceClaim()
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

            modelBuilder.Entity<ClientGrantType>().HasData(clientGrantTypeEntity);
            modelBuilder.Entity<ClientScope>().HasData(clientScopesEntity);
            modelBuilder.Entity<ClientSecret>().HasData(clientSecretsEntity);
            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.Client>().HasData(clientEntity);

            modelBuilder.Entity<ApiSecret>().HasData(apiSecretEntity);
            modelBuilder.Entity<ApiResourceClaim>().HasData(apiResourceClaimEntity);
            modelBuilder.Entity<ApiScope>().HasData(apiResourceScopesEntity);
            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResource>().HasData(apiResourceEntity);
        }
    }
}