using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class Adding_New_Tables : Migration
    {
/// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropForeignKey(
name: "FK_companies_users_user_id",
table: "companies");

    migrationBuilder.DropTable(
name: "schedulings");

    migrationBuilder.DropIndex(
name: "IX_companies_user_id",
table: "companies");

    migrationBuilder.RenameColumn(
name: "user_id",
table: "companies",
newName: "status");

    migrationBuilder.AddColumn<int>(
name: "status",
table: "users",
type: "int",
nullable: false,
defaultValue: 0);

    migrationBuilder.AddColumn<string>(
name: "CNPJ",
table: "companies",
type: "nvarchar(max)",
nullable: true);

    migrationBuilder.AddColumn<string>(
name: "description",
table: "companies",
type: "nvarchar(max)",
nullable: false,
defaultValue: "");

    migrationBuilder.CreateTable(
name: "categories",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
    status = table.Column<int>(type: "int", nullable: false),
    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
},
constraints: table =>
{
    table.PrimaryKey("PK_categories", x => x.id);
});

    migrationBuilder.CreateTable(
name: "company_owners",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    company_id = table.Column<int>(type: "int", nullable: false),
    user_id = table.Column<int>(type: "int", nullable: false),
    status = table.Column<int>(type: "int", nullable: false),
    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
},
constraints: table =>
{
    table.PrimaryKey("PK_company_owners", x => x.id);
    table.ForeignKey(
name: "FK_company_owners_companies_company_id",
column: x => x.company_id,
principalTable: "companies",
principalColumn: "id",
onDelete: ReferentialAction.Cascade);
    table.ForeignKey(
name: "FK_company_owners_users_user_id",
column: x => x.user_id,
principalTable: "users",
principalColumn: "id",
onDelete: ReferentialAction.Cascade);
});

    migrationBuilder.CreateTable(
name: "services_offered",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
    price = table.Column<float>(type: "real", nullable: false),
    company_id = table.Column<int>(type: "int", nullable: false),
    status = table.Column<int>(type: "int", nullable: false),
    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
},
constraints: table =>
{
    table.PrimaryKey("PK_services_offered", x => x.id);
});

    migrationBuilder.CreateIndex(
name: "IX_company_owners_company_id",
table: "company_owners",
column: "company_id");

    migrationBuilder.CreateIndex(
name: "IX_company_owners_user_id",
table: "company_owners",
column: "user_id");
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropTable(
name: "categories");

    migrationBuilder.DropTable(
name: "company_owners");

    migrationBuilder.DropTable(
name: "services_offered");

    migrationBuilder.DropColumn(
name: "status",
table: "users");

    migrationBuilder.DropColumn(
name: "c_n_p_j",
table: "companies");

    migrationBuilder.DropColumn(
name: "description",
table: "companies");

    migrationBuilder.RenameColumn(
name: "status",
table: "companies",
newName: "user_id");

    migrationBuilder.CreateTable(
name: "schedulings",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    company_id = table.Column<int>(type: "int", nullable: false),
    customer_id = table.Column<int>(type: "int", nullable: false),
    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    scheduled_date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
onDelete: ReferentialAction.Cascade);
    table.ForeignKey(
name: "FK_schedulings_users_customer_id",
column: x => x.customer_id,
principalTable: "users",
principalColumn: "id",
onDelete: ReferentialAction.Cascade);
});

    migrationBuilder.CreateIndex(
name: "IX_companies_user_id",
table: "companies",
column: "user_id");

    migrationBuilder.CreateIndex(
name: "IX_schedulings_company_id",
table: "schedulings",
column: "company_id");

    migrationBuilder.CreateIndex(
name: "IX_schedulings_customer_id",
table: "schedulings",
column: "customer_id");

    migrationBuilder.AddForeignKey(
name: "FK_companies_users_user_id",
table: "companies",
column: "user_id",
principalTable: "users",
principalColumn: "id",
onDelete: ReferentialAction.Restrict);
}
    }
}
