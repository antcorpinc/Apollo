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
    public class CustomRoleRepository : ICustomRoleRepository, IDisposable
    {
        private ApolloContext _context;
        public CustomRoleRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<SocietyRoleListItem>> GetRolesInSocietyAsync(Guid societyId)
        {
            return await _context.SocietyRole.Where(sr => sr.SocietyId == societyId )
                           .Select(SocietyRoleListItem.Projection).ToListAsync();
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
