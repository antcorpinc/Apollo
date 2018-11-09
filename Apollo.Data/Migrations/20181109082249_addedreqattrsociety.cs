using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class addedreqattrsociety : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Society",
                table: "Society",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Society",
                table: "Society",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Society",
                table: "Society",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "Society",
                table: "Society",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Society",
                table: "Society",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Society",
                table: "Flat",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Society",
                table: "Flat",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Society",
                table: "Flat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "Society",
                table: "Flat",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Society",
                table: "Flat",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Society",
                table: "Building",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Society",
                table: "Building",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Society",
                table: "Building",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "Society",
                table: "Building",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "Society",
                table: "Building",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Security",
                table: "User",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Society",
                table: "Society");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Society",
                table: "Society");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Society",
                table: "Society");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Society",
                table: "Society");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Society",
                table: "Society");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Society",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Society",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Society",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Society",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Society",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Society",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Society",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Society",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Society",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "Society",
                table: "Building");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Security",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
