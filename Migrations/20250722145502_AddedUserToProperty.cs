using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserToProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Properties");
        }
    }
}
