using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class FixingColumnName : Migration
    {
***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Up(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.AddColumn<int>(
***REMOVED******REMOVED***name: "services_offered_id",
***REMOVED******REMOVED***table: "schedulings",
***REMOVED******REMOVED***type: "int",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***defaultValue: 0);

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_schedulings_services_offered_id",
***REMOVED******REMOVED***table: "schedulings",
***REMOVED******REMOVED***column: "services_offered_id");

***REMOVED***    migrationBuilder.AddForeignKey(
***REMOVED******REMOVED***name: "FK_schedulings_services_offered_services_offered_id",
***REMOVED******REMOVED***table: "schedulings",
***REMOVED******REMOVED***column: "services_offered_id",
***REMOVED******REMOVED***principalTable: "services_offered",
***REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED***onDelete: ReferentialAction.Cascade);
***REMOVED***}

***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Down(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.DropForeignKey(
***REMOVED******REMOVED***name: "FK_schedulings_services_offered_services_offered_id",
***REMOVED******REMOVED***table: "schedulings");

***REMOVED***    migrationBuilder.DropIndex(
***REMOVED******REMOVED***name: "IX_schedulings_services_offered_id",
***REMOVED******REMOVED***table: "schedulings");

***REMOVED***    migrationBuilder.DropColumn(
***REMOVED******REMOVED***name: "services_offered_id",
***REMOVED******REMOVED***table: "schedulings");
***REMOVED***}
    }
}
