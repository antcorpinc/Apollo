using Apollo.Domain.ViewModel;
using Apollo.Service.UserManagement.Interface;
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
        public SupportUserController(IUserService userService)
        {
            _userService = userService;
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
        

    }
}
