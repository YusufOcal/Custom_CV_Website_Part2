using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "WriterMessages",
                newName: "SenderName");

            migrationBuilder.AddColumn<string>(
                name: "MessageContent",
                table: "WriterMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecieverName",
                table: "WriterMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageContent",
                table: "WriterMessages");

            migrationBuilder.DropColumn(
                name: "RecieverName",
                table: "WriterMessages");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "WriterMessages",
                newName: "Content");
        }
    }
}
