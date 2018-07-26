using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Web.Migrations
{
    public partial class BorrowMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Movies_MovieId",
                table: "BorrowedBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBooks_MovieId",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "BorrowedBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "BorrowedBooks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_MovieId",
                table: "BorrowedBooks",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Movies_MovieId",
                table: "BorrowedBooks",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
