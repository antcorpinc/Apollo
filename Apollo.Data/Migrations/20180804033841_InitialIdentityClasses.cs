using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class InitialIdentityClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Order = table.Column<int>(nullable: true),
                    ParentFeatureId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature_Feature_ParentFeatureId",
                        column: x => x.ParentFeatureId,
                        principalSchema: "Security",
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFeature",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    FeatureTypeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFeature_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "Security",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationFeature_Feature_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalSchema: "Security",
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
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
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(maxLength: 256, nullable: true),
                    PhotoUrl = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ApplicationRole",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationRole_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "Security",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationRole_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureTypeRolePrivilege",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FeatureTypeId = table.Column<int>(nullable: false),
                    Privileges = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureTypeRolePrivilege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureTypeRolePrivilege_Feature_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalSchema: "Security",
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureTypeRolePrivilege_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAppRoleMapping",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAppRoleMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAppRoleMapping_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "Security",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAppRoleMapping_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAppRoleMapping_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFeature_ApplicationId",
                schema: "Security",
                table: "ApplicationFeature",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFeature_FeatureTypeId",
                schema: "Security",
                table: "ApplicationFeature",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRole_ApplicationId",
                schema: "Security",
                table: "ApplicationRole",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRole_RoleId",
                schema: "Security",
                table: "ApplicationRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Security",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                name: "IX_AspNetUserClaims_UserId",
                schema: "Security",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Security",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Security",
                table: "AspNetUserRoles",
                column: "RoleId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Feature_ParentFeatureId",
                schema: "Security",
                table: "Feature",
                column: "ParentFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureTypeRolePrivilege_FeatureTypeId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureTypeRolePrivilege_RoleId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAppRoleMapping_ApplicationId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAppRoleMapping_RoleId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAppRoleMapping_UserId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationFeature",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ApplicationRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "FeatureTypeRolePrivilege",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserAppRoleMapping",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Feature",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Application",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "Security");
        }
    }
}
