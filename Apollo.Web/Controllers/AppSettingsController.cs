using Apollo.Web.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Web.Controllers
{
    public class AppSettingsController: Controller
    {
        AppSettings _appSettings;
        public AppSettingsController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings?.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Json(_appSettings);
        }
    }
}
