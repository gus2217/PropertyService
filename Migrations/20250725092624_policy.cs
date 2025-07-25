using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class policy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.AlterColumn<long>(
                name: "PendingPropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "PendingPolicyDescriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false),
                    PendingPropertyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingPolicyDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendingPolicyDescriptions_PendingProperties_PendingProperty~",
                        column: x => x.PendingPropertyId,
                        principalTable: "PendingProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PendingPolicyDescriptions_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDescriptions_PropertyId",
                table: "PolicyDescriptions",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingPolicyDescriptions_PendingPropertyId",
                table: "PendingPolicyDescriptions",
                column: "PendingPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingPolicyDescriptions_PolicyId",
                table: "PendingPolicyDescriptions",
                column: "PolicyId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_Properties_PropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropTable(
                name: "PendingPolicyDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PolicyDescriptions_PropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "PolicyDescriptions");

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
        }
    }
}
