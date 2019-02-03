using Apollo.Domain.DTO.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    public interface ICustomRoleRepository
    {
        Task<List<SocietyRoleListItem>> GetRolesInSocietyAsync(Guid societyId);
    }
}
