using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyPolicyDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyDescriptionProperty");

            migrationBuilder.DropTable(
                name: "PolicyProperty");

            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDescriptions_PropertyId",
                table: "PolicyDescriptions",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDescriptions_Properties_PropertyId",
                table: "PolicyDescriptions",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PolicyDescriptionProperty",
                columns: table => new
                {
                    PolicyDescriptionsId = table.Column<long>(type: "bigint", nullable: false),
                    PropertiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDescriptionProperty", x => new { x.PolicyDescriptionsId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_PolicyDescriptionProperty_PolicyDescriptions_PolicyDescriptionsId",
                        column: x => x.PolicyDescriptionsId,
                        principalTable: "PolicyDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyDescriptionProperty_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyProperty",
                columns: table => new
                {
                    PoliciesId = table.Column<long>(type: "bigint", nullable: false),
                    PropertiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyProperty", x => new { x.PoliciesId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_PolicyProperty_Policies_PoliciesId",
                        column: x => x.PoliciesId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyProperty_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDescriptionProperty_PropertiesId",
                table: "PolicyDescriptionProperty",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyProperty_PropertiesId",
                table: "PolicyProperty",
                column: "PropertiesId");
        }
    }
}
