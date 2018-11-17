
using Apollo.Service.SocietyManagement.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.Society.Controllers
{
    [Route("api/society")]
    public class SocietyController: BaseSocietyController
    {
        private readonly ISocietyService _societyService;

        public SocietyController(ISocietyService societyService)
        {
            _societyService = societyService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetSocieties()
        {
            var societies = await this._societyService.GetAllAsync();
            if(societies == null)
            {
                return NotFound();
            }
            return Ok(societies);            
        }
    }
}
