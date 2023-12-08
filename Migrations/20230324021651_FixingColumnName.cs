using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class FixingColumnName : Migration
    {
/// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AddColumn<int>(
name: "services_offered_id",
table: "schedulings",
type: "int",
nullable: false,
defaultValue: 0);

    migrationBuilder.CreateIndex(
name: "IX_schedulings_services_offered_id",
table: "schedulings",
column: "services_offered_id");

    migrationBuilder.AddForeignKey(
name: "FK_schedulings_services_offered_services_offered_id",
table: "schedulings",
column: "services_offered_id",
principalTable: "services_offered",
principalColumn: "id",
onDelete: ReferentialAction.Cascade);
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropForeignKey(
name: "FK_schedulings_services_offered_services_offered_id",
table: "schedulings");

    migrationBuilder.DropIndex(
name: "IX_schedulings_services_offered_id",
table: "schedulings");

    migrationBuilder.DropColumn(
name: "services_offered_id",
table: "schedulings");
}
    }
}
