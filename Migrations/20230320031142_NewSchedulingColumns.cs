using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class NewSchedulingColumns : Migration
    {
***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Up(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.AddColumn<DateTime>(
***REMOVED******REMOVED***name: "duration",
***REMOVED******REMOVED***table: "services_offered",
***REMOVED******REMOVED***type: "datetime2",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

***REMOVED***    migrationBuilder.CreateTable(
***REMOVED******REMOVED***name: "company_opening_hours",
***REMOVED******REMOVED***columns: table => new
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    id = table.Column<int>(type: "int", nullable: false)
***REMOVED******REMOVED******REMOVED***.Annotation("SqlServer:Identity", "1, 1"),
***REMOVED******REMOVED***    company_id = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    day_of_week = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    opening_hour = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    closing_hour = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    status = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
***REMOVED******REMOVED***},
***REMOVED******REMOVED***constraints: table =>
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    table.PrimaryKey("PK_company_opening_hours", x => x.id);
***REMOVED******REMOVED***    table.ForeignKey(
***REMOVED******REMOVED******REMOVED***name: "FK_company_opening_hours_companies_company_id",
***REMOVED******REMOVED******REMOVED***column: x => x.company_id,
***REMOVED******REMOVED******REMOVED***principalTable: "companies",
***REMOVED******REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED******REMOVED***onDelete: ReferentialAction.Cascade);
***REMOVED******REMOVED***});

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_services_offered_company_id",
***REMOVED******REMOVED***table: "services_offered",
***REMOVED******REMOVED***column: "company_id");

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_company_opening_hours_company_id",
***REMOVED******REMOVED***table: "company_opening_hours",
***REMOVED******REMOVED***column: "company_id");

***REMOVED***    migrationBuilder.AddForeignKey(
***REMOVED******REMOVED***name: "FK_services_offered_companies_company_id",
***REMOVED******REMOVED***table: "services_offered",
***REMOVED******REMOVED***column: "company_id",
***REMOVED******REMOVED***principalTable: "companies",
***REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED***onDelete: ReferentialAction.Cascade);
***REMOVED***}

***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Down(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.DropForeignKey(
***REMOVED******REMOVED***name: "FK_services_offered_companies_company_id",
***REMOVED******REMOVED***table: "services_offered");

***REMOVED***    migrationBuilder.DropTable(
***REMOVED******REMOVED***name: "company_opening_hours");

***REMOVED***    migrationBuilder.DropIndex(
***REMOVED******REMOVED***name: "IX_services_offered_company_id",
***REMOVED******REMOVED***table: "services_offered");

***REMOVED***    migrationBuilder.DropColumn(
***REMOVED******REMOVED***name: "duration",
***REMOVED******REMOVED***table: "services_offered");
***REMOVED***}
    }
}
