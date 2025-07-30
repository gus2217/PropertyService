using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class finalpolicyfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_Properties_PropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PolicyDescriptions_PropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "PolicyDescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDescriptions_PropertyId",
                table: "PolicyDescriptions",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDescriptions_Properties_PropertyId",
                table: "PolicyDescriptions",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
