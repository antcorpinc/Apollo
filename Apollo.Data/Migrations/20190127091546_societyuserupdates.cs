using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class societyuserupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocietyUser_Society_SocietyId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropIndex(
                name: "IX_SocietyUser_UserId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.CreateIndex(
                name: "IX_SocietyUser_BuildingId",
                schema: "Security",
                table: "SocietyUser",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_SocietyUser_UserId",
                schema: "Security",
                table: "SocietyUser",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocietyUser_Building_BuildingId",
                schema: "Security",
                table: "SocietyUser",
                column: "BuildingId",
                principalSchema: "Society",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocietyUser_Society_SocietyId",
                schema: "Security",
                table: "SocietyUser",
                column: "SocietyId",
                principalSchema: "Society",
                principalTable: "Society",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocietyUser_Building_BuildingId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SocietyUser_Society_SocietyId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropIndex(
                name: "IX_SocietyUser_BuildingId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropIndex(
                name: "IX_SocietyUser_UserId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.CreateIndex(
                name: "IX_SocietyUser_UserId",
                schema: "Security",
                table: "SocietyUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocietyUser_Society_SocietyId",
                schema: "Security",
                table: "SocietyUser",
                column: "SocietyId",
                principalSchema: "Society",
                principalTable: "Society",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
