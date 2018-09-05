using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Apollo.Sts.Configuration
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),                
            };
        }        

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
                {                   

                   new ApiResource
                   {
                       Name="apollo.api.usermanagement",
                       DisplayName="User Management Api",
                       Scopes = new List<Scope>()
                       {
                           new Scope("apollo.api.usermanagement")
                       }
                   },                    
                };
        }
    }   

}
