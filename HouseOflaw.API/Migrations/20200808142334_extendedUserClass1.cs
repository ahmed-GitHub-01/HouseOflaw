using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseOflaw.API.Migrations
{
    public partial class extendedUserClass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Photos");

            migrationBuilder.AddColumn<double>(
                name: "UserCode",
                table: "Photos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "Photos");

            migrationBuilder.AddColumn<double>(
                name: "Code",
                table: "Photos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
