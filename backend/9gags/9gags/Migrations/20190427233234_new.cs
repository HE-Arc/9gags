using Microsoft.EntityFrameworkCore.Migrations;

namespace _9gags.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "auth0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "auth0",
                table: "Users",
                newName: "username");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                nullable: true);
        }
    }
}
