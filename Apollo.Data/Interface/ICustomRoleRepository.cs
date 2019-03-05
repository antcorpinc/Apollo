using Apollo.Domain.DTO.Society;
using Apollo.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    public interface ICustomRoleRepository
    {
        Task<List<SocietyRoleListItem>> GetRolesInSocietyAsync(Guid societyId);
        Task<List<ApplicationRoleListItem>> GetApplicationRolesAsync();
        Task<List<ApplicationRoleListItem>> GetApplicationRolesForSupportUsersAsync();
    }
}
