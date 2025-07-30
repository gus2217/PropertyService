using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatepolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PendingPropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDescriptions_PendingPropertyId",
                table: "PolicyDescriptions",
                column: "PendingPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions",
                column: "PendingPropertyId",
                principalTable: "PendingProperties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PolicyDescriptions_PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropColumn(
                name: "PendingPropertyId",
                table: "PolicyDescriptions");
        }
    }
}
