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
    public class CustomApplicationRepository : ICustomApplicationRepository , IDisposable
    {
        private ApolloContext _context;
        public CustomApplicationRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ApplicationListItem> GetApplicationDetails(string applicationName)
        {
            return await _context.Application.Where(b => b.Name.ToUpper() == applicationName.ToUpper())
                          .OrderBy(f => f.Name).Select(ApplicationListItem.Projection).SingleOrDefaultAsync();
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
