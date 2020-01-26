using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestTracker.Web.Migrations
{
    public partial class removedNumberOfVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfVisit",
                table: "VisitDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfVisit",
                table: "VisitDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
