using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using Apollo.Service.UserManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo.Service.UserManagement
{
    public class SupportUserService : ISupportUserService
    {
        private IUserRepository _userRepository;
        public SupportUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<ApolloUser> GetAllUsers()
        {
            return _userRepository.FindSupportUsers(user => user.UserTypeId == (int)Domain.Enum.UserType.SupportUser).ToList();
        }
    }
}
