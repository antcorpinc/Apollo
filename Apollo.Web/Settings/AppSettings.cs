using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Web.Settings
{
    public class AppSettings
    {
         public BaseUrls BaseUrls { get; set; }        
    }
    public class BaseUrls {
        public string UserMgmtApi {get; set;}		
    }
}
