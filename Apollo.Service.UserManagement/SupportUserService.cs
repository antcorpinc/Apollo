using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Domain.Entity;
using Apollo.Service.UserManagement.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement
{
    public class SupportUserService : ISupportUserService
    {
        private IUserRepository _userRepository;
        public SupportUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IdentityResult> CreateUser(SupportUser user)
        {
            // Map manually DTO --> Entity
            //Todo Handle Error from services            ;
            return this._userRepository.Add(this.MapToEntity(user), user.Password);

            
        }

        ApolloUser MapToEntity(SupportUser user)
        {
            var apolloUser = new ApolloUser();
            apolloUser.FirstName = user.FirstName;
            apolloUser.LastName = user.LastName;
            apolloUser.UserName = user.UserName;
            apolloUser.Email = user.Email;
            apolloUser.UserTypeId = user.UserType;
            apolloUser.IsActive = user.IsActive;
            
            apolloUser.CreatedBy = user.CreatedBy;
            apolloUser.CreatedDate = DateTime.UtcNow;
            apolloUser.UpdatedBy = user.UpdatedBy;
            apolloUser.UpdatedDate = DateTime.UtcNow;
            apolloUser.ObjectState = user.ObjectState;


            apolloUser.UserAppRoleMappings.Clear();

            foreach (var item in user.UserApplicationRole)
            {
                apolloUser.UserAppRoleMappings.Add(new Apollo.Domain.Entity.UserAppRoleMapping
                {
                    Id = Guid.NewGuid(),
                    ApplicationId = item.ApplicationId,
                    RoleId = item.RoleId,                    
                    IsActive = true,
                    ObjectState = item.ObjectState,
                    CreatedBy = user.CreatedBy,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = user.UpdatedBy,
                    UpdatedDate = DateTime.UtcNow
                   
                });
            }

            return apolloUser;
        }

        public List<ApolloUser> GetAllUsers()
        {
            return _userRepository.FindSupportUsers(user => user.UserTypeId == (int)Domain.Enum.UserType.SupportUser).ToList();
        }
    }
}
