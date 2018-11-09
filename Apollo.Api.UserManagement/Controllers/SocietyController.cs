using Apollo.Service.UserManagement.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.UserManagement.Controllers
{
    [Route("api/society")]
    public class SocietyController: BaseUserController
    {
        private readonly ISocietyService _societyService;

        public SocietyController(ISocietyService societyService)
        {
            _societyService = societyService;
        }

        [HttpGet()]
        public IActionResult GetSocieties()
        {
            return Ok(this._societyService.GetAll());            
        }
    }
}
