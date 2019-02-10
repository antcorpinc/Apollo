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
    public class CustomSocietyUserRepository : ICustomSocietyUserRepository, IDisposable
    {
        private ApolloContext _context;
        public CustomSocietyUserRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async  Task<List<SocietyUserListItem>> GetSocietyUsersAsync(Guid societyId)
        {
            return await _context.SocietyUser.Where
                (su => su.SocietyId == societyId).Select(SocietyUserListItem.Projection).ToListAsync();

        }
        public async Task<SocietyUserListItem> GetSocietyUserAsync(Guid userId)
        {
            return await _context.SocietyUser.Where(su => su.UserId == userId).Select(SocietyUserListItem.Projection).FirstOrDefaultAsync();
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
