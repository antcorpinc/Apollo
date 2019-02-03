using Apollo.Core.Common;
using Apollo.Domain.DTO.Society;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement.Interface
{
   public  interface IRoleService
    {
        List<ApplicationRole> GetRolesForApplicationAndUserType(Guid applicationId,int? userType= 0);

        Task<ServiceResponse<List<SocietyRoleListItem>>> GetRolesInSocietyAsync(Guid societyId);
    }
}
