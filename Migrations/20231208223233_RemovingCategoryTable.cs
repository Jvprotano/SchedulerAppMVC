using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class RemovingCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "company_opening_hours");

            migrationBuilder.DropTable(
                name: "company_owners");

            migrationBuilder.DropTable(
                name: "schedulings");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "companies",
                newName: "image_url");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "services_offered",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "companies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "companies",
                newName: "image");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "services_offered",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "companies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "cities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_opening_hours",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    closing_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    day_of_week = table.Column<int>(type: "int", nullable: false),
                    opening_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "company_owners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
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
                name: "schedulings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    services_offered_id = table.Column<int>(type: "int", nullable: false),
                    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    scheduled_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_schedulings_services_offered_services_offered_id",
                        column: x => x.services_offered_id,
                        principalTable: "services_offered",
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
                name: "IX_company_opening_hours_company_id",
                table: "company_opening_hours",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_owners_company_id",
                table: "company_owners",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_owners_user_id",
                table: "company_owners",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedulings_company_id",
                table: "schedulings",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedulings_customer_id",
                table: "schedulings",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedulings_services_offered_id",
                table: "schedulings",
                column: "services_offered_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_city_id",
                table: "users",
                column: "city_id");
        }
    }
}
