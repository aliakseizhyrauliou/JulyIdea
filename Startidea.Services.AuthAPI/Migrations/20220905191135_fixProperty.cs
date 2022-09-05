using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JulyIdea.Services.AuthAPI.Migrations
{
    public partial class fixProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LasName",
                table: "Users",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "LasName");
        }
    }
}
