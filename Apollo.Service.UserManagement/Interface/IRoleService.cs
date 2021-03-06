﻿using Apollo.Core.Common;
using Apollo.Domain.DTO.Society;
using Apollo.Domain.DTO.User;
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

        Task<ServiceResponse<List<ApplicationRoleListItem>>> GetApplicationRolesAsync();

        Task<ServiceResponse<List<ApplicationRoleListItem>>> GetApplicationRolesForSupportUsersAsync();
        Task<ServiceResponse<List<ApplicationRoleListItem>>> GetRolesByApplicationIdAndUserType(Guid applicationId, int userType);
    }
}
