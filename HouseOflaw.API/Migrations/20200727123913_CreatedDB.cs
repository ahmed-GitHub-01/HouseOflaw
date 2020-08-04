using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseOflaw.API.Migrations
{
    public partial class CreatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<double>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordHashed = table.Column<byte[]>(nullable: true),
                    Name_Ar = table.Column<string>(nullable: true),
                    DateEntry = table.Column<DateTime>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    IsVoke = table.Column<int>(nullable: false),
                    Switch = table.Column<int>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    Acc_Code = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
