﻿using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace cat0logic.IdentityServer
{
    public static class Config
    {
        public static readonly IEnumerable<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static readonly IEnumerable<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource("movie_api", "Movie Review Service")
            {
                UserClaims = { "role" }
            }
        };

        public static readonly IEnumerable<Client> Clients = new List<Client>
        {
            new Client
            {
                ClientId = "movie_client",
                ClientName = "Movie Review App",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                ClientSecrets = 
                {
                    new Secret("secret".Sha256())
                },
                RedirectUris = 
                {
                    "http://localhost:32361/signin-oidc"
                },

                PostLogoutRedirectUris = 
                {
                    "http://localhost:32361/signout-callback-oidc"
                },

                AllowedScopes = 
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "movie_api"
                }
            }
        };

        public static readonly List<TestUser> Users = new List<TestUser>()
        {
            new TestUser {SubjectId="user1", Username="user1", Password = "user1",
                Claims =
                {
                    new Claim("name", "User One"),
                    new Claim("email", "User1@gmail.com"),
                    new Claim("role", "Reviewer"),
                }
            },
            new TestUser {SubjectId="user2", Username="user2", Password = "user2",
                Claims =
                {
                    new Claim("name", "User Two"),
                    new Claim("email", "User2@yahoo.com"),
                    new Claim("role", "Reviewer"),
                }
            },
            new TestUser {SubjectId="user3", Username="user3", Password = "user3",
                Claims =
                {
                    new Claim("name", "User Three"),
                    new Claim("email", "User3@outlook.com"),
                    new Claim("role", "Reviewer"),
                }
            },
            new TestUser {SubjectId="user4", Username="user4", Password = "user4",
                Claims =
                {
                    new Claim("name", "User Four"),
                    new Claim("email", "User4@gmail.com"),
                    new Claim("role", "Customer"),
                }
            },
            new TestUser {SubjectId="user5", Username="user5", Password = "user5",
                Claims =
                {
                    new Claim("name", "User Five"),
                    new Claim("email", "User5@admin.com"),
                    new Claim("role", "Admin"),
                }
            },
        };
    }
}
