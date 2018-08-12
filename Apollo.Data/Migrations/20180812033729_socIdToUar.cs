using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class socIdToUar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SocietyId",
                schema: "Security",
                table: "UserAppRoleMapping",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAppRoleMapping_SocietyId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "SocietyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAppRoleMapping_Society_SocietyId",
                schema: "Security",
                table: "UserAppRoleMapping",
                column: "SocietyId",
                principalSchema: "Society",
                principalTable: "Society",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAppRoleMapping_Society_SocietyId",
                schema: "Security",
                table: "UserAppRoleMapping");

            migrationBuilder.DropIndex(
                name: "IX_UserAppRoleMapping_SocietyId",
                schema: "Security",
                table: "UserAppRoleMapping");

            migrationBuilder.DropColumn(
                name: "SocietyId",
                schema: "Security",
                table: "UserAppRoleMapping");
        }
    }
}
