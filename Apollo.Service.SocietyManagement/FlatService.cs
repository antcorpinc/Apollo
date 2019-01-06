using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO.Society;
using Apollo.Service.SocietyManagement.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.SocietyManagement
{
    public class FlatService : IFlatService
    {
        private IFlatRepository _flatRepository;
        public FlatService(IFlatRepository flatRepository)
        {
            _flatRepository = flatRepository ??
                throw new ArgumentNullException(nameof(flatRepository));
        }
        public Task<ServiceResponse<Flat>> CreateFlat(Guid societyId, Guid buildingId, FlatCreate flat)
        {
            throw new NotImplementedException();
        }
    }
}
