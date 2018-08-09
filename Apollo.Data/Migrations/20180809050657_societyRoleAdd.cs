using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class societyRoleAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SocietyId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeatureTypeRolePrivilege_SocietyId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                column: "SocietyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureTypeRolePrivilege_Society_SocietyId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                column: "SocietyId",
                principalSchema: "Society",
                principalTable: "Society",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureTypeRolePrivilege_Society_SocietyId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege");

            migrationBuilder.DropIndex(
                name: "IX_FeatureTypeRolePrivilege_SocietyId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege");

            migrationBuilder.DropColumn(
                name: "SocietyId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege");
        }
    }
}
