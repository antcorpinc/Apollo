using Apollo.Domain.DTO.Society;
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

        [HttpGet("{id}", Name = "GetFlatInSocietyBuilding")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid societyId, Guid buildingId, Guid id,
            [FromBody] FlatUpdate flat)
        {
            if (flat == null)
            {
                return BadRequest();
            }
            
            var flatExists = await this._flatService.IsFlatInSocietyBuildingExistsAsync(societyId, buildingId, id);
            if (!flatExists)
            {
                return NotFound();
            }
            flat.UpdatedBy = this.LoggedInUserId;
            flat.UpdatedDate = DateTime.UtcNow;
            var response = await this._flatService.UpdateFlatAsync(societyId, buildingId, id, flat);

            if (response.Successful)
            {
                return NoContent();               
            }
            return BadRequest(response.ErrorMessages);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Guid societyId, Guid buildingId, [FromBody] FlatCreate flat)
        {
            if (flat == null)
            {
                return BadRequest();
            }
            var exists = await this._societyService.IsBuildingExistsAsync(societyId, buildingId);
            if (!exists)
            {
                return NotFound();
            }
            flat.CreatedBy = this.LoggedInUserId;
            flat.CreatedDate = DateTime.UtcNow;
            flat.UpdatedBy = this.LoggedInUserId;
            flat.UpdatedDate = DateTime.UtcNow;
            var response = await this._flatService.CreateFlat(societyId, buildingId, flat);
            if (response.Successful)
            {
                // return Ok(response.Data);
                return CreatedAtRoute("GetFlatInSocietyBuilding",
                new { societyId = societyId, buildingId = buildingId,  id = response.Data.Id },
                response.Data);
            }

            return BadRequest(response.ErrorMessages);
        }
    }

}
