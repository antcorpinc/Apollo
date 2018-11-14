
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
        
        private Client GetApolloWebClient()
        {
            return new Client
            {
                ClientId = "apollo.web",
                ClientName = "Apollo Web Application",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,
                RedirectUris= { 
                    $"{_appSettings.BaseUrls.Web}assets/oidc-login-redirect.html" ,
                    $"{_appSettings.BaseUrls.Web}assets/silent-redirect.html"
                    },
                PostLogoutRedirectUris= { $"{_appSettings.BaseUrls.Web}?postLogout=true" },
                AllowedCorsOrigins = { $"{_appSettings.BaseUrls.Web}" },
                AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apollo.api.usermanagement",
                        "apollo.api.society",
                        "apollo.api.backoffice"
                    }, 
                    //IdentityTokenLifetime = 120,
                    //AccessTokenLifetime = 120                   
            };
        }      
    }
}