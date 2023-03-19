using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgendamentos.Migrations
{
    /// <inheritdoc />
    public partial class Add_Image_Company : Migration
    {
***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Up(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.AddColumn<string>(
***REMOVED******REMOVED***name: "image",
***REMOVED******REMOVED***table: "companies",
***REMOVED******REMOVED***type: "nvarchar(max)",
***REMOVED******REMOVED***nullable: true);
***REMOVED***}

***REMOVED***/// <inheritdoc />
***REMOVED***protected override void Down(MigrationBuilder migrationBuilder)
***REMOVED***{
***REMOVED***    migrationBuilder.DropColumn(
***REMOVED******REMOVED***name: "image",
***REMOVED******REMOVED***table: "companies");
***REMOVED***}
    }
}
