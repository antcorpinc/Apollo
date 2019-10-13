using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class addingfeaturepermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddAccess",
                schema: "Security",
                table: "Feature",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApproveAccess",
                schema: "Security",
                table: "Feature",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteAccess",
                schema: "Security",
                table: "Feature",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EditAccess",
                schema: "Security",
                table: "Feature",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMenuRequired",
                schema: "Security",
                table: "Feature",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                schema: "Security",
                table: "Feature",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ViewAccess",
                schema: "Security",
                table: "Feature",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddAccess",
                schema: "Security",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "ApproveAccess",
                schema: "Security",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "DeleteAccess",
                schema: "Security",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "EditAccess",
                schema: "Security",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "IsMenuRequired",
                schema: "Security",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "IsRequired",
                schema: "Security",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "ViewAccess",
                schema: "Security",
                table: "Feature");
        }
    }
}
