using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Web.Migrations
{
    public partial class BorowerBookDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "BorrowerBook",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "BorrowerBook",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "BorrowerBook");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "BorrowerBook");
        }
    }
}
