﻿using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.UserManagement.Interface
{
    public interface ISupportUserService
    {
        List<ApolloUser> GetAllUsers();
    }
}