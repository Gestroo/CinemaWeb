using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaLibrary.Migrations
{
    public partial class anotherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_genre_id",
                table: "film");

            migrationBuilder.DropIndex(
                name: "IX_film_id",
                table: "film");

            migrationBuilder.AddColumn<int>(
                name: "genre_id",
                table: "film",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_film_genre_id",
                table: "film",
                column: "genre_id");

            migrationBuilder.AddForeignKey(
                name: "FK_film_genre_genre_id",
                table: "film",
                column: "genre_id",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_genre_genre_id",
                table: "film");

            migrationBuilder.DropIndex(
                name: "IX_film_genre_id",
                table: "film");

            migrationBuilder.DropColumn(
                name: "genre_id",
                table: "film");

            migrationBuilder.CreateIndex(
                name: "IX_film_id",
                table: "film",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_film_genre_id",
                table: "film",
                column: "id",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
