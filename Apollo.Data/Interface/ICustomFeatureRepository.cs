using Apollo.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    public interface ICustomFeatureRepository
    {
        Task<List<FeatureListItem>> GetFeaturesInApplicationAsync(Guid applicationId);
    }
}
