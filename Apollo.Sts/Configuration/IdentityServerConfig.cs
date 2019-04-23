using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
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
                   new ApiResource
                   {
                       Name="apollo.api.society",
                       DisplayName="Society Api",
                       Scopes = new List<Scope>()
                       {
                           new Scope("apollo.api.society")
                       }
                   },   
                   new ApiResource
                   {
                       Name="apollo.api.backoffice",
                       DisplayName="BackOffice Api",
                       Scopes = new List<Scope>()
                       {
                           new Scope("apollo.api.backoffice")
                       }
                   },                 
                };
        }

        public static X509Certificate2 GetSigningCertificate(string certName, string certPassword)
        {
            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "Certificates", certName);
            var certDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Certificates"));
            var info = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Certificates")).GetFiles();
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Signing Certificate is missing!");
            }
            var cert = new X509Certificate2(fileName, certPassword);
            return cert;
        }
    }   

}
