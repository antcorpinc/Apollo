using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Apollo.Core.Common;
using Apollo.Domain.DTO.Society;
namespace Apollo.Service.SocietyManagement.Interface
{
    public interface IBuildingService
    {
        Task<ServiceResponse<Building>> CreateBuilding(Guid societyId,BuildingCreate society);
    }
}
