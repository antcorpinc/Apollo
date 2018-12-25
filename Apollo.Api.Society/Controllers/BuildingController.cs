using Apollo.Service.SocietyManagement.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.Society.Controllers
{
    [Route("api/societies/{societyId}/buildings")]
    public class BuildingController: BaseSocietyController
    {
        private readonly ISocietyService _societyService;
        public BuildingController(ISocietyService societyService)
        {
            _societyService = societyService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetBuildingsForSociety(Guid societyId)
        {
            // Check if the society exists
            return null;
        }
    }
}
