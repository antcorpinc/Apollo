using Apollo.Domain.Entity;
using Apollo.Domain.Entity.MasterData;
using Apollo.Domain.Entity.Society;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Data
{
   public class ApolloContext : IdentityDbContext<ApolloUser,ApolloRole, Guid>
    {
        // Security Schema Tables 
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationFeature> ApplicationFeature { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        public virtual DbSet<ApolloRole> Role { get; set; }
        public virtual DbSet<ApolloUser> User { get; set; }
        public virtual DbSet<UserAppRoleMapping> UserAppRoleMapping { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        // ~ Security Schema Tables

        // Mater Schema Tables 
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<City> City { get; set; }

        public virtual DbSet<Area> Area { get; set; }

        // ~Master Schema Tables 

        // Society Schema Tables 
        public virtual DbSet<Society> Society { get; set; }

        // Society Schema Tables 

        public ApolloContext(DbContextOptions<ApolloContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Changing the Default Schemas
            // https://stackoverflow.com/questions/28948309/how-to-remove-dbo-aspnetuserclaims-and-dbo-aspnetuserlogins-tables-identityuser/28950804
            // Change the ApolloUser entity to point to the User   Table instead of the default
            builder.Entity<ApolloUser>().ToTable("User", "Security");
            // Change the ApolloRole entity to point to the Role Table instead of the default
            builder.Entity<ApolloRole>().ToTable("Role", "Security");

            // The below AspIdentity Tables are not used , however they need to be created
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AspNetUserClaims", "Security");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AspNetUserRoles", "Security");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AspNetRoleClaims", "Security");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AspNetUserLogins", "Security");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AspNetUserTokens", "Security");
            // ~The below AspIdentity Tables are not used , however they need to be created

         
        }
    }
}
