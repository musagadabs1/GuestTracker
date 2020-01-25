using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestTracker.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitDetails",
                columns: table => new
                {
                    Visit_Detail_Id = table.Column<Guid>(nullable: false),
                    GuestName = table.Column<string>(nullable: true),
                    NumberOfVisit = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitDetails", x => x.Visit_Detail_Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Guest_Id = table.Column<Guid>(nullable: false),
                    GuestName = table.Column<string>(nullable: true),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    GuestAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PurposeOfVisit = table.Column<string>(nullable: true),
                    WhomToSee = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    Signature = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    VisitDetailId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Guest_Id);
                    table.ForeignKey(
                        name: "FK_Guests_VisitDetails_VisitDetailId",
                        column: x => x.VisitDetailId,
                        principalTable: "VisitDetails",
                        principalColumn: "Visit_Detail_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_VisitDetailId",
                table: "Guests",
                column: "VisitDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "VisitDetails");
        }
    }
}
