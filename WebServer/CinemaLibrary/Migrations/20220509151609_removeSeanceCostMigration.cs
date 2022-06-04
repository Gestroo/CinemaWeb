using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaLibrary.Migrations
{
    public partial class removeSeanceCostMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                table: "seance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cost",
                table: "seance",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
