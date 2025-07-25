using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedxxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_Properties_PropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PendingPropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions",
                column: "PendingPropertyId",
                principalTable: "PendingProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDescriptions_Properties_PropertyId",
                table: "PolicyDescriptions",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_Properties_PropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PendingPropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions",
                column: "PendingPropertyId",
                principalTable: "PendingProperties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDescriptions_Properties_PropertyId",
                table: "PolicyDescriptions",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
