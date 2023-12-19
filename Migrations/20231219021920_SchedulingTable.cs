using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class SchedulingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "companies_services_offered",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 733, DateTimeKind.Local).AddTicks(8405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "companies_services_offered",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 733, DateTimeKind.Local).AddTicks(7916),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "companies_opening_hours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 733, DateTimeKind.Local).AddTicks(5145),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 17, 19, 1, 49, 410, DateTimeKind.Local).AddTicks(2034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "companies_opening_hours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 733, DateTimeKind.Local).AddTicks(4560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 17, 19, 1, 49, 410, DateTimeKind.Local).AddTicks(1054));

            migrationBuilder.CreateTable(
                name: "schedulings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    scheduled_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    services_offered_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 734, DateTimeKind.Local).AddTicks(2442)),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 734, DateTimeKind.Local).AddTicks(2978))
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
                        name: "FK_schedulings_companies_services_offered_services_offered_id",
                        column: x => x.services_offered_id,
                        principalTable: "companies_services_offered",
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

            migrationBuilder.CreateIndex(
                name: "IX_schedulings_services_offered_id",
                table: "schedulings",
                column: "services_offered_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schedulings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "companies_services_offered",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 733, DateTimeKind.Local).AddTicks(8405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "companies_services_offered",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 733, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "companies_opening_hours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 17, 19, 1, 49, 410, DateTimeKind.Local).AddTicks(2034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 733, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "companies_opening_hours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 17, 19, 1, 49, 410, DateTimeKind.Local).AddTicks(1054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 23, 19, 20, 733, DateTimeKind.Local).AddTicks(4560));
        }
    }
}
