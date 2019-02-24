using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Domain.DTO.User;
using Apollo.Domain.Entity;
using Apollo.Service.UserManagement.Interface;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement
{
    public class SocietyUserService: ISocietyUserService
    {
        private IUserRepository _userRepository;
        private ICustomSocietyUserRepository _customSocietyUserRepository;
        private ICustomApplicationRepository _customApplicationRepository;
        private IUserAppRoleMappingRepository _userAppRoleMappingRepository;
        public SocietyUserService(IUserRepository userRepository,
            ICustomSocietyUserRepository customSocietyUserRepository,
            ICustomApplicationRepository customApplicationRepository,
            IUserAppRoleMappingRepository userAppRoleMappingRepository)
        {
            _userRepository = userRepository;
            _customSocietyUserRepository = customSocietyUserRepository;
            _customApplicationRepository = customApplicationRepository;
            _userAppRoleMappingRepository = userAppRoleMappingRepository;
        }

        // Complex Mapping add here
        ApolloUser MapToUpdateEntity(SocietyUserUpdate user, Guid userId)
        {
            var apolloUser = this._userRepository.Get(userId);
            apolloUser.FirstName = user.FirstName;
            apolloUser.LastName = user.LastName;
            // Todo why is username null?? For now workaround
            // apolloUser.UserName = user.UserName;
            apolloUser.UserName = user.Email;
            apolloUser.Email = user.Email;
            apolloUser.PhoneNumber = user.PhoneNumber;
            apolloUser.UserTypeId = user.UserType;
            apolloUser.IsActive = user.IsActive;

         //   apolloUser.CreatedBy = user.CreatedBy;
        // Todo : NOte this is workaround - Fix why the created date is not added when creating
            apolloUser.CreatedDate = user.UpdatedDate;
            apolloUser.CreatedBy = user.UpdatedBy;
            // Todo : NOte this is workaround - Fix why the created date is not added when creating
            apolloUser.UpdatedBy = user.UpdatedBy;
            apolloUser.UpdatedDate = user.UpdatedDate;
            apolloUser.ObjectState = user.ObjectState;

            this._userAppRoleMappingRepository.RemoveAll(apolloUser.UserAppRoleMappings.ToArray());
            apolloUser.UserAppRoleMappings.Clear();

            var usrAppRoleMap = new Apollo.Domain.Entity.UserAppRoleMapping();
            usrAppRoleMap.Id = Guid.NewGuid();
            usrAppRoleMap.UserId = userId;
            usrAppRoleMap.ApplicationId = user.UserApplicationRole.ApplicationId;
            usrAppRoleMap.RoleId = user.UserApplicationRole.RoleId;
            usrAppRoleMap.SocietyId = user.UserApplicationRole.SocietyId;
            usrAppRoleMap.IsActive = user.IsActive;
            usrAppRoleMap.ObjectState = user.ObjectState;
            usrAppRoleMap.CreatedBy = apolloUser.CreatedBy;
            usrAppRoleMap.CreatedDate = apolloUser.CreatedDate.Value;
            usrAppRoleMap.UpdatedBy = user.UpdatedBy;
            usrAppRoleMap.UpdatedDate = user.UpdatedDate;

            apolloUser.UserAppRoleMappings.Add(usrAppRoleMap);
            //apolloUser.UserAppRoleMappings.Add(new Apollo.Domain.Entity.UserAppRoleMapping
            //{
            //    Id = Guid.NewGuid(),
            //    ApplicationId = user.UserApplicationRole.ApplicationId,
            //    RoleId = user.UserApplicationRole.RoleId,
            //    SocietyId = user.UserApplicationRole?.SocietyId.Value,
            //    IsActive = user.IsActive,
            //    ObjectState = user.ObjectState,
            //    CreatedBy = apolloUser.CreatedBy,
            //    CreatedDate = apolloUser.CreatedDate.Value,
            //    UpdatedBy = user.UpdatedBy,
            //    UpdatedDate = user.UpdatedDate
            //});
            //apolloUser.SocietyUser = new Domain.Entity.SocietyUser
            //{
            //    Id = Guid.NewGuid(),
            //    SocietyId = user.SocietyUser.SocietyId,
            //    BuildingId = user.SocietyUser.BuildingId,
            //    FlatId = user.SocietyUser.FlatId
            //};
            return apolloUser;
        }
        ApolloUser MapToCreateEntity(Domain.DTO.User.SocietyUserCreate user)
        {
            var apolloUser = new ApolloUser();
            apolloUser.FirstName = user.FirstName;
            apolloUser.LastName = user.LastName;
            apolloUser.UserName = user.UserName;
            apolloUser.Email = user.Email;
            apolloUser.PhoneNumber = user.PhoneNumber;
            apolloUser.UserTypeId = user.UserType;
            apolloUser.IsActive = user.IsActive;

            apolloUser.CreatedBy = user.CreatedBy;
            apolloUser.CreatedDate = user.CreatedDate;
            apolloUser.UpdatedBy = user.UpdatedBy;
            apolloUser.UpdatedDate = user.UpdatedDate;
            apolloUser.ObjectState = user.ObjectState;


            apolloUser.UserAppRoleMappings.Clear();
            apolloUser.UserAppRoleMappings.Add(new Apollo.Domain.Entity.UserAppRoleMapping
            {
                Id = Guid.NewGuid(),
                ApplicationId = user.SocietyUser.ApplicationId.Value,
                RoleId = user.SocietyUser.RoleId.Value,
                IsActive = user.IsActive,
                ObjectState = user.ObjectState,
                CreatedBy = user.CreatedBy,
                CreatedDate = user.CreatedDate,
                UpdatedBy = user.UpdatedBy,
                UpdatedDate = user.UpdatedDate
            });
            apolloUser.SocietyUser = new Domain.Entity.SocietyUser
                {
                    Id = Guid.NewGuid(),
                    SocietyId = user.SocietyUser.SocietyId,
                    BuildingId = user.SocietyUser.BuildingId,
                    FlatId = user.SocietyUser.FlatId            
                };
            return apolloUser;
        }

        public List<ApolloUser> GetAllUsers()
        {
            return _userRepository.FindSupportUsers(user => user.UserTypeId == (int)Domain.Enum.UserType.SocietyUser).ToList();
        }

        public async Task<ServiceResponse<List<SocietyUserListItem>>> GetUsersForSocietyAsync(Guid societyId)
        {
            var response = new ServiceResponse<List<SocietyUserListItem>>();
            var societyUsers = await this._customSocietyUserRepository.GetSocietyUsersAsync(societyId);
            if (societyUsers == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any results"));
                return response;
            }
            response.Data = societyUsers;
            return response;
        }

        public async Task<ServiceResponse<Domain.DTO.User.SocietyUser>> UpdateUserAsync(Guid userId,
            SocietyUserUpdate user)
        {
            var validator = new Domain.DTO.User.SocietyUserUpdateValidator();
            var results = validator.Validate(user);
            var response = new ServiceResponse<Apollo.Domain.DTO.User.SocietyUser>();
            response.ErrorMessages = results.Errors.ToList();
            if (!response.Successful)
            {
                return response;
            }
            var appUser = MapToUpdateEntity(user, userId);
            var result = await this._userRepository.Update(appUser);
            if (!result.Succeeded)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Failed to Update User"));
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<Domain.DTO.User.SocietyUser>> CreateUserAsync(Domain.DTO.User.SocietyUserCreate user)
        {
            var validator = new Domain.DTO.User.SocietyUserCreateValidator();
            var results = validator.Validate(user);
            var response = new ServiceResponse<Apollo.Domain.DTO.User.SocietyUser>();
            response.ErrorMessages = results.Errors.ToList();
            if (!response.Successful)
            {
                return response;
            }
            var applicationDetails = await this._customApplicationRepository.GetApplicationDetails(Constants.SOCIETYAPPLICATION);
            if (applicationDetails == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Could not find application"));
                return response;
            }
            user.SocietyUser.ApplicationId = applicationDetails.Id;
            var result = await this._userRepository.Add(MapToCreateEntity(user), user.Password);
            if (!result.Succeeded)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Failed to Create User"));
                return response;
            }            
            return response;
        }

        public async Task<ServiceResponse<SocietyUserListItem>> GetSocietyUserAsync(Guid userId)
        {
            var response = new ServiceResponse<SocietyUserListItem>();
            var societyUser = await this._customSocietyUserRepository.GetSocietyUserAsync(userId);
            if (societyUser == null)
            {
                response.ErrorMessages.Add(new ValidationFailure("", "Search did not yield any results"));
                return response;
            }
            response.Data = societyUser;
            return response;
        }

        
    }
}
