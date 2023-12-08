using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
/// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.CreateTable(
name: "users",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
},
constraints: table =>
{
    table.PrimaryKey("PK_users", x => x.id);
});

    migrationBuilder.CreateTable(
name: "companies",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
    user_id = table.Column<int>(type: "int", nullable: false),
    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
},
constraints: table =>
{
    table.PrimaryKey("PK_companies", x => x.id);
    table.ForeignKey(
name: "FK_companies_users_user_id",
column: x => x.user_id,
principalTable: "users",
principalColumn: "id",
onDelete: ReferentialAction.Restrict);
});

    migrationBuilder.CreateTable(
name: "schedulings",
columns: table => new
{
    id = table.Column<int>(type: "int", nullable: false)
.Annotation("SqlServer:Identity", "1, 1"),
    company_id = table.Column<int>(type: "int", nullable: false),
    customer_id = table.Column<int>(type: "int", nullable: false),
    scheduled_date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
onDelete: ReferentialAction.Restrict,
onUpdate: ReferentialAction.Restrict);
    table.ForeignKey(
name: "FK_schedulings_users_customer_id",
column: x => x.customer_id,
principalTable: "users",
principalColumn: "id",
onDelete: ReferentialAction.Restrict,
onUpdate: ReferentialAction.Restrict);
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
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropTable(
name: "schedulings");

    migrationBuilder.DropTable(
name: "companies");

    migrationBuilder.DropTable(
name: "users");
}
    }
}
