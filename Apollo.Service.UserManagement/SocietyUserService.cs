using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO;
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
        public SocietyUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<Apollo.Domain.DTO.SocietyUser>> CreateUserAsync(Domain.DTO.SocietyUserCreate userCreate)
        {
            var validator = new SocietyUserCreateValidator();
            var results = validator.Validate(userCreate);
            var response = new ServiceResponse<Domain.DTO.SocietyUser>();
            response.ErrorMessages = results.Errors.ToList();
            if (!response.Successful)
            {
                return response;
            }

            var result = await this._userRepository.Add(MapToCreateEntity(userCreate), userCreate.Password);
            if(!result.Succeeded)
            {
                // Todo: Throw Exception or Valication Msg
                response.ErrorMessages.Add(new ValidationFailure("", "Failed to Create User"));
                return response;
            }
            // Todo: Map to SocietyUser Dto from ApolloUser
            return response;
        }

        // Complex Mapping add here

        ApolloUser MapToCreateEntity(SocietyUserCreate user)
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

            apolloUser.SocietyUser = new Domain.Entity.SocietyUser
                {
                    Id = Guid.NewGuid(),
                    SocietyId = user.SocietyUser.SocietyId,
                    BuildingId = user.SocietyUser.BuildingId,
                    FlatId = user.SocietyUser.FlatId,
                    UserId = user.SocietyUser.UserId,
                };
            return apolloUser;
        }

        public List<ApolloUser> GetAllUsers()
        {
            return _userRepository.FindSupportUsers(user => user.UserTypeId == (int)Domain.Enum.UserType.SocietyUser).ToList();
        }
    }
}
