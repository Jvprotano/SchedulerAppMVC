using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Migrations
{
    /// <inheritdoc />
    public partial class ProfileBaseEntityAndCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address_number",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "postal_code",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address_number",
                table: "companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_virtual",
                table: "companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "postal_code",
                table: "companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_city_id",
                table: "users",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_city_id",
                table: "companies",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_cities_city_id",
                table: "companies",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_cities_city_id",
                table: "users",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_cities_city_id",
                table: "companies");

            migrationBuilder.DropForeignKey(
                name: "FK_users_cities_city_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropIndex(
                name: "IX_users_city_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_companies_city_id",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "address",
                table: "users");

            migrationBuilder.DropColumn(
                name: "address_number",
                table: "users");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "users");

            migrationBuilder.DropColumn(
                name: "email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "postal_code",
                table: "users");

            migrationBuilder.DropColumn(
                name: "address",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "address_number",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "email",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "is_virtual",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "postal_code",
                table: "companies");
        }
    }
}
