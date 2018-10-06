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

            if (await _roleManager.FindByNameAsync("SocietyAdmin") == null)
            {
                var role = new ApolloRole()
                {
                    Id = new Guid("A5BE6F05-7D89-4532-A275-85F6919A637F"),
                    Name = "SocietyAdmin",
                    UserTypeId = (int)Domain.Enum.UserType.SocietyUser,
                    Description = "This role has access to all features in society",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };

                var result = await _roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new InvalidProgramException("Failed to create seed role");
            }

            // Add Users 
            if (await _userManager.FindByNameAsync("ronithomas@gmail.com") == null)
            {
                var user = new ApolloUser()
                {
                    Id = new Guid("7430DD69-3F53-4471-A621-E1E3BB582D45"),
                    IsActive = true,
                    Email = "ronithomas@gmail.com",
                    FirstName = "Roni",
                    LastName = "Thomas",
                    PhoneNumber = "214-529-2634",
                    UserName = "ronithomas@gmail.com",
                    UserTypeId = (int)Domain.Enum.UserType.SupportUser,
                    CreatedBy = "SystemAdmin",
                    UpdatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,                  
                    
                   
                };
                await _userManager.CreateAsync(user, "DDdd@1234");
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

            if (_context.Application.Find(Guid.Parse("664EAA01-3C48-42BE-9194-86879AD0A712")) == null)
            {
                Application backoffice = new Application()
                {
                    Id = new Guid("664EAA01-3C48-42BE-9194-86879AD0A712"),
              //      Name = "Apollo",
                    Name = "Society",
                    Description = "Application for managing Society features",
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };

                _context.Add(backoffice);
            }

            // Add Roles for the Applications

            // Add Features 
            // Add Apollo Features
            // Add Top Level Apollo Features
            if (_context.Feature.Find((int)FeatureTypes.ApolloFeature.ApolloDashboard) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.ApolloFeature.ApolloDashboard,
                    Name = "ApolloDashboard",
                    Description = "Dashboard",
                    Order = 1,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }
            if (_context.Feature.Find((int)FeatureTypes.ApolloFeature.SocietyManagement) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.ApolloFeature.SocietyManagement,
                    Name = "SocietyManagement",
                    Description = "Society Management",
                    Order = 2,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

            if (_context.Feature.Find((int)FeatureTypes.ApolloFeature.FormManagement) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.ApolloFeature.FormManagement,
                    Name = "FormManagement",
                    Description = "Forms",
                    Order = 3,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

            if (_context.Feature.Find((int)FeatureTypes.ApolloFeature.UserManagement) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.ApolloFeature.UserManagement,
                    Name = "UserManagement",
                    Description = "User Management",
                    Order = 4,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

            if (_context.Feature.Find((int)FeatureTypes.ApolloFeature.Advertisements) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.ApolloFeature.Advertisements,
                    Name = "Advertisements",
                    Description = "Advertisements",
                    Order = 5,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

            if (_context.Feature.Find((int)FeatureTypes.ApolloFeature.Reports) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.ApolloFeature.Reports,
                    Name = "Reports",
                    Description = "Reports",
                    Order = 6,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }
            // ~Add Top Level Apollo Features

            // ~Add Apollo Features
            // Add BackOffice Features
            // ~Add BackOffice Features
            // ~Add Features 

            // Add States

            if (_context.State.Find((int)States.Maharashtra) == null)
            {
                Domain.Entity.MasterData.State state = new Domain.Entity.MasterData.State()
                {
                    Id = (int)States.Maharashtra,
                    Name= "Maharashtra",
                    DisplayName= "Maharashtra",
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow
                };
                _context.Add(state);
            }

            // Add Cities of the States

            if (_context.City.Find((int)Cities.Pune) == null)
            {
                Domain.Entity.MasterData.City city = new Domain.Entity.MasterData.City()
                {
                    Id = (int)Cities.Pune,
                    Name = "Pune",
                    StateId = (int)States.Maharashtra,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow
                };
                _context.Add(city);
            }
            // Add Areas within cities of the state

            if (_context.Area.Find((int)Areas.AundhRoad) == null)
            {
                Domain.Entity.MasterData.Area area= new Domain.Entity.MasterData.Area()
                {
                    Id = (int)Areas.AundhRoad,
                    Name = "AundhRoad",
                    StateId = (int)States.Maharashtra,
                    CityId = (int)Cities.Pune,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow
                };
                _context.Add(area);
            }

            if (_context.Area.Find((int)Areas.Bopodi) == null)
            {
                Domain.Entity.MasterData.Area area = new Domain.Entity.MasterData.Area()
                {
                    Id = (int)Areas.Bopodi,
                    Name = "Bopodi",
                    StateId = (int)States.Maharashtra,
                    CityId = (int)Cities.Pune,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow
                };
                _context.Add(area);
            }

            _context.SaveChanges();
        }
    }
}
