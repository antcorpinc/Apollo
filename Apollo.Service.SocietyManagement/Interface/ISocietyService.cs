using Apollo.Core.Common;
using Apollo.Domain.DTO;
using Apollo.Domain.DTO.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.SocietyManagement.Interface
{
    public interface ISocietyService
    {
        List<SocietyList> GetAll();
        Task<List<Domain.DTO.SocietyList>> GetAllAsync();
        Task<ServiceResponse<Society>>CreateSociety(Society society);
        Task<ServiceResponse<Society>> UpdateAsync(Society society);
        Task<ServiceResponse<Society>> GetAsync(Guid id);

        Task<bool> IsExistsAsync(Guid id);
    }
}
