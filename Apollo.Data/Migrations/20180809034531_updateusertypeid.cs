using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class updateusertypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_UserType_UserType",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_UserType",
                schema: "Security",
                table: "User");

            migrationBuilder.EnsureSchema(
                name: "Society");

            migrationBuilder.RenameColumn(
                name: "UserType",
                schema: "Security",
                table: "User",
                newName: "UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserType",
                schema: "Security",
                table: "User",
                newName: "IX_User_UserTypeId");

            migrationBuilder.RenameColumn(
                name: "UserType",
                schema: "Security",
                table: "Role",
                newName: "UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Role_UserType",
                schema: "Security",
                table: "Role",
                newName: "IX_Role_UserTypeId");

            migrationBuilder.CreateTable(
                name: "Society",
                schema: "Society",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    PinCode = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AdditionalPhoneNumber = table.Column<string>(nullable: true),
                    ParentSocietyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Society", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Society_Area_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "MasterData",
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Society_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "MasterData",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Society_Society_ParentSocietyId",
                        column: x => x.ParentSocietyId,
                        principalSchema: "Society",
                        principalTable: "Society",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Society_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "MasterData",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Society_AreaId",
                schema: "Society",
                table: "Society",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Society_CityId",
                schema: "Society",
                table: "Society",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Society_ParentSocietyId",
                schema: "Society",
                table: "Society",
                column: "ParentSocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Society_StateId",
                schema: "Society",
                table: "Society",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_UserType_UserTypeId",
                schema: "Security",
                table: "Role",
                column: "UserTypeId",
                principalSchema: "Security",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_UserTypeId",
                schema: "Security",
                table: "User",
                column: "UserTypeId",
                principalSchema: "Security",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_UserType_UserTypeId",
                schema: "Security",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_UserTypeId",
                schema: "Security",
                table: "User");

            migrationBuilder.DropTable(
                name: "Society",
                schema: "Society");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                schema: "Security",
                table: "User",
                newName: "UserType");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserTypeId",
                schema: "Security",
                table: "User",
                newName: "IX_User_UserType");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                schema: "Security",
                table: "Role",
                newName: "UserType");

            migrationBuilder.RenameIndex(
                name: "IX_Role_UserTypeId",
                schema: "Security",
                table: "Role",
                newName: "IX_Role_UserType");

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
        }
    }
}
