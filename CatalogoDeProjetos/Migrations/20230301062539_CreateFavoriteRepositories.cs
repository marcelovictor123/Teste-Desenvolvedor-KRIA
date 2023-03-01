using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoDeProjetos.Migrations
{
    public partial class CreateFavoriteRepositories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorito",
                table: "Repositorios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorito",
                table: "Repositorios");
        }
    }
}
