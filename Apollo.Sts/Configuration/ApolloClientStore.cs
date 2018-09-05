
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Apollo.Sts.Settings;
using Microsoft.Extensions.Options;

namespace Apollo.Sts.Configuration
{

    public class ApolloClientStore : IClientStore
    {
        private readonly AppSettings _appSettings;
        public ApolloClientStore(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public  Task<Client> FindClientByIdAsync(string clientId)
        {
            if(clientId == "apollo.web")
            {
                return Task.FromResult(GetApolloWebClient());
            }        
            // Add Other Clients as needed
            return null;
        }
        // Todo: Need to change this Implicit grant type -- Brian Noyes
        private Client GetApolloWebClient()
        {
            return new Client
            {
                ClientId = "apollo.web",
                ClientName = "Apollo Web Application",
                AllowedGrantTypes = GrantTypes.Hybrid,
                ClientSecrets = {new Secret("02F97D49-18F8-4E20-AD8D-0EA51F3450A0".Sha256())},
                RedirectUris= { $"{_appSettings.BaseUrls.Web}signin-oidc" },
                FrontChannelLogoutUri = $"{_appSettings.BaseUrls.Web}signout-oidc",
                PostLogoutRedirectUris= new List<string>{$"{_appSettings.BaseUrls.Web}signout-callback-oidc" },
                 
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apollo.api.usermanagement",
                    },
                    AllowOfflineAccess = true,
                    RequireConsent=false,
                    AlwaysIncludeUserClaimsInIdToken=true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = 157700000  // 5 years
            };
        }      
    }
}