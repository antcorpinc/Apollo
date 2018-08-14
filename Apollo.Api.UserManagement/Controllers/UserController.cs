using Apollo.Service.UserManagement.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.UserManagement.Controllers
{
    [Route("api/user")]
    public class UserController: BaseUserController
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:Guid}",Name = "GetUserDetails")]
        public IActionResult GetUserDetails(Guid id)
        {
            var userDetails = this._userService.GetUserDetails(id);
            return Ok(userDetails);
           
        }

        [Route("GetByEmailId")]
        [HttpGet]
        public IActionResult GetByEmailId(string emailId)
        {
            // Todo : 
            return null;

        }

        [HttpGet()]
        public IActionResult GetUsers()
        {
            // Todo : Get ALl Users
            return null;
        }

       

    }
}
