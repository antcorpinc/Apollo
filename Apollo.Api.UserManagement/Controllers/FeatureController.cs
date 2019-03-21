using Apollo.Service.UserManagement.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.UserManagement.Controllers
{
    [Route("api/features")]
    public class FeatureController : BaseUserController
    {
        private readonly IFeatureService _featureService;
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("getfeaturesinapplication")]
        [HttpGet]
        public async Task<IActionResult> GetFeaturesInApplication(Guid applicationId)
        {
            var response = await this._featureService.GetFeaturesInApplicationAsync
                (applicationId);
            if (response.Successful)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.ErrorMessages);
        }
    }
}
