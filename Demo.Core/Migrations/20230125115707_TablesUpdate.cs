using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Core.Migrations
{
    public partial class TablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemOfMovieList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    FavoriteListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOfMovieList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemOfTvList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TvId = table.Column<int>(type: "int", nullable: false),
                    FavoriteListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOfTvList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOfMovieList");

            migrationBuilder.DropTable(
                name: "ItemOfTvList");
        }
    }
}
