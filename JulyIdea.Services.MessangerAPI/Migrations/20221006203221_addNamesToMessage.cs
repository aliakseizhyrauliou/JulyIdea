using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JulyIdea.Services.MessangerAPI.Migrations
{
    public partial class addNamesToMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverUserName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderUserName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverUserName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderUserName",
                table: "Messages");
        }
    }
}
