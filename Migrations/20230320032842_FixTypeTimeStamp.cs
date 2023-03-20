using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class FixTypeTimeStamp : Migration
    {
***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Up(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.AlterColumn<TimeSpan>(
***REMOVED******REMOVED***name: "duration",
***REMOVED******REMOVED***table: "services_offered",
***REMOVED******REMOVED***type: "time",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***oldClrType: typeof(DateTime),
***REMOVED******REMOVED***oldType: "datetime2");

***REMOVED***    migrationBuilder.AlterColumn<TimeSpan>(
***REMOVED******REMOVED***name: "opening_hour",
***REMOVED******REMOVED***table: "company_opening_hours",
***REMOVED******REMOVED***type: "time",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***oldClrType: typeof(DateTime),
***REMOVED******REMOVED***oldType: "datetime2");

***REMOVED***    migrationBuilder.AlterColumn<TimeSpan>(
***REMOVED******REMOVED***name: "closing_hour",
***REMOVED******REMOVED***table: "company_opening_hours",
***REMOVED******REMOVED***type: "time",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***oldClrType: typeof(DateTime),
***REMOVED******REMOVED***oldType: "datetime2");
***REMOVED***}

***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Down(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.AlterColumn<DateTime>(
***REMOVED******REMOVED***name: "duration",
***REMOVED******REMOVED***table: "services_offered",
***REMOVED******REMOVED***type: "datetime2",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***oldClrType: typeof(TimeSpan),
***REMOVED******REMOVED***oldType: "time");

***REMOVED***    migrationBuilder.AlterColumn<DateTime>(
***REMOVED******REMOVED***name: "opening_hour",
***REMOVED******REMOVED***table: "company_opening_hours",
***REMOVED******REMOVED***type: "datetime2",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***oldClrType: typeof(TimeSpan),
***REMOVED******REMOVED***oldType: "time");

***REMOVED***    migrationBuilder.AlterColumn<DateTime>(
***REMOVED******REMOVED***name: "closing_hour",
***REMOVED******REMOVED***table: "company_opening_hours",
***REMOVED******REMOVED***type: "datetime2",
***REMOVED******REMOVED***nullable: false,
***REMOVED******REMOVED***oldClrType: typeof(TimeSpan),
***REMOVED******REMOVED***oldType: "time");
***REMOVED***}
    }
}
