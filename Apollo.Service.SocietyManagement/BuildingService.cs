﻿using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO.Society;
using Apollo.Service.SocietyManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.SocietyManagement
{
    public class BuildingService : IBuildingService
    {
        private IBuildingRepository _buildingRepository;
        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository ??
                throw new ArgumentNullException(nameof(buildingRepository)); ;
        }
        public async Task<ServiceResponse<Building>> CreateBuilding(Guid societyId, BuildingCreate buildingCreate)
        {
            var validator = new BuildingCreateValidator();
            var results = validator.Validate(buildingCreate);
            var response = new ServiceResponse<Building>();
            response.ErrorMessages = results.Errors.ToList();
            // response.Data = new Building();
            if (!response.Successful)
            {
                return response;
            }
            var building = AutoMapper.Mapper.Map<Apollo.Domain.Entity.Society.Building>(buildingCreate);
            building.Id = Guid.NewGuid();
            building.SocietyId = societyId;
            var result = await this._buildingRepository.AddAsync(building);
            response.Data = AutoMapper.Mapper.Map<Apollo.Domain.DTO.Society.Building>(result);
            return response;
        }
    }
}