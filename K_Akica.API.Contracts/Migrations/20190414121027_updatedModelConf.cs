using Microsoft.EntityFrameworkCore.Migrations;

namespace K_Akica.API.Contracts.Migrations
{
    public partial class updatedModelConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Poopers",
                newName: "Poopers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FeedItems",
                newName: "FeedItems",
                newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Poopers",
                schema: "dbo",
                newName: "Poopers");

            migrationBuilder.RenameTable(
                name: "FeedItems",
                schema: "dbo",
                newName: "FeedItems");
        }
    }
}
