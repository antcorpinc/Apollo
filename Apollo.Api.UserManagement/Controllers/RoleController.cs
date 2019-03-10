using Apollo.Domain.DTO.Base;
using Apollo.Service.UserManagement.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.UserManagement.Controllers
{
    [Route("api/role")]
    public class RoleController: BaseUserController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [Route("GetByApplicationId")]
        [HttpGet]
        public IActionResult GetByApplicationId(Guid applicationId, int? userType = 0)
        {
           
                if (applicationId == Guid.Empty)
                    return BadRequest();

                var roles = this._roleService.GetRolesForApplicationAndUserType(applicationId, userType);
                

                if (roles is null || roles.Count == 0)
                    return NoContent();

                return Ok(Mapper.Map<IEnumerable<Role>>(roles));
           
         
        }

        [Route("getrolesinsociety")]
        [HttpGet]
        public async Task<IActionResult> GetRolesInSociety(Guid societyId)
        {
            if (societyId == Guid.Empty)
                return BadRequest();
            var response = await this._roleService.GetRolesInSocietyAsync(societyId);
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }

        [Route("getapplicationroles")]
        [HttpGet]
        public async Task<IActionResult> GetApplicationRoles()
        {           
            var response = await this._roleService.GetApplicationRolesAsync();
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }

        [Route("getapplicationrolesforsupportusers")]
        [HttpGet]
        public async Task<IActionResult> GetApplicationRolesForSupportUsers()
        {
            var response = await this._roleService.GetApplicationRolesForSupportUsersAsync();
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }

        [Route("getrolesbyapplicationidandusertype")]
        [HttpGet]
        public async Task<IActionResult> GetRolesByApplicationIdAndUserType(Guid applicationId, int UserType = 0)
        {
            return Ok();
        }
    }
}
