using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class IdentityUserRoleTableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_AspNetRoles_RoleId",
                schema: "Security",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Security",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Security",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Security",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Security",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Security",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Security",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureTypeRolePrivilege_AspNetRoles_RoleId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAppRoleMapping_AspNetRoles_RoleId",
                schema: "Security",
                table: "UserAppRoleMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAppRoleMapping_AspNetUsers_UserId",
                schema: "Security",
                table: "UserAppRoleMapping");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Security");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Security",
                table: "User",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "Security",
                table: "User",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "Security",
                table: "User",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Security",
                table: "User",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Security",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Security",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Security",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "User",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Security",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                schema: "Security",
                table: "User",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "Security",
                table: "User",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Security",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                schema: "Security",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                schema: "Security",
                table: "Role",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Security",
                table: "Role",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Security",
                table: "Role",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Security",
                table: "Role",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Security",
                table: "Role",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Security",
                table: "Role",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "Security",
                table: "Role",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Security",
                table: "Role",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                schema: "Security",
                table: "Role",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserType",
                schema: "Security",
                table: "User",
                column: "UserType");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserType",
                schema: "Security",
                table: "Role",
                column: "UserType");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_Role_RoleId",
                schema: "Security",
                table: "ApplicationRole",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Role_RoleId",
                schema: "Security",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                schema: "Security",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                schema: "Security",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Role_RoleId",
                schema: "Security",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                schema: "Security",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                schema: "Security",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureTypeRolePrivilege_Role_RoleId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_UserType_UserType",
                schema: "Security",
                table: "Role",
                column: "UserType",
                principalSchema: "Security",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_UserType",
                schema: "Security",
                table: "User",
                column: "UserType",
                principalSchema: "Security",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAppRoleMapping_Role_RoleId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAppRoleMapping_User_UserId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_Role_RoleId",
                schema: "Security",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Role_RoleId",
                schema: "Security",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                schema: "Security",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                schema: "Security",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Role_RoleId",
                schema: "Security",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                schema: "Security",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                schema: "Security",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureTypeRolePrivilege_Role_RoleId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_UserType_UserType",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_UserType",
                schema: "Security",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAppRoleMapping_Role_RoleId",
                schema: "Security",
                table: "UserAppRoleMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAppRoleMapping_User_UserId",
                schema: "Security",
                table: "UserAppRoleMapping");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "User");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserType",
                schema: "Security",
                table: "User");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserType",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserType",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserType",
                schema: "Security",
                table: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Security",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "Security",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "Security",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Security",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                schema: "Security",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Security",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_UserType_UserType",
                        column: x => x.UserType,
                        principalSchema: "Security",
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(maxLength: 256, nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PhotoUrl = table.Column<string>(maxLength: 256, nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserType_UserType",
                        column: x => x.UserType,
                        principalSchema: "Security",
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserType",
                schema: "Security",
                table: "AspNetRoles",
                column: "UserType");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserType",
                schema: "Security",
                table: "AspNetUsers",
                column: "UserType");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_AspNetRoles_RoleId",
                schema: "Security",
                table: "ApplicationRole",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Security",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Security",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Security",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Security",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Security",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Security",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureTypeRolePrivilege_AspNetRoles_RoleId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAppRoleMapping_AspNetRoles_RoleId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAppRoleMapping_AspNetUsers_UserId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
