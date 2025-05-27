using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedPolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IndoorFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndoorFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutDoorFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutDoorFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndoorFeaturesProperty",
                columns: table => new
                {
                    IdoorFeaturesId = table.Column<long>(type: "bigint", nullable: false),
                    PropertiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndoorFeaturesProperty", x => new { x.IdoorFeaturesId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_IndoorFeaturesProperty_IndoorFeatures_IdoorFeaturesId",
                        column: x => x.IdoorFeaturesId,
                        principalTable: "IndoorFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndoorFeaturesProperty_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutDoorFeaturesProperty",
                columns: table => new
                {
                    OutdoorFeaturesId = table.Column<long>(type: "bigint", nullable: false),
                    PropertiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutDoorFeaturesProperty", x => new { x.OutdoorFeaturesId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_OutDoorFeaturesProperty_OutDoorFeatures_OutdoorFeaturesId",
                        column: x => x.OutdoorFeaturesId,
                        principalTable: "OutDoorFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutDoorFeaturesProperty_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyDescriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyDescriptions_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
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
                name: "IX_IndoorFeaturesProperty_PropertiesId",
                table: "IndoorFeaturesProperty",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_OutDoorFeaturesProperty_PropertiesId",
                table: "OutDoorFeaturesProperty",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDescriptions_PolicyId",
                table: "PolicyDescriptions",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyProperty_PropertiesId",
                table: "PolicyProperty",
                column: "PropertiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndoorFeaturesProperty");

            migrationBuilder.DropTable(
                name: "OutDoorFeaturesProperty");

            migrationBuilder.DropTable(
                name: "PolicyDescriptions");

            migrationBuilder.DropTable(
                name: "PolicyProperty");

            migrationBuilder.DropTable(
                name: "IndoorFeatures");

            migrationBuilder.DropTable(
                name: "OutDoorFeatures");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Properties");
        }
    }
}
