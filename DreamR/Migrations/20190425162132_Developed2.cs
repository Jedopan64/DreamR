using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamR.Migrations
{
    public partial class Developed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImageBinary",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImageBinary",
                table: "AspNetUsers");
        }
    }
}
