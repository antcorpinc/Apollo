using Apollo.Domain.ViewModel;
using Apollo.Service.UserManagement.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.UserManagement.Controllers
{
    [Route("api/supportuser")]
    public class SupportUserController: BaseUserController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public SupportUserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody]SupportUserVm user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            this._userService.CreateSupportUser(user);
            // Todo: Change the below
            return null;
        }
        
        [HttpGet]
       public IActionResult GetSupportUsers()
        {
            // Todo First check that the logged in user is of support user type if yes then only let him call the below
            var supportUserList = this._userService.GetAllUsersBasedOnUserType(Domain.Enum.UserType.SupportUser);
            return Ok(Mapper.Map<IEnumerable<Apollo.Domain.DTO.SupportUserList>>(supportUserList));
            //return Ok(supportUserList);
        }

    }
}
