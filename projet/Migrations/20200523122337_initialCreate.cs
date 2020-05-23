using Microsoft.EntityFrameworkCore.Migrations;

namespace projet.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Enseignants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Admins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Enseignants");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Admins");
        }
    }
}
