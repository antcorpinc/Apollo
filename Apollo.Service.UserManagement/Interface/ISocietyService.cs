using Apollo.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.UserManagement.Interface
{
    public interface ISocietyService
    {
        List<SocietyList> GetAll();
    }
}
