using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryMovies",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMovies", x => new { x.CategoryId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CategoryMovies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMovies_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ImdbRating = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieFeatures_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macera", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilim Kurgu", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aksiyon", null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 27, 18, 32, 10, 74, DateTimeKind.Local).AddTicks(2122), "Jumanji", null },
                    { 2, 2, new DateTime(2023, 6, 27, 18, 32, 10, 74, DateTimeKind.Local).AddTicks(2132), "Interstellar", null },
                    { 3, 2, new DateTime(2023, 6, 27, 18, 32, 10, 74, DateTimeKind.Local).AddTicks(2133), "The Martian", null },
                    { 4, 3, new DateTime(2023, 6, 27, 18, 32, 10, 74, DateTimeKind.Local).AddTicks(2134), "Pacific Rim", null },
                    { 5, 3, new DateTime(2023, 6, 27, 18, 32, 10, 74, DateTimeKind.Local).AddTicks(2135), "Hitman's Bodyguard", null }
                });

            migrationBuilder.InsertData(
                table: "MovieFeatures",
                columns: new[] { "Id", "ImdbRating", "MoviesId", "Overview", "Year" },
                values: new object[,]
                {
                    { 1, 8, 1, "Uzun Bir Açıklama", 2012 },
                    { 2, 9, 2, "Uzun Bir Açıklama 2", 2014 },
                    { 3, 7, 3, "Uzun Bir Açıklama 3", 2014 },
                    { 4, 8, 4, "Uzun Bir Açıklama 4", 2019 },
                    { 5, 7, 5, "Uzun Bir Açıklama 5", 2015 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMovies_MoviesId",
                table: "CategoryMovies",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFeatures_MoviesId",
                table: "MovieFeatures",
                column: "MoviesId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMovies");

            migrationBuilder.DropTable(
                name: "MovieFeatures");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
