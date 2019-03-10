using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO.User;
using Apollo.Service.UserManagement.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement
{
    public class FeatureService : IFeatureService
    {
        private ICustomFeatureRepository _customFeatureRepository;
        public FeatureService(ICustomFeatureRepository customFeatureRepository)
        {
            _customFeatureRepository = customFeatureRepository;
        }
        public async Task<ServiceResponse<List<FeatureListItem>>> GetFeaturesInApplicationAsync(Guid applicationId)
        {
            var response = new ServiceResponse<List<FeatureListItem>>();
            var features = await this._customFeatureRepository.GetFeaturesInApplicationAsync(applicationId);
            if (features == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any results"));
                return response;
            }
            
            features = GenerateTree(features);
            response.Data = features;
            return response;
        }

        private List<FeatureListItem> GenerateTree(List<FeatureListItem> collection)
        {
            if (collection.Count() != 0)
            {
                var lookup = collection.ToDictionary(g => g.Id);
                foreach (var item in collection.Where(g => g.ParentFeatureId != null))
                {
                    var index = 0;
                    if (lookup[item.ParentFeatureId.Value].SubFeature.Count <= item.Order.Value - 1)
                        index = lookup[item.ParentFeatureId.Value].SubFeature.Count;
                    else
                    {
                        index = item.Order.Value - 1;
                    }
                    lookup[item.ParentFeatureId.Value].SubFeature.Insert(index, item);
                }
                return lookup.Where(g => g.Value.ParentFeatureId == null)
                        .OrderBy(g => g.Value.Order).Select(g => g.Value).ToList();
            }
            return collection;
        }
    }
}
