using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JulyIdea.Services.IdeasAPI.Migrations
{
    public partial class addGroupProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "Ideas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsInGroup",
                table: "Ideas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "IsInGroup",
                table: "Ideas");
        }
    }
}
