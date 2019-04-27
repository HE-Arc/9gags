using Microsoft.EntityFrameworkCore.Migrations;

namespace _9gags.Migrations
{
    public partial class news9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Comment_Id",
                table: "Comment",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Comment_Id",
                table: "Comment");
        }
    }
}
