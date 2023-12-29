using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Migrations
{
    /// <inheritdoc />
    public partial class FixTypeTimeStamp : Migration
    {
/// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AlterColumn<TimeSpan>(
name: "duration",
table: "services_offered",
type: "time",
nullable: false,
oldClrType: typeof(DateTime),
oldType: "datetime2");

    migrationBuilder.AlterColumn<TimeSpan>(
name: "opening_hour",
table: "company_opening_hours",
type: "time",
nullable: false,
oldClrType: typeof(DateTime),
oldType: "datetime2");

    migrationBuilder.AlterColumn<TimeSpan>(
name: "closing_hour",
table: "company_opening_hours",
type: "time",
nullable: false,
oldClrType: typeof(DateTime),
oldType: "datetime2");
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AlterColumn<DateTime>(
name: "duration",
table: "services_offered",
type: "datetime2",
nullable: false,
oldClrType: typeof(TimeSpan),
oldType: "time");

    migrationBuilder.AlterColumn<DateTime>(
name: "opening_hour",
table: "company_opening_hours",
type: "datetime2",
nullable: false,
oldClrType: typeof(TimeSpan),
oldType: "time");

    migrationBuilder.AlterColumn<DateTime>(
name: "closing_hour",
table: "company_opening_hours",
type: "datetime2",
nullable: false,
oldClrType: typeof(TimeSpan),
oldType: "time");
}
    }
}
