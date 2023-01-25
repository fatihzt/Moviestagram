using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Core.Migrations
{
    public partial class TablesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "LikedFavoriteList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TvSeriesId",
                table: "LikedFavoriteList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "CommentedFavoriteList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TvSeriesId",
                table: "CommentedFavoriteList",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "LikedFavoriteList");

            migrationBuilder.DropColumn(
                name: "TvSeriesId",
                table: "LikedFavoriteList");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "CommentedFavoriteList");

            migrationBuilder.DropColumn(
                name: "TvSeriesId",
                table: "CommentedFavoriteList");
        }
    }
}
