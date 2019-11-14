using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskTeamDeseret.Migrations
{
    public partial class RushDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Quote",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Quote");
        }
    }
}
