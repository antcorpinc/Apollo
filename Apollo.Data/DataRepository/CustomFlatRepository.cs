using Apollo.Data.Interface;
using Apollo.Domain.DTO.Society;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.DataRepository
{
    public class CustomFlatRepository : ICustomFlatRepository, IDisposable
    {
        private ApolloContext _context;
        public CustomFlatRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async  Task<List<FlatListItem>> GetFlatsInSocietyBuildingAsync(Guid societyId, Guid buildingId)
        {
            return await _context.Flat.Where(f => f.SocietyId == societyId &&
                                                  f.BuildingId == buildingId)
                           .OrderBy(f => f.Name).Select(FlatListItem.Projection).ToListAsync();
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
