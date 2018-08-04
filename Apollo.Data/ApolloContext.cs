using Apollo.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Data
{
   public class ApolloContext : IdentityDbContext<User,Role, Guid>
    {
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationFeature> ApplicationFeature { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAppRoleMapping> UserAppRoleMapping { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        public ApolloContext(DbContextOptions<ApolloContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Changing the Default Schemas
            // https://stackoverflow.com/questions/28948309/how-to-remove-dbo-aspnetuserclaims-and-dbo-aspnetuserlogins-tables-identityuser/28950804
            // Change the User entity to point to the User   Table instead of the default
            builder.Entity<IdentityUser<Guid>>().ToTable("User", "Security");
            // Change the Role entity to point to the Role Table instead of the default
            builder.Entity<IdentityRole<Guid>>().ToTable("Role", "Security");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AspNetUserClaims", "Security");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AspNetUserRoles", "Security");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AspNetRoleClaims", "Security");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AspNetUserLogins", "Security");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AspNetUserTokens", "Security");
           
        }
    }
}
