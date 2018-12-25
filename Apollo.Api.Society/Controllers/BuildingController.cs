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
            var exists = await this._societyService.IsExistsAsync(societyId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await this._societyService.GetBuildingsInSocietyAsync(societyId);
            if(response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildingForSociety(Guid societyId, Guid id)
        {
            var exists = await this._societyService.IsExistsAsync(societyId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await this._societyService.GetBuildingInSocietyAsync(societyId, id);
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }
    }
}
