﻿using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Domain.Entity;
using Apollo.Service.UserManagement.Interface;
using Apollo.Service.UserManagement.Mappers;
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
        private IUserAppRoleMappingRepository _userAppRoleMappingRepository;
        public SupportUserService(IUserRepository userRepository,
            IUserAppRoleMappingRepository userAppRoleMappingRepository)
        {
            _userRepository = userRepository;
            _userAppRoleMappingRepository = userAppRoleMappingRepository;
        }

        // Todo: User a single methods for Add and Update since they are same  or are they ??
        public Task<IdentityResult> CreateUser(SupportUser user)
        {
            // Map manually DTO --> Entity
            //Todo Handle Error from services            ;
            return this._userRepository.Add(this.MapToEntity(user), user.Password);
        }
        public Task<IdentityResult> UpdateUser(SupportUser user)
        {
            return this._userRepository.Update(this.MapToUpdateEntity(user));
        }

        ApolloUser MapToUpdateEntity(SupportUser user)
        {
            var apolloUser = this._userRepository.Get(user.Id);
            // ApolloUser apolloUser = this._userRepository.FindById(user.Id).Result;
            //var apolloUser = new ApolloUser();
            // apolloUser.Id = user.Id;
            apolloUser.FirstName = user.FirstName;
            apolloUser.LastName = user.LastName;
            apolloUser.UserName = user.UserName;
            apolloUser.Email = user.Email;
            apolloUser.PhoneNumber = user.PhoneNumber;
            // apolloUser.UserTypeId = user.UserType;
            apolloUser.IsActive = user.IsActive;

            // apolloUser.CreatedBy = user.CreatedBy;
            // apolloUser.CreatedDate = DateTime.UtcNow;
            apolloUser.UpdatedBy = user.UpdatedBy;
            apolloUser.UpdatedDate = DateTime.UtcNow;
            apolloUser.ObjectState = user.ObjectState;

            this._userAppRoleMappingRepository.RemoveAll(apolloUser.UserAppRoleMappings.ToArray());
            apolloUser.UserAppRoleMappings.Clear();

            foreach (var item in user.UserApplicationRole)
            {
                apolloUser.UserAppRoleMappings.Add(new Apollo.Domain.Entity.UserAppRoleMapping
                {
                    // Id = item.Id == null ? Guid.NewGuid() : item.Id.Value,
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
        ApolloUser MapToEntity(SupportUser user)
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
            return _userRepository.FindSupportUsers
                (user => user.UserTypeId == (int)Domain.Enum.UserType.SupportUser).ToList();
        }

        //public async Task<List<ApolloUser>> GetAllUsersAsync()
        //{
        //    return await _userRepository.FindSupportUsersAsync
        //        (user => user.UserTypeId == (int)Domain.Enum.UserType.SupportUser);          
        //}
        public async Task<List<Domain.DTO.SupportUserList>> GetAllUsersAsync()
        {
            var users = await _userRepository.FindSupportUsersAsync
                (user => user.UserTypeId == (int)Domain.Enum.UserType.SupportUser);
            return SupportUserMapper.MapToSupportUserList(users);
        }

        public ApolloUser GetById(Guid id)
        {
            return _userRepository.FindSupportUsers(
                user => user.UserTypeId == (int)Domain.Enum.UserType.SupportUser &&
                     user.Id == id).FirstOrDefault();
        }

        public async Task<Domain.DTO.SupportUser> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return SupportUserMapper.MapToSupportUser(user);
        }
    }
}
