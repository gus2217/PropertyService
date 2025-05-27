using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedFeatureToProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralFeaturesProperty",
                columns: table => new
                {
                    GeneralFeaturesId = table.Column<long>(type: "bigint", nullable: false),
                    PropertiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralFeaturesProperty", x => new { x.GeneralFeaturesId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_GeneralFeaturesProperty_GeneralFeatures_GeneralFeaturesId",
                        column: x => x.GeneralFeaturesId,
                        principalTable: "GeneralFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralFeaturesProperty_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralFeaturesProperty_PropertiesId",
                table: "GeneralFeaturesProperty",
                column: "PropertiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralFeaturesProperty");

            migrationBuilder.DropTable(
                name: "GeneralFeatures");
        }
    }
}
