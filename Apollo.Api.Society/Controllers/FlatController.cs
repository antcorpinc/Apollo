using Apollo.Service.SocietyManagement.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.Society.Controllers
{
    [Route("api/societies/{societyId}/buildings/{buildingId}/flats")]
    public class FlatController: BaseSocietyController
    {
        private readonly ISocietyService _societyService;
        private readonly IFlatService _flatService;

        public FlatController(ISocietyService societyService, IFlatService flatService)
        {
            _societyService = societyService;
            _flatService = flatService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetFlatsInSocietyBuilding(Guid societyId, Guid buildingId)
        {
            var exists = await this._societyService.IsBuildingExistsAsync(societyId, buildingId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await this._flatService.GetFlatsInSocietyBuildingAsync(societyId, buildingId);
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlatInSocietyBuilding(Guid societyId, Guid buildingId, Guid id)
        {
            var exists = await this._societyService.IsBuildingExistsAsync(societyId, buildingId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await this._societyService.GetFlatInSocietyBuildingAsync(societyId, buildingId, id);
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }
    }

}
