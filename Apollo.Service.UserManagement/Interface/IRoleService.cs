using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.UserManagement.Interface
{
   public  interface IRoleService
    {
        List<ApplicationRole> GetRolesForApplicationAndUserType(Guid applicationId,int? userType= 0);
    }
}
