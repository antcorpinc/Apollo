﻿using Apollo.Domain.DTO.Society;
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
        private readonly IBuildingService _buildingService;
        public BuildingController(ISocietyService societyService, IBuildingService buildingService)
        {
            _societyService = societyService;
            _buildingService = buildingService;
        }
        //[HttpGet()]
        //public async Task<IActionResult> GetBuildingsForSociety(Guid societyId)
        //{
        //    var exists = await this._societyService.IsExistsAsync(societyId);
        //    if (!exists)
        //    {
        //        return NotFound();
        //    }
        //    var response = await this._societyService.GetBuildingsInSocietyAsync(societyId);
        //    if(response.Successful)
        //    {
        //        return Ok(response.Data);
        //    }
        //    return BadRequest(response.ErrorMessages);            
        //}
        [HttpGet()]
        public async Task<IActionResult> GetBuildingsInSociety(Guid societyId)
        {
            var exists = await this._societyService.IsExistsAsync(societyId);
            if (!exists)
            {
                return NotFound();
            }
            var response = await this._buildingService.GetBuildingsInSocietyAsync(societyId);
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Guid societyId, [FromBody] BuildingCreate building)
        {
            if(building == null) 
            {
                return  BadRequest();
            }
            var exists = await this._societyService.IsExistsAsync(societyId);
            if (!exists)
            {
                return NotFound();
            }
            building.CreatedBy = this.LoggedInUserId;
            building.CreatedDate = DateTime.UtcNow;
            building.UpdatedBy = this.LoggedInUserId;
            building.UpdatedDate = DateTime.UtcNow;
            var response = await this._buildingService.CreateBuilding(societyId, building);
            if(response.Successful)
            {
               // return Ok(response.Data);
               return CreatedAtRoute("GetBuildingForSociety",
               new {societyId= societyId, id= response.Data.Id},
               response.Data );
            }

            return BadRequest(response.ErrorMessages);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid societyId,Guid id,
            [FromBody] BuildingUpdate building)
        {
            if (building == null)
            {
                return BadRequest();
            }
            var societyExists = await this._societyService.IsExistsAsync(societyId);
            if (!societyExists)
            {
                return NotFound();
            }
            var buildingExists = await this._buildingService.IsBuildingInSocietyExistsAsync(societyId, id);
            if (!buildingExists)
            {
                return NotFound();
            }
            building.UpdatedBy = this.LoggedInUserId;
            building.UpdatedDate = DateTime.UtcNow;
            var response = await this._buildingService.UpdateAsync(societyId, id, building);

            if(response.Successful)
            {
                return NoContent();
               // return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }


        [HttpGet("{id}", Name="GetBuildingForSociety")]
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
