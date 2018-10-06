using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Web.Settings
{
    public class AppSettings
    {
         public BaseUrls BaseUrls { get; set; }
         public IdentityClient IdentityClient {get;set;}
    }
    public class BaseUrls {
        public string Sts {get;set;}
        public string Web {get;set;}
        public string UserMgmtApi {get; set;}
    }

    public class IdentityClient {
        public string ClientId {get;set;}
        public string ClientSecret {get;set;}
    }
}
