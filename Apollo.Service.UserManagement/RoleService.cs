using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO.Society;
using Apollo.Domain.DTO.User;
using Apollo.Domain.Entity;
using Apollo.Domain.Enum;
using Apollo.Service.UserManagement.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private ICustomRoleRepository _customRoleRepository;
        public RoleService(IRoleRepository roleRepository, ICustomRoleRepository customRoleRepository)
        {
            _roleRepository = roleRepository;
            _customRoleRepository = customRoleRepository;
        }

       

        public List<ApplicationRole> GetRolesForApplicationAndUserType(Guid applicationId, int? userType = 0)
        {
            return this._roleRepository.GetRolesForApplicationAndUserType(applicationId, (Domain.Enum.UserType)userType);
        }

        public async Task<ServiceResponse<List<SocietyRoleListItem>>> GetRolesInSocietyAsync(Guid societyId)
        {
            var response = new ServiceResponse<List<SocietyRoleListItem>>();
            var roles = await this._customRoleRepository.GetRolesInSocietyAsync(societyId);
            if (roles == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any results"));
                return response;
            }
            response.Data = roles;
            return response;
        }

        public async Task<ServiceResponse<List<ApplicationRoleListItem>>> GetApplicationRolesAsync()
        {
            var response = new ServiceResponse<List<ApplicationRoleListItem>>();
            var roles = await this._customRoleRepository.GetApplicationRolesAsync();
            if (roles == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any results"));
                return response;
            }
            response.Data = roles;
            return response;
        }

        public async Task<ServiceResponse<List<ApplicationRoleListItem>>> GetApplicationRolesForSupportUsersAsync()
        {
            var response = new ServiceResponse<List<ApplicationRoleListItem>>();
            var roles = await this._customRoleRepository.GetApplicationRolesForSupportUsersAsync();
            if (roles == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any results"));
                return response;
            }
            response.Data = roles;
            return response;
        }
    }
}
