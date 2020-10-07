using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseOflaw.API.Migrations
{
    public partial class roule4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .CreateTable(name: "Roule",
                columns: table =>
                    new {
                        id =
                            table
                                .Column<int>(nullable: false)
                                .Annotation("SqlServer:Identity", "1, 1"),
                        UserCode = table.Column<int>(nullable: true),
                        registry = table.Column<int>(nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roule", x => x.id);
                    table
                        .ForeignKey(name: "FK_Roule_Users_UserCode",
                        column: x => x.UserCode,
                        principalTable: "Users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder
                .CreateIndex(name: "IX_Roule_UserID",
                table: "Roule",
                column: "UserCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Roule");
        }
    }
}
