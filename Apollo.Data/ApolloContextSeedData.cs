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
            if (_context.UserType.Find((int)Domain.Enum.UserType.Apollo) == null) {
                Domain.Entity.UserType userType = new Domain.Entity.UserType()
                {
                    Id = (int)Domain.Enum.UserType.Apollo,
                    Type = "ApolloUser",
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

            if (await _roleManager.FindByNameAsync("ApolloSuperAdmin") == null)
            {
                var role = new ApolloRole()
                {
                    Id = new Guid("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    Name = "ApolloSuperAdmin",
                    UserType = (int)Domain.Enum.UserType.Apollo,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };

                var result = await _roleManager.CreateAsync(role);

                    if (!result.Succeeded) throw new InvalidProgramException("Failed to create seed role");
                }
                _context.SaveChanges();
        }
    }
}
