using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class Adding_New_Tables : Migration
    {
***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Up(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.DropForeignKey(
***REMOVED******REMOVED***name: "FK_companies_users_user_id",
***REMOVED******REMOVED***table: "companies");

***REMOVED***    migrationBuilder.DropTable(
***REMOVED******REMOVED***name: "schedulings");

***REMOVED***    migrationBuilder.DropIndex(
***REMOVED******REMOVED***name: "IX_companies_user_id",
***REMOVED******REMOVED***table: "companies");

***REMOVED***    migrationBuilder.RenameColumn(
***REMOVED******REMOVED***name: "user_id",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***newName: "status");

***REMOVED***    migrationBuilder.AddColumn<int>(
***REMOVED******REMOVED***name: "status",
***REMOVED******REMOVED***table: "users",
***REMOVED******REMOVED***type: "int",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***defaultValue: 0);

***REMOVED***    migrationBuilder.AddColumn<string>(
***REMOVED******REMOVED***name: "CNPJ",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***type: "nvarchar(max)",
***REMOVED******REMOVED***nullable: true);

***REMOVED***    migrationBuilder.AddColumn<string>(
***REMOVED******REMOVED***name: "description",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***type: "nvarchar(max)",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***defaultValue: "");

***REMOVED***    migrationBuilder.CreateTable(
***REMOVED******REMOVED***name: "categories",
***REMOVED******REMOVED***columns: table => new
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    id = table.Column<int>(type: "int", nullable: false)
***REMOVED******REMOVED******REMOVED***.Annotation("SqlServer:Identity", "1, 1"),
***REMOVED******REMOVED***    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
***REMOVED******REMOVED***    status = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
***REMOVED******REMOVED***},
***REMOVED******REMOVED***constraints: table =>
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    table.PrimaryKey("PK_categories", x => x.id);
***REMOVED******REMOVED***});

***REMOVED***    migrationBuilder.CreateTable(
***REMOVED******REMOVED***name: "company_owners",
***REMOVED******REMOVED***columns: table => new
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    id = table.Column<int>(type: "int", nullable: false)
***REMOVED******REMOVED******REMOVED***.Annotation("SqlServer:Identity", "1, 1"),
***REMOVED******REMOVED***    company_id = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    user_id = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    status = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
***REMOVED******REMOVED***},
***REMOVED******REMOVED***constraints: table =>
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    table.PrimaryKey("PK_company_owners", x => x.id);
***REMOVED******REMOVED***    table.ForeignKey(
***REMOVED******REMOVED******REMOVED***name: "FK_company_owners_companies_company_id",
***REMOVED******REMOVED******REMOVED***column: x => x.company_id,
***REMOVED******REMOVED******REMOVED***principalTable: "companies",
***REMOVED******REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED******REMOVED***onDelete: ReferentialAction.Cascade);
***REMOVED******REMOVED***    table.ForeignKey(
***REMOVED******REMOVED******REMOVED***name: "FK_company_owners_users_user_id",
***REMOVED******REMOVED******REMOVED***column: x => x.user_id,
***REMOVED******REMOVED******REMOVED***principalTable: "users",
***REMOVED******REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED******REMOVED***onDelete: ReferentialAction.Cascade);
***REMOVED******REMOVED***});

***REMOVED***    migrationBuilder.CreateTable(
***REMOVED******REMOVED***name: "services_offered",
***REMOVED******REMOVED***columns: table => new
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    id = table.Column<int>(type: "int", nullable: false)
***REMOVED******REMOVED******REMOVED***.Annotation("SqlServer:Identity", "1, 1"),
***REMOVED******REMOVED***    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
***REMOVED******REMOVED***    price = table.Column<float>(type: "real", nullable: false),
***REMOVED******REMOVED***    company_id = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    status = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
***REMOVED******REMOVED***},
***REMOVED******REMOVED***constraints: table =>
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    table.PrimaryKey("PK_services_offered", x => x.id);
***REMOVED******REMOVED***});

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_company_owners_company_id",
***REMOVED******REMOVED***table: "company_owners",
***REMOVED******REMOVED***column: "company_id");

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_company_owners_user_id",
***REMOVED******REMOVED***table: "company_owners",
***REMOVED******REMOVED***column: "user_id");
***REMOVED***}

***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Down(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.DropTable(
***REMOVED******REMOVED***name: "categories");

***REMOVED***    migrationBuilder.DropTable(
***REMOVED******REMOVED***name: "company_owners");

***REMOVED***    migrationBuilder.DropTable(
***REMOVED******REMOVED***name: "services_offered");

***REMOVED***    migrationBuilder.DropColumn(
***REMOVED******REMOVED***name: "status",
***REMOVED******REMOVED***table: "users");

***REMOVED***    migrationBuilder.DropColumn(
***REMOVED******REMOVED***name: "c_n_p_j",
***REMOVED******REMOVED***table: "companies");

***REMOVED***    migrationBuilder.DropColumn(
***REMOVED******REMOVED***name: "description",
***REMOVED******REMOVED***table: "companies");

***REMOVED***    migrationBuilder.RenameColumn(
***REMOVED******REMOVED***name: "status",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***newName: "user_id");

***REMOVED***    migrationBuilder.CreateTable(
***REMOVED******REMOVED***name: "schedulings",
***REMOVED******REMOVED***columns: table => new
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    id = table.Column<int>(type: "int", nullable: false)
***REMOVED******REMOVED******REMOVED***.Annotation("SqlServer:Identity", "1, 1"),
***REMOVED******REMOVED***    company_id = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    customer_id = table.Column<int>(type: "int", nullable: false),
***REMOVED******REMOVED***    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
***REMOVED******REMOVED***    scheduled_date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
***REMOVED******REMOVED******REMOVED***onDelete: ReferentialAction.Cascade);
***REMOVED******REMOVED***    table.ForeignKey(
***REMOVED******REMOVED******REMOVED***name: "FK_schedulings_users_customer_id",
***REMOVED******REMOVED******REMOVED***column: x => x.customer_id,
***REMOVED******REMOVED******REMOVED***principalTable: "users",
***REMOVED******REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED******REMOVED***onDelete: ReferentialAction.Cascade);
***REMOVED******REMOVED***});

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_companies_user_id",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***column: "user_id");

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_schedulings_company_id",
***REMOVED******REMOVED***table: "schedulings",
***REMOVED******REMOVED***column: "company_id");

***REMOVED***    migrationBuilder.CreateIndex(
***REMOVED******REMOVED***name: "IX_schedulings_customer_id",
***REMOVED******REMOVED***table: "schedulings",
***REMOVED******REMOVED***column: "customer_id");

***REMOVED***    migrationBuilder.AddForeignKey(
***REMOVED******REMOVED***name: "FK_companies_users_user_id",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***column: "user_id",
***REMOVED******REMOVED***principalTable: "users",
***REMOVED******REMOVED***principalColumn: "id",
***REMOVED******REMOVED***onDelete: ReferentialAction.Restrict);
***REMOVED***}
    }
}
