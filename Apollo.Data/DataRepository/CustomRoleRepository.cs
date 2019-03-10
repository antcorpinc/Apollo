using Apollo.Data.Interface;
using Apollo.Domain.DTO.Society;
using Apollo.Domain.DTO.User;
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

        public async Task<List<ApplicationRoleListItem>> GetApplicationRolesAsync()
        {
            return await _context.ApplicationRole.Select(ApplicationRoleListItem.Projection).ToListAsync();
        }

        public async Task<List<ApplicationRoleListItem>> GetApplicationRolesForSupportUsersAsync()
        {
            //  return await _context.ApplicationRole.Where(ar  => ar.Role.UserTypeId==1).Select(ApplicationRoleListItem.Projection).ToListAsync();
            return await _context.ApplicationRole.Where(ar => 
            ar.Role.UserTypeId == (int)Domain.Enum.UserType.SupportUser)
            .Select(ApplicationRoleListItem.Projection).ToListAsync();

        }

        public async  Task<List<ApplicationRoleListItem>> GetRolesByApplicationIdAndUserType(Guid applicationId, 
            int userType)
        {
            return await _context.ApplicationRole.Where(ar =>
            ar.ApplicationId == applicationId && ar.Role.UserTypeId == userType)
            .Select(ApplicationRoleListItem.Projection).ToListAsync();
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
