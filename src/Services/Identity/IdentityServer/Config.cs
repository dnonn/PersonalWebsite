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
                new ApiScope("chat"),
                new ApiScope("forum")
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
                        "chat",
                        "forum"
                    },
                    
                    AccessTokenLifetime = 60*60*2, // 2 hours
                    IdentityTokenLifetime= 60*60*2 // 2 hours
                },
                new Client
                {
                    ClientId = "react-web",
                    ClientName = "react-web",
                    ClientSecrets =  { new Secret("secret".Sha256()) },
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,

                    RequireConsent = false,
                    RequirePkce = false,

                    RedirectUris =
                    {
                        $"{configuration["Client:React:Uri"]}/api/auth/callback/identity-server4",
                        $"{configuration["Client:React:Uri"]}/auth/login-callback",
                        $"{configuration["Client:React:Uri"]}/silent-renew.html",
                        $"{configuration["Client:React:Uri"]}",
                    },
                    PostLogoutRedirectUris =
                    {
                        $"{configuration["Client:React:Uri"]}/auth/unauthorized",
                        $"{configuration["Client:React:Uri"]}/auth/logout-callback",
                        $"{configuration["Client:React:Uri"]}"
                    },
                    AllowedCorsOrigins =
                    {
                        $"{configuration["Client:React:Uri"]}"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "chat",
                        "forum"
                    }
                },
                new Client
                {
                    ClientId = "postman",
                    ClientSecrets = { new Secret("812dc01e-bd77-4257-bfeb-944ae5f8f1e3".Sha256()) },

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
                        "chat",
                        "forum"
                    },
                    
                    AccessTokenLifetime = 60*60*2, // 2 hours
                    IdentityTokenLifetime= 60*60*2 // 2 hours
                }
            };
    }
}