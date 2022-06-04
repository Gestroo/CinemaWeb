using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaLibrary.Migrations
{
    public partial class removeUniqueNumbePersonalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_personal_phonenumber",
                table: "personal");

            migrationBuilder.CreateIndex(
                name: "IX_personal_phonenumber",
                table: "personal",
                column: "phonenumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_personal_phonenumber",
                table: "personal");

            migrationBuilder.CreateIndex(
                name: "IX_personal_phonenumber",
                table: "personal",
                column: "phonenumber",
                unique: true);
        }
    }
}
