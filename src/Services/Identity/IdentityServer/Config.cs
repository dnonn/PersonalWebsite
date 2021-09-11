// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("chat")
            };

        public static IEnumerable<Client> Clients(IConfiguration configuration) =>
            new Client[]
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("812dc01e-bd77-4257-bfeb-944ae5f8f1e3".Sha256()) },
                    ClientUri = configuration["MvcClient"],

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,
                    
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris =
                    {
                        $"{configuration["MvcClient"]}/signin-oidc"
                    },

                    PostLogoutRedirectUris =
                    {
                        $"{configuration["MvcClient"]}/signout-callback-oidc"
                    },

                    AllowedScopes =
                    {

                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "chat"
                    },
                    
                    AccessTokenLifetime = 60*60*2, // 2 hours
                    IdentityTokenLifetime= 60*60*2 // 2 hours
                },
                new Client
                {
                    ClientId = "postman",
                    ClientSecrets = { new Secret("812dc01e-bd77-4257-bfeb-944ae5f8f1e3".Sha256()) },
                    ClientUri = configuration["MvcClient"],

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequirePkce = false,
                    
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris =
                    {
                        $"{configuration["MvcClient"]}/signin-oidc"
                    },

                    PostLogoutRedirectUris =
                    {
                        $"{configuration["MvcClient"]}/signout-callback-oidc"
                    },

                    AllowedScopes =
                    {

                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "chat"
                    },
                    
                    AccessTokenLifetime = 60*60*2, // 2 hours
                    IdentityTokenLifetime= 60*60*2 // 2 hours
                },
                new Client
                {
                    ClientId = "AngularClient",
                    ClientName = "Angular Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =
                    {
                        "http://localhost:4200/oidc-login-redirect",
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:4200/?postLogout=true",
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:4200",
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "chat"
                    },
                    ClientSecrets =
                    {
                        new Secret("812dc01e-bd77-4257-bfeb-944ae5f8f1e3".Sha256()),
                    },
                    AllowOfflineAccess = true,
                    RequireConsent = true,
                }
            };
    }
}