using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Domain.Entity;
using Apollo.Domain.Enum;
using Apollo.Domain.ViewModel;
using Apollo.Service.UserManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public void CreateSupportUser(SupportUserVm user)
        {
            // Todo: Call the Helper to create Pwd for Support User before inserting in the Apollo User Table
            // Deserialize to User Entity 
            throw new NotImplementedException();
        }

        public List<ApolloUser> GetAllUsersBasedOnUserType(Domain.Enum.UserType userType)
        {
            return _userRepository.FindSupportUsers(user => user.UserTypeId == (int)userType).ToList();
           // return _userRepository.GetSupportUsers();
        }

        public UserDetails GetUserDetails(Guid id)
        {
            var user = _userRepository.Get(id);
            var userDetails = new UserDetails() {
                 Id = user.Id,
                 Email = user.Email,
                 UserName = user.UserName,
                 FirstName = user.FirstName,
                 LastName = user.LastName,
                 IsActive = user.IsActive,
                 UserTypeId = user.UserTypeId,
                 PhoneNumber = user.PhoneNumber,
                 
            };
            var applicationPermissions = new List<ApplicationPermission>();

            foreach(var userAppRole in user.UserAppRoleMappings)
            {
                List<RolePrivilege> roleDetails = new List<RolePrivilege>();

                if(userDetails.UserTypeId == (int)Apollo.Domain.Enum.UserType.SupportUser)
                {
                    roleDetails =
                        _roleRepository.GetRelatedPrivilegesForRoleAndApp(userAppRole.RoleId, userAppRole.ApplicationId);
                }
                else if(userDetails.UserTypeId==(int)Apollo.Domain.Enum.UserType.SocietyUser)
                {
                    roleDetails =
                        _roleRepository.GetRelatedPrivilegesForRoleAppAndSociety
                        (userAppRole.RoleId, userAppRole.ApplicationId, userAppRole.SocietyId);
                }

                if (roleDetails.Count > 0)
                {
                    var applicationPermission = new ApplicationPermission();
                    applicationPermission.Id = userAppRole.ApplicationId;
                    applicationPermission.Name = roleDetails[0].ApplicationName;
                    applicationPermission.RoleId = userAppRole.Role.Id;
                    applicationPermission.Role = roleDetails[0].RoleName;

                    Dictionary<int, FeaturePermission> featurePermissions = new Dictionary<int, FeaturePermission>();
                    foreach (var roleDetail in roleDetails)
                    {
                        FeaturePermission featurePermission = new FeaturePermission();
                        featurePermission.FeatureTypeId = roleDetail.FeatureTypeId;
                        featurePermission.TypeName = roleDetail.FeatureTypeName;
                        featurePermission.Label = roleDetail.FeatureLabel;
                        featurePermission.ParentFeatureId = roleDetail.ParentFeatureId;
                        featurePermission.Order = roleDetail.Order;
                        featurePermission.Privileges = roleDetail.Privileges;
                                         
                        applicationPermission.FeaturesList.Add(featurePermission);
                    }

                    applicationPermissions.Add(applicationPermission);
                }
            }

            userDetails.ApplicationPermissions = applicationPermissions;
            return userDetails;
        }
        
    }
}
