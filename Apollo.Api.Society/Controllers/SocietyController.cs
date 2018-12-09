
using Apollo.Service.SocietyManagement.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.Society.Controllers
{
    [Route("api/society")]
    public class SocietyController: BaseSocietyController
    {
        private readonly ISocietyService _societyService;

        public SocietyController(ISocietyService societyService)
        {
            _societyService = societyService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetSocieties()
        {
            var societies = await this._societyService.GetAllAsync();
            if(societies == null)
            {
                return NotFound();
            }
            return Ok(societies);            
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Domain.DTO.Society.Society society)
        {
            if (society == null)
            {
                return BadRequest();
            }
            society.CreatedBy = this.LoggedInUserId;
            society.CreatedDate =  DateTime.UtcNow;
            society.UpdatedBy = this.LoggedInUserId;
            society.UpdatedDate =  DateTime.UtcNow;
            society.Id = Guid.NewGuid();
            var response = await this._societyService.CreateSociety(society);
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
           // return Ok(this._societyService.CreateSociety(society));
        }
    }
}
