using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class RemoveSocRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SocietyUser_SocietyId",
                schema: "Security",
                table: "SocietyUser",
                column: "SocietyId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocietyUser_Society_SocietyId",
                schema: "Security",
                table: "SocietyUser");

            migrationBuilder.DropIndex(
                name: "IX_SocietyUser_SocietyId",
                schema: "Security",
                table: "SocietyUser");
        }
    }
}
