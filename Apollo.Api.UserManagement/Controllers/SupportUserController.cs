using Apollo.Domain.DTO;
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
        private readonly ISupportUserService _userService;
        private readonly IMapper _mapper;
        public SupportUserController(ISupportUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
         public IActionResult Create([FromBody]SupportUser user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            // Todo : Change thiis later - Use some logic like Ew

            var password = string.IsNullOrEmpty(user.Password) ? "DDdd@1234": user.Password;
            user.Password = password;
            return Ok(this._userService.CreateUser(user));
        }
        
        [HttpGet]
       public IActionResult GetSupportUsers()
        {
            // Todo First check that the logged in user is of support user type if yes then only let him call the below
            var supportUserList = this._userService.GetAllUsers();
            return Ok(Mapper.Map<IEnumerable<Apollo.Domain.DTO.SupportUserList>>(supportUserList));
            
        }

    }
}
