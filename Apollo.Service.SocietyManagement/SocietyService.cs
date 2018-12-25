﻿using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Service.SocietyManagement.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Apollo.Service.SocietyManagement.Mappers;
using Apollo.Core.Common;
using Apollo.Domain.DTO.Society;
using FluentValidation.Results;

namespace Apollo.Service.SocietyManagement
{
    public class SocietyService : ISocietyService
    {
        private ISocietyRepository _societyRepository;
        public SocietyService(ISocietyRepository societyRepository)
        {
            _societyRepository = societyRepository ??
                throw new ArgumentNullException(nameof(societyRepository)); ;
        }

        public async Task<ServiceResponse<Society>> CreateSociety(Society society)
        {
            var validator = new SocietyValidator();
            var results = validator.Validate(society);
            var response = new ServiceResponse<Society>();
            response.Data = society;
            response.ErrorMessages = results.Errors.ToList();
            if (!response.Successful)
            {
                return response;
            }
            var result = await this._societyRepository.AddAsync
                (AutoMapper.Mapper.Map<Apollo.Domain.Entity.Society.Society>(society));
            return response;
        }   

        public List<SocietyList> GetAll()
        {
            var societies =  this._societyRepository.GetAll();
            if(societies != null && societies.Count() > 0)
            {
                return AutoMapper.Mapper.Map<IEnumerable<SocietyList>>(societies).ToList();
            }
            else
            {
                return null;
            }            
        }
        public async Task<List<SocietyList>> GetAllAsync()
        {
            var societies = await this._societyRepository.GetAllAsync();
            return SocietyMapper.MapToSocietyList(societies);
        }

        public async Task<ServiceResponse<Society>> GetAsync(Guid id)
        {
            var response = new ServiceResponse<Society>();
            var society = await this._societyRepository.GetAsync(id);
            if(society == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("","Search did not yield any society"));
                return response;
            }
            Domain.DTO.Society.Society societyDto = AutoMapper.Mapper.Map<Society>(society);
            response.Data = societyDto;
            return response;
        }

        public async Task<ServiceResponse<List<Building>>> GetBuildingsInSocietyAsync(Guid societyId)
        {
            var response = new ServiceResponse<List<Building>>();
            var buildings = await this._societyRepository.GetBuildingsInSocietyAsync(societyId);
            if (buildings == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any buildings"));
                return response;
            }
            List<Building> buildigsDto = AutoMapper.Mapper.Map<List<Building>>(buildings);
            response.Data = buildigsDto;
            return response;
        }

        public async Task<ServiceResponse<Building>> GetBuildingInSocietyAsync(Guid societyId, Guid buildingId)
        {
            var response = new ServiceResponse<Building>();
            var building = await this._societyRepository.GetBuildingInSocietyAsync(societyId, buildingId);
            if (building == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any buildings"));
                return response;
            }
            Building buildingDto = AutoMapper.Mapper.Map<Building>(building);
            response.Data = buildingDto;
            return response;
        }

        public Task<List<Flat>> GetFlatsInSocietyBuildingAsync(Guid societyId, Guid buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            return await this._societyRepository.IsExistsAsync(id);
        }

        public async Task<ServiceResponse<Society>> UpdateAsync(Society society)
        {
            var validator = new SocietyUpdateValidator();
            var results = validator.Validate(society);
            var response = new ServiceResponse<Society>();
            
            response.ErrorMessages = results.Errors.ToList();
            if (!response.Successful)
            {
                return response;
            }
            var result = await this._societyRepository.UpdateAsync
                (AutoMapper.Mapper.Map<Apollo.Domain.Entity.Society.Society>(society));
            
            return response;
        }
    }
}
