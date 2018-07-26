using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Web.Migrations
{
    public partial class MoviesDirectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BorrowedBooks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "BorrowedBooks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PosterImage = table.Column<string>(nullable: true),
                    DirectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedMovies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BorrowerId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedMovies_Borrowers_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Borrowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_BookId",
                table: "BorrowedBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_MovieId",
                table: "BorrowedBooks",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedMovies_BorrowerId",
                table: "BorrowedMovies",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedMovies_MovieId",
                table: "BorrowedMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Movies_MovieId",
                table: "BorrowedBooks",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Movies_MovieId",
                table: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "BorrowedMovies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBooks_BookId",
                table: "BorrowedBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBooks_MovieId",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "BorrowedBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks",
                columns: new[] { "BookId", "BorrowerId" });
        }
    }
}
