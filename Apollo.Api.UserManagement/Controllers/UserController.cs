using Apollo.Service.UserManagement.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;


        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;


        }

        [HttpGet("{id:Guid}",Name = "GetUserDetails")]
        public IActionResult GetUserDetails(Guid id)
        {
            var userDetails = this._userService.GetUserDetails(id);
            _logger.LogInformation("SubJectId :" + this.LoggedInUserId);
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
