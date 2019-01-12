using Apollo.Data.Interface;
using Apollo.Domain.DTO.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Apollo.Data.DataRepository
{
    // INfo : The Custom Repository are basically used for SELECT queries to execute specific select using
    // projections
    // https://benjii.me/2018/01/expression-projection-magic-entity-framework-core/
    public class CustomSocietyRepository : ICustomSocietyRepository, IDisposable
    {
        private ApolloContext _context;
        public CustomSocietyRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<SocietyListItem>> GetSocietiesWithCustomSearchAsync(string customSearch)
        {
           return await _context.Society
                            .Where(soc => soc.Name.StartsWith(customSearch,true,null))
                            .Select(SocietyListItem.Projection).ToListAsync();
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
