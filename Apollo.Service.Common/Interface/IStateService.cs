using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.Common.Interface
{
    public interface IStateService
    {
        List<Apollo.Domain.DTO.MasterData.State> GetAll();
        Task<List<Domain.DTO.MasterData.State>> GetAllAsync();
    }
}
