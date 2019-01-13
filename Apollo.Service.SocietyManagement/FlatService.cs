using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO.Society;
using Apollo.Service.SocietyManagement.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
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
        public Task<ServiceResponse<Flat>> CreateFlat(Guid societyId, Guid buildingId, FlatCreate flat)
        {
            throw new NotImplementedException();
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
