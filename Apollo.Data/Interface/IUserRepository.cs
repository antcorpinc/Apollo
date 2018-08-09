using Apollo.Core.Interface;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Data.Interface
{
    public interface IUserRepository : IRepository<ApolloUser, Guid>   {

        // Add User Specific Methods
    }
}