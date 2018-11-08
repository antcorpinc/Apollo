using Apollo.Core.Interface;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Data.Interface
{
    public interface IUserAppRoleMappingRepository : IRepository<UserAppRoleMapping, Guid> 
    {
        void RemoveAll(UserAppRoleMapping[] items);
    }
}
