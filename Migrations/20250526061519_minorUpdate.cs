using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class minorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndoorFeaturesProperty_IndoorFeatures_IdoorFeaturesId",
                table: "IndoorFeaturesProperty");

            migrationBuilder.RenameColumn(
                name: "IdoorFeaturesId",
                table: "IndoorFeaturesProperty",
                newName: "IndoorFeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndoorFeaturesProperty_IndoorFeatures_IndoorFeaturesId",
                table: "IndoorFeaturesProperty",
                column: "IndoorFeaturesId",
                principalTable: "IndoorFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndoorFeaturesProperty_IndoorFeatures_IndoorFeaturesId",
                table: "IndoorFeaturesProperty");

            migrationBuilder.RenameColumn(
                name: "IndoorFeaturesId",
                table: "IndoorFeaturesProperty",
                newName: "IdoorFeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndoorFeaturesProperty_IndoorFeatures_IdoorFeaturesId",
                table: "IndoorFeaturesProperty",
                column: "IdoorFeaturesId",
                principalTable: "IndoorFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
