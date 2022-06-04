using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaLibrary.Migrations
{
    public partial class removeUniqueNumberMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_client_phonenumber",
                table: "client");

            migrationBuilder.CreateIndex(
                name: "IX_client_phonenumber",
                table: "client",
                column: "phonenumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_client_phonenumber",
                table: "client");

            migrationBuilder.CreateIndex(
                name: "IX_client_phonenumber",
                table: "client",
                column: "phonenumber",
                unique: true);
        }
    }
}
