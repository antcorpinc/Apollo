using System;
using System.Threading.Tasks;
using Apollo.Service.Common.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Apollo.Api.BackOffice.Controllers
{
    [Route("api/state")]
    public class StateController:  BaseBackOfficeController
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }       

        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            var states = await this._stateService.GetAllAsync();
            if(states == null)
            {
                return NotFound();
            }
            return Ok(states);
        }
    }
}
