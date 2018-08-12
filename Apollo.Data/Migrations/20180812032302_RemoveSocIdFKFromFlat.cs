using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class RemoveSocIdFKFromFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocietyUser_Role_RoleId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropIndex(
                name: "IX_SocietyUser_RoleId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                schema: "Security",
                table: "SocietyUser",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FlatId",
                schema: "Security",
                table: "SocietyUser",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Building",
                schema: "Society",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SocietyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_Society_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Society",
                        principalTable: "Society",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                schema: "Society",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SocietyId = table.Column<Guid>(nullable: false),
                    BuildingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flat_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "Society",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Building_SocietyId",
                schema: "Society",
                table: "Building",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_BuildingId",
                schema: "Society",
                table: "Flat",
                column: "BuildingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flat",
                schema: "Society");

            migrationBuilder.DropTable(
                name: "Building",
                schema: "Society");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropColumn(
                name: "FlatId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                schema: "Security",
                table: "SocietyUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocietyUser_RoleId",
                schema: "Security",
                table: "SocietyUser",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocietyUser_Role_RoleId",
                schema: "Security",
                table: "SocietyUser",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
