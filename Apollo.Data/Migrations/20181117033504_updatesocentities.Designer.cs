﻿// <auto-generated />
using System;
using Apollo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apollo.Data.Migrations
{
    [DbContext(typeof(ApolloContext))]
    [Migration("20181117033504_updatesocentities")]
    partial class updatesocentities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apollo.Domain.Entity.ApolloRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int?>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Role","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.ApolloUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(256);

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserTypeId");

                    b.ToTable("User","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Application","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.ApplicationFeature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationId");

                    b.Property<int>("FeatureId");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("FeatureId");

                    b.ToTable("ApplicationFeature","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("RoleId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("RoleId");

                    b.ToTable("ApplicationRole","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int?>("Order");

                    b.Property<int?>("ParentFeatureId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ParentFeatureId");

                    b.ToTable("Feature","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.FeatureTypeRolePrivilege", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("FeatureId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Privileges");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid?>("SocietyId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SocietyId");

                    b.ToTable("FeatureTypeRolePrivilege","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.MasterData.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int?>("StateId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Area","MasterData");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.MasterData.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int?>("StateId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("City","MasterData");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.MasterData.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("State","MasterData");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Society.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("SocietyId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId");

                    b.ToTable("Building","Society");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Society.Flat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BuildingId");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("SocietyId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Flat","Society");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Society.Society", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalPhoneNumber")
                        .HasMaxLength(20);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(500);

                    b.Property<int>("AreaId");

                    b.Property<int>("CityId");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Landmark")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid?>("ParentSocietyId");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("StateId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CityId");

                    b.HasIndex("ParentSocietyId");

                    b.HasIndex("StateId");

                    b.ToTable("Society","Society");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.SocietyRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("SocietyId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("SocietyId");

                    b.ToTable("SocietyRole","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.SocietyUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BuildingId");

                    b.Property<Guid>("FlatId");

                    b.Property<Guid>("SocietyId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId");

                    b.HasIndex("UserId");

                    b.ToTable("SocietyUser","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.UserAppRoleMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid?>("SocietyId");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SocietyId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAppRoleMapping","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("UserType","Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims","Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims","Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins","Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles","Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens","Security");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.ApolloRole", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.UserType", "UserType")
                        .WithMany("Role")
                        .HasForeignKey("UserTypeId");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.ApolloUser", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.UserType", "UserType")
                        .WithMany("User")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apollo.Domain.Entity.ApplicationFeature", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.Application", "Application")
                        .WithMany("ApplicationFeature")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.Feature", "Feature")
                        .WithMany("ApplicationFeature")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apollo.Domain.Entity.ApplicationRole", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.Application", "Application")
                        .WithMany("ApplicationRole")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.ApolloRole", "Role")
                        .WithMany("ApplicationRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Feature", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.Feature", "ParentFeature")
                        .WithMany("InverseParentFeature")
                        .HasForeignKey("ParentFeatureId");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.FeatureTypeRolePrivilege", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.Feature", "Feature")
                        .WithMany("FeatureTypeRolePrivilege")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.ApolloRole", "Role")
                        .WithMany("FeatureTypeRolePrivilege")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.Society.Society", "Society")
                        .WithMany()
                        .HasForeignKey("SocietyId");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.MasterData.Area", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.MasterData.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Apollo.Domain.Entity.MasterData.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.MasterData.City", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.MasterData.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Society.Building", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.Society.Society", "Society")
                        .WithMany("Buildings")
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Society.Flat", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.Society.Building", "Building")
                        .WithMany("Flats")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apollo.Domain.Entity.Society.Society", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.MasterData.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.MasterData.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.Society.Society", "ParentSociety")
                        .WithMany()
                        .HasForeignKey("ParentSocietyId");

                    b.HasOne("Apollo.Domain.Entity.MasterData.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apollo.Domain.Entity.SocietyRole", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.ApolloRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.Society.Society", "Society")
                        .WithMany()
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apollo.Domain.Entity.SocietyUser", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.Society.Society", "Society")
                        .WithMany("SocietyUsers")
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.ApolloUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apollo.Domain.Entity.UserAppRoleMapping", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.Application", "Application")
                        .WithMany("UserAppRoleMapping")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.ApolloRole", "Role")
                        .WithMany("UserAppRoleMapping")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.Society.Society", "Society")
                        .WithMany()
                        .HasForeignKey("SocietyId");

                    b.HasOne("Apollo.Domain.Entity.ApolloUser", "User")
                        .WithMany("UserAppRoleMappings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.ApolloRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.ApolloUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.ApolloUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.ApolloRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apollo.Domain.Entity.ApolloUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Apollo.Domain.Entity.ApolloUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
