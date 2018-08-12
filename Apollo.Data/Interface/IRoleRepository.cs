using Apollo.Core.Interface;
using Apollo.Domain.DTO;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Data.Interface
{
    public interface IRoleRepository : IRepository<ApolloRole, Guid>
    {
        List<RolePrivilege> GetRelatedPrivilegesForRoleAndApp(Guid roleId, Guid appId);
        List<RolePrivilege> GetRelatedPrivilegesForRoleAppAndSociety(Guid roleId, Guid appId, Guid? societyId);
    }
}
