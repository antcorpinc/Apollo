using Microsoft.EntityFrameworkCore.Migrations;

namespace Apollo.Data.Migrations
{
    public partial class RefactorFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationFeature_Feature_FeatureTypeId",
                schema: "Security",
                table: "ApplicationFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureTypeRolePrivilege_Feature_FeatureTypeId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege");

            migrationBuilder.RenameColumn(
                name: "FeatureTypeId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                newName: "FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_FeatureTypeRolePrivilege_FeatureTypeId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                newName: "IX_FeatureTypeRolePrivilege_FeatureId");

            migrationBuilder.RenameColumn(
                name: "FeatureTypeId",
                schema: "Security",
                table: "ApplicationFeature",
                newName: "FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationFeature_FeatureTypeId",
                schema: "Security",
                table: "ApplicationFeature",
                newName: "IX_ApplicationFeature_FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFeature_Feature_FeatureId",
                schema: "Security",
                table: "ApplicationFeature",
                column: "FeatureId",
                principalSchema: "Security",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureTypeRolePrivilege_Feature_FeatureId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                column: "FeatureId",
                principalSchema: "Security",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationFeature_Feature_FeatureId",
                schema: "Security",
                table: "ApplicationFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureTypeRolePrivilege_Feature_FeatureId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                newName: "FeatureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FeatureTypeRolePrivilege_FeatureId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                newName: "IX_FeatureTypeRolePrivilege_FeatureTypeId");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                schema: "Security",
                table: "ApplicationFeature",
                newName: "FeatureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationFeature_FeatureId",
                schema: "Security",
                table: "ApplicationFeature",
                newName: "IX_ApplicationFeature_FeatureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFeature_Feature_FeatureTypeId",
                schema: "Security",
                table: "ApplicationFeature",
                column: "FeatureTypeId",
                principalSchema: "Security",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureTypeRolePrivilege_Feature_FeatureTypeId",
                schema: "Security",
                table: "FeatureTypeRolePrivilege",
                column: "FeatureTypeId",
                principalSchema: "Security",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
