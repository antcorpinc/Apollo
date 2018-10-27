using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using Apollo.Domain.Enum;
using Apollo.Service.UserManagement.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.UserManagement
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<ApplicationRole> GetRolesForApplicationAndUserType(Guid applicationId, int? userType = 0)
        {
            return this._roleRepository.GetRolesForApplicationAndUserType(applicationId, (Domain.Enum.UserType)userType);
        }      
    }
}
