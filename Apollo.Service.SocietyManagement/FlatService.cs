using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO.Society;
using Apollo.Service.SocietyManagement.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.SocietyManagement
{
    public class FlatService : IFlatService
    {
        private IFlatRepository _flatRepository;
        private ICustomFlatRepository _customFlatRepository;
        public FlatService(IFlatRepository flatRepository , ICustomFlatRepository customFlatRepository)
        {
            _flatRepository = flatRepository ??
                throw new ArgumentNullException(nameof(flatRepository));

            _customFlatRepository = customFlatRepository ??
                throw new ArgumentNullException(nameof(customFlatRepository));

        }
        public async Task<ServiceResponse<Flat>> CreateFlat(Guid societyId, Guid buildingId, FlatCreate flat)
        {

            var validator = new FlatCreateValidator();
            var results = validator.Validate(flat);
            var response = new ServiceResponse<Flat>();
            response.ErrorMessages = results.Errors.ToList();
            if (!response.Successful)
            {
                return response;
            }
            var flatEntity = AutoMapper.Mapper.Map<Apollo.Domain.Entity.Society.Flat>(flat);
            flatEntity.Id = Guid.NewGuid();
            flatEntity.SocietyId = societyId;
            flatEntity.BuildingId = buildingId;
            var result = await this._flatRepository.AddAsync(flatEntity);
            response.Data = AutoMapper.Mapper.Map<Apollo.Domain.DTO.Society.Flat>(result);
            return response;           
        }

        public async Task<ServiceResponse<List<FlatListItem>>> GetFlatsInSocietyBuildingAsync(Guid societyId, Guid buildingId)
        {
            var response = new ServiceResponse<List<FlatListItem>>();
            var flats = await this._customFlatRepository.GetFlatsInSocietyBuildingAsync(societyId, buildingId);
            if (flats == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any results"));
                return response;
            }
            response.Data = flats;
            return response;
        }
    }
}
