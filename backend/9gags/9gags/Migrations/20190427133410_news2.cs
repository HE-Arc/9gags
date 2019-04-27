using Microsoft.EntityFrameworkCore.Migrations;

namespace _9gags.Migrations
{
    public partial class news2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vote",
                table: "Vote",
                newName: "Point");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Comment",
                newName: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Vote",
                newName: "vote");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Comment",
                newName: "comment");
        }
    }
}
