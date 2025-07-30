using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KejaHUnt_PropertiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class pendingProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PendingPropertyId",
                table: "Units",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PendingPropertyId",
                table: "PolicyDescriptions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PendingPropertyId",
                table: "OutDoorFeatures",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PendingPropertyId",
                table: "IndoorFeatures",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PendingPropertyId",
                table: "GeneralFeatures",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PendingProperties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubmittedByUserId = table.Column<string>(type: "text", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingProperties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_PendingPropertyId",
                table: "Units",
                column: "PendingPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDescriptions_PendingPropertyId",
                table: "PolicyDescriptions",
                column: "PendingPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_OutDoorFeatures_PendingPropertyId",
                table: "OutDoorFeatures",
                column: "PendingPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_IndoorFeatures_PendingPropertyId",
                table: "IndoorFeatures",
                column: "PendingPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralFeatures_PendingPropertyId",
                table: "GeneralFeatures",
                column: "PendingPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralFeatures_PendingProperties_PendingPropertyId",
                table: "GeneralFeatures",
                column: "PendingPropertyId",
                principalTable: "PendingProperties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndoorFeatures_PendingProperties_PendingPropertyId",
                table: "IndoorFeatures",
                column: "PendingPropertyId",
                principalTable: "PendingProperties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutDoorFeatures_PendingProperties_PendingPropertyId",
                table: "OutDoorFeatures",
                column: "PendingPropertyId",
                principalTable: "PendingProperties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions",
                column: "PendingPropertyId",
                principalTable: "PendingProperties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_PendingProperties_PendingPropertyId",
                table: "Units",
                column: "PendingPropertyId",
                principalTable: "PendingProperties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralFeatures_PendingProperties_PendingPropertyId",
                table: "GeneralFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_IndoorFeatures_PendingProperties_PendingPropertyId",
                table: "IndoorFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_OutDoorFeatures_PendingProperties_PendingPropertyId",
                table: "OutDoorFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyDescriptions_PendingProperties_PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_PendingProperties_PendingPropertyId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "PendingProperties");

            migrationBuilder.DropIndex(
                name: "IX_Units_PendingPropertyId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_PolicyDescriptions_PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_OutDoorFeatures_PendingPropertyId",
                table: "OutDoorFeatures");

            migrationBuilder.DropIndex(
                name: "IX_IndoorFeatures_PendingPropertyId",
                table: "IndoorFeatures");

            migrationBuilder.DropIndex(
                name: "IX_GeneralFeatures_PendingPropertyId",
                table: "GeneralFeatures");

            migrationBuilder.DropColumn(
                name: "PendingPropertyId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PendingPropertyId",
                table: "PolicyDescriptions");

            migrationBuilder.DropColumn(
                name: "PendingPropertyId",
                table: "OutDoorFeatures");

            migrationBuilder.DropColumn(
                name: "PendingPropertyId",
                table: "IndoorFeatures");

            migrationBuilder.DropColumn(
                name: "PendingPropertyId",
                table: "GeneralFeatures");
        }
    }
}
