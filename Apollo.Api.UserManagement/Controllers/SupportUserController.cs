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
    public class SupportUserController : BaseUserController
    {
        private readonly ISupportUserService _userService;
        private readonly IMapper _mapper;
        public SupportUserController(ISupportUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody]SupportUser user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            // Todo : Change thiis later - Use some logic like Ew

            var password = string.IsNullOrEmpty(user.Password) ? "DDdd@1234" : user.Password;
            user.Password = password;
            return Ok(this._userService.CreateUser(user));
        }

        [Route("update")]
        [HttpPost]
        public IActionResult Update([FromBody]SupportUser user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(this._userService.UpdateUser(user));
        }

        [HttpGet]
        public async Task<IActionResult> GetSupportUsers()
        {
            // Todo First check that the logged in user is of support user type if yes then only let him call the below
            var supportUserList = await this._userService.GetAllUsersAsync();
            if(supportUserList == null)
            {
                return NotFound();
            }
            // return Ok(Mapper.Map<IEnumerable<Apollo.Domain.DTO.SupportUserList>>(supportUserList));
            return Ok(supportUserList);
        }

        [Route("getbyid")]
        [HttpGet]
        public IActionResult GetById(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }
            var user = this._userService.GetById(userId);
            if (user is null || user.Id == Guid.Empty)
                return NoContent();
            return Ok(Mapper.Map<Apollo.Domain.DTO.SupportUser>(user));
        }

        [HttpGet("{id}")]
        public IActionResult GetSupportUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            var user = this._userService.GetById(id);
            if (user is null || user.Id == Guid.Empty)
                return NoContent();
            return Ok(Mapper.Map<Apollo.Domain.DTO.SupportUser>(user));
        }
    }
}
