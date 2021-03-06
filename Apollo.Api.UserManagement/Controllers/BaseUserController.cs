﻿using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.UserManagement.Controllers
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public abstract  class BaseUserController: ControllerBase
    {

        protected string LoggedInUserId
        {
            get
            {
                string loggedInUserId = string.Empty;
                if (HttpContext != null && HttpContext.User != null && HttpContext.User.Claims != null)
                {
                    var user = HttpContext.User.Claims.Where(a => a.Type == "sub");
                    if (user != null)
                    {
                        var userName = user.FirstOrDefault();
                        if (userName != null)
                        {
                            loggedInUserId = userName.Value;
                        }
                    }
                }
                return loggedInUserId;
            }

        }
    }
}
