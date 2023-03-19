using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Schedulings : Migration
    {
***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Up(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.RenameColumn(
***REMOVED******REMOVED***name: "CNPJ",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***newName: "cnpj");

***REMOVED***    migrationBuilder.CreateTable(
***REMOVED******REMOVED***name: "schedulings",
***REMOVED******REMOVED***columns: table => new
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    id = table.Column<int>(type: "int", nullable: false)
***REMOVED******REMOVED******REMOVED***.Annotation("SqlServer:Identity", "1, 1"),
***REMOVED******REMOVED***    company_id = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    customer_id = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    scheduled_date = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    status = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
***REMOVED******REMOVED***},
***REMOVED******REMOVED***constraints: table =>
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    table.PrimaryKey("PK_schedulings", x => x.id);
***REMOVED******REMOVED***    table.ForeignKey(
***REMOVED******REMOVED******REMOVED***name: "FK_schedulings_companies_company_id",
***REMOVED******REMOVED******REMOVED***column: x => x.company_id,
***REMOVED******REMOVED******REMOVED***principalTable: "companies",
***REMOVED******REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED******REMOVED***onDelete: ReferentialAction.Restrict);
***REMOVED******REMOVED***    table.ForeignKey(
***REMOVED******REMOVED******REMOVED***name: "FK_schedulings_users_customer_id",
***REMOVED******REMOVED******REMOVED***column: x => x.customer_id,
***REMOVED******REMOVED******REMOVED***principalTable: "users",
***REMOVED******REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED******REMOVED***onDelete: ReferentialAction.Restrict);
***REMOVED******REMOVED***});

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_schedulings_company_id",
***REMOVED******REMOVED***table: "schedulings",
***REMOVED******REMOVED***column: "company_id");

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_schedulings_customer_id",
***REMOVED******REMOVED***table: "schedulings",
***REMOVED******REMOVED***column: "customer_id");
***REMOVED***}

***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Down(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.DropTable(
***REMOVED******REMOVED***name: "schedulings");

***REMOVED***    migrationBuilder.RenameColumn(
***REMOVED******REMOVED***name: "cnpj",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***newName: "cnpj");
***REMOVED***}
    }
}
