using Apollo.Domain.DTO;
using Apollo.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.UserManagement.Interface
{
    public interface IUserService
    {
        UserDetails GetUserDetails(Guid id);
        void CreateSupportUser(SupportUserVm user);

    }
}
