using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Web.Migrations
{
    public partial class BorrowedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerBook_Books_BookId",
                table: "BorrowerBook");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerBook_Borrowers_BorrowerId",
                table: "BorrowerBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowerBook",
                table: "BorrowerBook");

            migrationBuilder.RenameTable(
                name: "BorrowerBook",
                newName: "BorrowedBooks");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowerBook_BorrowerId",
                table: "BorrowedBooks",
                newName: "IX_BorrowedBooks_BorrowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks",
                columns: new[] { "BookId", "BorrowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Books_BookId",
                table: "BorrowedBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Borrowers_BorrowerId",
                table: "BorrowedBooks",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Books_BookId",
                table: "BorrowedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Borrowers_BorrowerId",
                table: "BorrowedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks");

            migrationBuilder.RenameTable(
                name: "BorrowedBooks",
                newName: "BorrowerBook");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowedBooks_BorrowerId",
                table: "BorrowerBook",
                newName: "IX_BorrowerBook_BorrowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowerBook",
                table: "BorrowerBook",
                columns: new[] { "BookId", "BorrowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerBook_Books_BookId",
                table: "BorrowerBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerBook_Borrowers_BorrowerId",
                table: "BorrowerBook",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
