using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JulyIdea.Services.IdeasAPI.Migrations
{
    public partial class removeStackEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stacks");

            migrationBuilder.AddColumn<string>(
                name: "StackFullString",
                table: "Ideas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StackFullString",
                table: "Ideas");

            migrationBuilder.CreateTable(
                name: "Stacks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaId = table.Column<long>(type: "bigint", nullable: true),
                    Technology = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stacks_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stacks_IdeaId",
                table: "Stacks",
                column: "IdeaId");
        }
    }
}
