using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apollo.Service.UserManagement.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apollo.Api.UserManagement.Controllers
{
    [Route("api/application")]
    public class ApplicationController: BaseUserController
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetApplications()
        {
            // Todo First check that the logged in user is of support user type if yes then only let him call the below
            var appListList = this._applicationService.GetApplications();
            return Ok(Mapper.Map<IEnumerable<Apollo.Domain.DTO.Application>>(appListList));

        }
    }
}
