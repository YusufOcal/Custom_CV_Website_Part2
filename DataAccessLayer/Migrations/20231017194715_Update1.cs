using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Portfolios",
                newName: "ProjectUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl1",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "ProjectUrl",
                table: "Portfolios",
                newName: "ImageUrl");
        }
    }
}
