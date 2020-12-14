using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCatalogs",
                columns: table => new
                {
                    CatalogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCatalogs", x => x.CatalogId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    AmountOfBooksRented = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    BookGenre = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    BookCatalogCatalogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookCatalogs_BookCatalogCatalogId",
                        column: x => x.BookCatalogCatalogId,
                        principalTable: "BookCatalogs",
                        principalColumn: "CatalogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookDictionary",
                columns: table => new
                {
                    DictionaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: true),
                    BooksAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDictionary", x => x.DictionaryId);
                    table.ForeignKey(
                        name: "FK_BookDictionary_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookStates",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllBooksCatalogId = table.Column<int>(nullable: true),
                    AvailableBooksDictionaryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStates", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_BookStates_BookCatalogs_AllBooksCatalogId",
                        column: x => x.AllBooksCatalogId,
                        principalTable: "BookCatalogs",
                        principalColumn: "CatalogId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookStates_BookDictionary_AvailableBooksDictionaryId",
                        column: x => x.AvailableBooksDictionaryId,
                        principalTable: "BookDictionary",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalEvents", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_RentalEvents_BookStates_BookId",
                        column: x => x.BookId,
                        principalTable: "BookStates",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnEvents", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_ReturnEvents_BookStates_BookId",
                        column: x => x.BookId,
                        principalTable: "BookStates",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookDictionary_BookId",
                table: "BookDictionary",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCatalogCatalogId",
                table: "Books",
                column: "BookCatalogCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStates_AllBooksCatalogId",
                table: "BookStates",
                column: "AllBooksCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStates_AvailableBooksDictionaryId",
                table: "BookStates",
                column: "AvailableBooksDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalEvents_BookId",
                table: "RentalEvents",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalEvents_UserId",
                table: "RentalEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnEvents_BookId",
                table: "ReturnEvents",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnEvents_UserId",
                table: "ReturnEvents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalEvents");

            migrationBuilder.DropTable(
                name: "ReturnEvents");

            migrationBuilder.DropTable(
                name: "BookStates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BookDictionary");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookCatalogs");
        }
    }
}
