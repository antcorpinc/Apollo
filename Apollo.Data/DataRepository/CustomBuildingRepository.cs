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
    public class CustomBuildingRepository : ICustomBuildingRepository, IDisposable
    {
        private ApolloContext _context;
        public CustomBuildingRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<BuildingListItem>> GetBuildingInSocietyAsync(Guid societyId)
        {
            return await _context.Building.Where(b => b.SocietyId == societyId )
                          .OrderBy(f => f.Name).Select(BuildingListItem.Projection).ToListAsync();
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
