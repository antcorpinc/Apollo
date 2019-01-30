using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class societyuserforflat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SocietyUser_FlatId",
                schema: "Security",
                table: "SocietyUser",
                column: "FlatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocietyUser_Flat_FlatId",
                schema: "Security",
                table: "SocietyUser",
                column: "FlatId",
                principalSchema: "Society",
                principalTable: "Flat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocietyUser_Flat_FlatId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropIndex(
                name: "IX_SocietyUser_FlatId",
                schema: "Security",
                table: "SocietyUser");
        }
    }
}
