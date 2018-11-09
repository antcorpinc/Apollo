using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.Common.Interface
{
    public interface IStateService
    {
        List<Apollo.Domain.DTO.MasterData.State> GetAll();        
    }
}
