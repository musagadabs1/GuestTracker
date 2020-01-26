using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestTracker.Web.Migrations
{
    public partial class addSignInTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SignInTime",
                table: "VisitDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignInTime",
                table: "VisitDetails");
        }
    }
}
