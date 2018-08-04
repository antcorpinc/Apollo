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
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;

        public ApolloContextSeedData(ApolloContext context,
            UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
             // Adding Roles 
            // For now add Apollo role 

            if (await _roleManager.FindByNameAsync("SuperAdmin") == null)
            {
                var role = new Role()
                {
                    Id = new Guid("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    Name = "SuperAdmin",
                    UserType = (int)Domain.Enum.UserType.Apollo,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                   
                };

                var result1 = await _roleManager.CreateAsync(role);

                if (!result1.Succeeded) throw new InvalidProgramException("Failed to create seed role");
            }

        }
    }
}
