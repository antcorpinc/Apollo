using Apollo.Data.Interface;
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
        private ICustomSocietyRepository _customSocietyRepository;
        public SocietyService(ISocietyRepository societyRepository, 
            ICustomSocietyRepository customSocietyRepository)
        {
            _societyRepository = societyRepository ??
                throw new ArgumentNullException(nameof(societyRepository));

            _customSocietyRepository = customSocietyRepository ??
                throw new ArgumentNullException(nameof(customSocietyRepository));

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

        //public async Task<ServiceResponse<List<Building>>> GetBuildingsInSocietyAsync(Guid societyId)
        //{
        //    var response = new ServiceResponse<List<Building>>();
        //    var buildings = await this._societyRepository.GetBuildingsInSocietyAsync(societyId);
        //    if (buildings == null)
        //    {
        //        response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any buildings"));
        //        return response;
        //    }
        //    List<Building> buildigsDto = AutoMapper.Mapper.Map<List<Building>>(buildings);
        //    response.Data = buildigsDto;
        //    return response;
        //}

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

        public async Task<ServiceResponse<List<Flat>>> GetFlatsInSocietyBuildingAsync(Guid societyId, Guid buildingId)
        {
            var response = new ServiceResponse<List<Flat>>();
            var flats = await this._societyRepository.
                GetFlatsInSocietyBuildingAsync(societyId, buildingId);
            if (flats == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any flats"));
                return response;
            }
            List<Flat> flatsDto = AutoMapper.Mapper.Map<List<Flat>>(flats);
            response.Data = flatsDto;
            return response;
        }
        public async Task<ServiceResponse<Flat>> GetFlatInSocietyBuildingAsync(Guid societyId,
            Guid buildingId, Guid flatId)
        {
            var response = new ServiceResponse<Flat>();
            var flat = await this._societyRepository.GetFlatInSocietyBuildingAsync
                (societyId, buildingId,flatId);
            if (flat == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any flat"));
                return response;
            }
            Flat flatDto = AutoMapper.Mapper.Map<Flat>(flat);
            response.Data = flatDto;
            return response;
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            return await this._societyRepository.IsExistsAsync(id);
        }
        public async Task<bool> IsBuildingExistsAsync(Guid societyId, Guid buildingId)
        {
            return await this._societyRepository.IsBuildingExistsAsync(societyId, buildingId);
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

        public async Task<ServiceResponse<List<SocietyListItem>>> GetSocietiesWithCustomSearchAsync(string customSearch)
        {
            var response = new ServiceResponse<List<SocietyListItem>>();
            if(String.IsNullOrEmpty(customSearch))
            {
                response.ErrorMessages.Add(new ValidationFailure("", "No Search Criteria provided "));
                return response;
            }
            var societies = await this._customSocietyRepository.GetSocietiesWithCustomSearchAsync(customSearch);
            if(societies ==null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any results"));
                return response;
            }
            response.Data = societies;
            return response;
        }
    }
}
