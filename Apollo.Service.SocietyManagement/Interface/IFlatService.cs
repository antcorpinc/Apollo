using Apollo.Core.Common;
using Apollo.Domain.DTO.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.SocietyManagement.Interface
{
   public  interface IFlatService
    {
        Task<ServiceResponse<Flat>> CreateFlat(Guid societyId,Guid buildingId, FlatCreate flat);

        Task<ServiceResponse<List<FlatListItem>>> GetFlatsInSocietyBuildingAsync(Guid societyId, Guid buildingId);
    }
}
