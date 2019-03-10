using Apollo.Data.Interface;
using Apollo.Domain.DTO.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.DataRepository
{
    public class CustomFeatureRepository: ICustomFeatureRepository, IDisposable
    {
        private ApolloContext _context;
        public CustomFeatureRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<FeatureListItem>> GetFeaturesInApplicationAsync(Guid applicationId)
        {
            List<FeatureListItem> featureList = new List<FeatureListItem>();
            var innerQuery = _context.ApplicationFeature.
                Where(af => af.ApplicationId == applicationId && af.IsActive).
                Select(af => af.FeatureId);
            if (innerQuery.Count() != 0)
            {
                return await _context.Feature.Where(f => innerQuery.Contains(f.Id)).
                    Select(FeatureListItem.Projection).ToListAsync();
            }
            return featureList;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
