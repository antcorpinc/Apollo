using Apollo.Domain.DTO;
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
    }
}
