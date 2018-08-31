using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Web.Settings
{
    public class AppSettings
    {
         public BaserUrls BaserUrls { get; set; }        
    }
    public class BaserUrls {
        public string UserMgmtApi {get; set;}		
    }
}
