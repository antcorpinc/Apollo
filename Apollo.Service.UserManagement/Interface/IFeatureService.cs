using Apollo.Core.Common;
using Apollo.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement.Interface
{
    public interface IFeatureService
    {
        Task<ServiceResponse<List<FeatureListItem>>> GetFeaturesInApplicationAsync(Guid applicationId);
    }
}
