﻿using Apollo.Domain.DTO;
using Apollo.Service.UserManagement.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.UserManagement.Controllers
{
    [Route("api/societyuser")]
    public class SocietyUserController: BaseUserController
    {
        private readonly ISocietyUserService _userService;
        private readonly IMapper _mapper;
        public SocietyUserController(ISocietyUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost()]
        public  IActionResult Create([FromBody]SocietyUserCreate user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            // Todo: Check if there is already active user in the Soc/Build/Flat
            // Todo : Change thiis later - Use some logic like Ew

            var password = string.IsNullOrEmpty(user.Password) ? "DDdd@1234" : user.Password;
            user.Password = password;
            return Ok(this._userService.CreateUserAsync(user));
        }
    }
}
