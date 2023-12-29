using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Migrations
{
    /// <inheritdoc />
    public partial class NewSchedulingColumns : Migration
    {
/// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AddColumn<DateTime>(
name: "duration",
table: "services_offered",
type: "datetime2",
nullable: false,
defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

    migrationBuilder.CreateTable(
name: "company_opening_hours",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    company_id = table.Column<int>(type: "int", nullable: false),
    day_of_week = table.Column<int>(type: "int", nullable: false),
    opening_hour = table.Column<DateTime>(type: "datetime2", nullable: false),
    closing_hour = table.Column<DateTime>(type: "datetime2", nullable: false),
    status = table.Column<int>(type: "int", nullable: false),
    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
},
constraints: table =>
{
    table.PrimaryKey("PK_company_opening_hours", x => x.id);
    table.ForeignKey(
name: "FK_company_opening_hours_companies_company_id",
column: x => x.company_id,
principalTable: "companies",
principalColumn: "id",
onDelete: ReferentialAction.Cascade);
});

    migrationBuilder.CreateIndex(
name: "IX_services_offered_company_id",
table: "services_offered",
column: "company_id");

    migrationBuilder.CreateIndex(
name: "IX_company_opening_hours_company_id",
table: "company_opening_hours",
column: "company_id");

    migrationBuilder.AddForeignKey(
name: "FK_services_offered_companies_company_id",
table: "services_offered",
column: "company_id",
principalTable: "companies",
principalColumn: "id",
onDelete: ReferentialAction.Cascade);
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropForeignKey(
name: "FK_services_offered_companies_company_id",
table: "services_offered");

    migrationBuilder.DropTable(
name: "company_opening_hours");

    migrationBuilder.DropIndex(
name: "IX_services_offered_company_id",
table: "services_offered");

    migrationBuilder.DropColumn(
name: "duration",
table: "services_offered");
}
    }
}
