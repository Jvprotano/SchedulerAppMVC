using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Schedulings : Migration
    {
/// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.RenameColumn(
name: "CNPJ",
table: "companies",
newName: "cnpj");

    migrationBuilder.CreateTable(
name: "schedulings",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    company_id = table.Column<int>(type: "int", nullable: false),
    customer_id = table.Column<int>(type: "int", nullable: false),
    scheduled_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    status = table.Column<int>(type: "int", nullable: false),
    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
},
constraints: table =>
{
    table.PrimaryKey("PK_schedulings", x => x.id);
    table.ForeignKey(
name: "FK_schedulings_companies_company_id",
column: x => x.company_id,
principalTable: "companies",
principalColumn: "id",
onDelete: ReferentialAction.Restrict);
    table.ForeignKey(
name: "FK_schedulings_users_customer_id",
column: x => x.customer_id,
principalTable: "users",
principalColumn: "id",
onDelete: ReferentialAction.Restrict);
});

    migrationBuilder.CreateIndex(
name: "IX_schedulings_company_id",
table: "schedulings",
column: "company_id");

    migrationBuilder.CreateIndex(
name: "IX_schedulings_customer_id",
table: "schedulings",
column: "customer_id");
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropTable(
name: "schedulings");

    migrationBuilder.RenameColumn(
name: "cnpj",
table: "companies",
newName: "cnpj");
}
    }
}
