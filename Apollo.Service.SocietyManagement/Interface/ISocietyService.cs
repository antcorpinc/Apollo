using Apollo.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.SocietyManagement.Interface
{
    public interface ISocietyService
    {
        List<SocietyList> GetAll();
    }
}
