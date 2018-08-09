using Apollo.Domain.Entity;
/*using MG.Jarvis.Model.Enums; */
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Apollo.Domain.Enum;
namespace Apollo.Data
{
   public class ApolloContextSeedData
    {
        private ApolloContext _context;
        private UserManager<ApolloUser> _userManager;
        private RoleManager<ApolloRole> _roleManager;

        public ApolloContextSeedData(ApolloContext context,
            UserManager<ApolloUser> userManager, RoleManager<ApolloRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {

            // Add UserTypes 
            if (_context.UserType.Find((int)Domain.Enum.UserType.SupportUser) == null) {
                Domain.Entity.UserType userType = new Domain.Entity.UserType()
                {
                    Id = (int)Domain.Enum.UserType.SupportUser,
                    Type = "SupportUser",
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow
                };
                _context.Add(userType);
            }

            if (_context.UserType.Find((int)Domain.Enum.UserType.SocietyUser) == null)
            {
                Domain.Entity.UserType userType = new Domain.Entity.UserType()
                {
                    Id = (int)Domain.Enum.UserType.SocietyUser,
                    Type = "SocietyUser",
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow
                };
                _context.Add(userType);
            }
            // Adding Roles 
            // For now add Apollo role 

            if (await _roleManager.FindByNameAsync("SuperAdmin") == null)
            {
                var role = new ApolloRole()
                {
                    Id = new Guid("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    Name = "SuperAdmin",
                    UserTypeId = (int)Domain.Enum.UserType.SupportUser,
                    Description="This role has access to all features in application",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };

                var result = await _roleManager.CreateAsync(role);

                    if (!result.Succeeded) throw new InvalidProgramException("Failed to create seed role");
            }

            // Add Applications
            if (_context.Application.Find(Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97")) == null)
            {
                Application backoffice = new Application()
                {
                    Id = new Guid("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    Name = "BackOffice",
                    Description = "Application for managing BackOffice features",
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,                  

                };

                _context.Add(backoffice);
            }

            // Add Roles for the Applications

            _context.SaveChanges();
        }
    }
}
