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
            // Add BackOffice Features
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
            // Add BackOffice Features - Top Level 1001 - 1010
              if (_context.Feature.Find((int)FeatureTypes.BackOfficeFeature.BackOfficeDashboard) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.BackOfficeDashboard,
                    Name = "BackOfficeDashboard",
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

             if (_context.Feature.Find((int)FeatureTypes.BackOfficeFeature.SocietyManagement) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.SocietyManagement,
                    Name = "BackOfficeSocietyManagement",
                    Description = "Society",
                    Order = 2,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

            if (_context.Feature.Find((int)FeatureTypes.BackOfficeFeature.FinanceManagement) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.FinanceManagement,
                    Name = "BackOfficeFinanceManagement",
                    Description = "Finance",
                    Order = 3,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

             if (_context.Feature.Find((int)FeatureTypes.BackOfficeFeature.UserManagement) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.UserManagement,
                    Name = "BackOfficeUserManagement",
                    Description = "Users",
                    Order = 4,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

            if (_context.Feature.Find((int)FeatureTypes.BackOfficeFeature.Advertisements) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.Advertisements,
                    Name = "BackOfficeAdvertisements",
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

             if (_context.Feature.Find((int)FeatureTypes.BackOfficeFeature.Tools) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.Tools,
                    Name = "Tools",
                    Description = "Tools",
                    Order = 6,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

              if (_context.Feature.Find((int)FeatureTypes.BackOfficeFeature.Reports) == null)
            {
                Feature feature = new Feature()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.Reports,
                    Name = "BackOfficeReports",
                    Description = "Reports",
                    Order = 7,
                    IsActive = true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,

                };
                _context.Add(feature);
            }

            // ~Add BackOffice Features
            // ~Add Features 

            // Add Application Feature
                // Add BackOffice Features
            if (_context.ApplicationFeature.Find(Guid.Parse("D4B09152-429C-46DA-A90D-9216069DE7E5")) == null)
            {
                ApplicationFeature boFeature = new ApplicationFeature()
                {
                    Id = new Guid("D4B09152-429C-46DA-A90D-9216069DE7E5"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureId = 1001,
                    IsActive=true
                };
                _context.Add(boFeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("E9249D50-6268-479A-805F-A4C2CD1B31F5")) == null)
            {
                ApplicationFeature boFeature = new ApplicationFeature()
                {
                    Id = new Guid("E9249D50-6268-479A-805F-A4C2CD1B31F5"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureId = 1002,
                    IsActive=true
                };
                _context.Add(boFeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("AB7C2E07-F0C2-4F19-80BE-43AD71A199FF")) == null)
            {
                ApplicationFeature boFeature = new ApplicationFeature()
                {
                    Id = new Guid("AB7C2E07-F0C2-4F19-80BE-43AD71A199FF"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureId = 1003,
                    IsActive=true
                };
                _context.Add(boFeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("1C0EECBB-0A32-4CB4-B16D-10BFABDBF39E")) == null)
            {
                ApplicationFeature boFeature = new ApplicationFeature()
                {
                    Id = new Guid("1C0EECBB-0A32-4CB4-B16D-10BFABDBF39E"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureId = 1004,
                    IsActive=true
                };
                _context.Add(boFeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("3167BACB-DA24-4962-9131-5EAC935D5163")) == null)
            {
                ApplicationFeature boFeature = new ApplicationFeature()
                {
                    Id = new Guid("3167BACB-DA24-4962-9131-5EAC935D5163"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureId = 1005,
                    IsActive=true
                };
                _context.Add(boFeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("9BE3D5A9-9223-49E4-A157-C8408DB50FE7")) == null)
            {
                ApplicationFeature boFeature = new ApplicationFeature()
                {
                    Id = new Guid("9BE3D5A9-9223-49E4-A157-C8408DB50FE7"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureId = 1006,
                    IsActive=true
                };
                _context.Add(boFeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("142EF676-E430-41F4-BBE2-98EC30515C73")) == null)
            {
                ApplicationFeature boFeature = new ApplicationFeature()
                {
                    Id = new Guid("142EF676-E430-41F4-BBE2-98EC30515C73"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureId = 1007,
                    IsActive=true
                };
                _context.Add(boFeature);
            }
                // ~Add BackOffice Features

                // Todo : Add Society Features
            // ~Add Application Feature

            // Add Application Role
            if (_context.ApplicationRole.Find(Guid.Parse("6F6146CF-D4AF-4761-8D80-80F891B53244")) == null)
            {
                ApplicationRole boFeature = new ApplicationRole()
                {
                    Id = new Guid("6F6146CF-D4AF-4761-8D80-80F891B53244"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    IsActive=true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                };
                _context.Add(boFeature);
            }

            // Todo: Add other Application Roles
            // ~Add Application Role

            // Add FeatureTypeRoleProvilege
            // Info: Society Id is null for BaackOffice Role , For Society it should have the Society Id
            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("CA9DE951-3C40-479C-AAAE-F3EA6246F9C5")) == null)
            {
                FeatureTypeRolePrivilege boFeature = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("CA9DE951-3C40-479C-AAAE-F3EA6246F9C5"),
                    FeatureId = 1001,
                    Privileges = "VW|CR|DE|AP",
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    SocietyId = null,
                    IsActive=true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                };
                _context.Add(boFeature);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("B62E4816-986D-44D1-B574-258580C538FE")) == null)
            {
                FeatureTypeRolePrivilege boFeaturePriv = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("B62E4816-986D-44D1-B574-258580C538FE"),
                    FeatureId = 1002,
                    Privileges = "VW|CR|DE|AP",
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    SocietyId = null,
                    IsActive=true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                };
                _context.Add(boFeaturePriv);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("FE080068-8183-4326-877C-16F6EFF22F7A")) == null)
            {
                FeatureTypeRolePrivilege boFeaturePriv = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("FE080068-8183-4326-877C-16F6EFF22F7A"),
                    FeatureId = 1003,
                    Privileges = "VW|CR|DE|AP",
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    SocietyId = null,
                    IsActive=true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                };
                _context.Add(boFeaturePriv);
            }

             if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("736B1469-9067-4791-8FEC-927A09A9D854")) == null)
            {
                FeatureTypeRolePrivilege boFeaturePriv = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("736B1469-9067-4791-8FEC-927A09A9D854"),
                    FeatureId = 1004,
                    Privileges = "VW|CR|DE|AP",
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    SocietyId = null,
                    IsActive=true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                };
                _context.Add(boFeaturePriv);
            }

             if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("1CFCA5A8-E32F-4696-9987-9FB95D683A8A")) == null)
            {
                FeatureTypeRolePrivilege boFeaturePriv = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("1CFCA5A8-E32F-4696-9987-9FB95D683A8A"),
                    FeatureId = 1005,
                    Privileges = "VW|CR|DE|AP",
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    SocietyId = null,
                    IsActive=true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                };
                _context.Add(boFeaturePriv);
            }

             if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("FF5022DB-ADCE-433E-8ED2-54BD5205C674")) == null)
            {
                FeatureTypeRolePrivilege boFeaturePriv = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("FF5022DB-ADCE-433E-8ED2-54BD5205C674"),
                    FeatureId = 1006,
                    Privileges = "VW|CR|DE|AP",
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    SocietyId = null,
                    IsActive=true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                };
                _context.Add(boFeaturePriv);
            }

             if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("29D89942-FF57-4FBB-B25A-D624C22BF5C5")) == null)
            {
                FeatureTypeRolePrivilege boFeaturePriv = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("29D89942-FF57-4FBB-B25A-D624C22BF5C5"),
                    FeatureId = 1007,
                    Privileges = "VW|CR|DE|AP",
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    SocietyId = null,
                    IsActive=true,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                };
                _context.Add(boFeaturePriv);
            }

            // ~Add FeatureTypeRoleProvilege

            // Add UserAppRoleMapping
            if (_context.UserAppRoleMapping.Find(Guid.Parse("8D70132B-60B2-4D36-9189-46A0A4FAD627")) == null)
            {
                UserAppRoleMapping usrAppRoleMapping = new UserAppRoleMapping()
                {
                   Id = new Guid("8D70132B-60B2-4D36-9189-46A0A4FAD627"),
                   RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                   UserId = Guid.Parse("7430DD69-3F53-4471-A621-E1E3BB582D45"),
                   ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                   IsActive=true,
                   CreatedBy = "SystemAdmin",
                   CreatedDate = DateTime.UtcNow,
                   UpdatedBy = "SystemAdmin",
                   UpdatedDate = DateTime.UtcNow
                };
                _context.Add(usrAppRoleMapping);
            }
            // ~ // Add UserAppRoleMapping

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
