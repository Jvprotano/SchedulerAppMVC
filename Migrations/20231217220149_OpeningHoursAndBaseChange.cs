using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Migrations
{
    /// <inheritdoc />
    public partial class OpeningHoursAndBaseChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "companies_services_offered",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "register_date",
                table: "companies_services_offered",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "companies_categories",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "register_date",
                table: "companies_categories",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "companies",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "register_date",
                table: "companies",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "cities",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "register_date",
                table: "cities",
                newName: "created_at");

            migrationBuilder.CreateTable(
                name: "companies_opening_hours",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    day_of_week = table.Column<int>(type: "int", nullable: false),
                    opening_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    closing_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 17, 19, 1, 49, 410, DateTimeKind.Local).AddTicks(1054)),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 17, 19, 1, 49, 410, DateTimeKind.Local).AddTicks(2034))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies_opening_hours", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_opening_hours_companies_company_id",
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
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    auto_generated_image = table.Column<bool>(type: "bit", nullable: false),
                    image_prompt = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "companies_owners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies_owners", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_owners_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_companies_owners_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companies_opening_hours_company_id",
                table: "companies_opening_hours",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_owners_company_id",
                table: "companies_owners",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_owners_user_id",
                table: "companies_owners",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_city_id",
                table: "users",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companies_opening_hours");

            migrationBuilder.DropTable(
                name: "companies_owners");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "companies_services_offered",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "companies_services_offered",
                newName: "register_date");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "companies_categories",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "companies_categories",
                newName: "register_date");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "companies",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "companies",
                newName: "register_date");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "cities",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "cities",
                newName: "register_date");
        }
    }
}
