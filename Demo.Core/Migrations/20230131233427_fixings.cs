using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Core.Migrations
{
    public partial class fixings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOfMovieList_MovieFavoriteList_MovieFavoriteListId",
                table: "ItemOfMovieList");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOfTvList_TvSeriesFavoriteList_TvSeriesFavoriteListId",
                table: "ItemOfTvList");

            migrationBuilder.DropIndex(
                name: "IX_ItemOfTvList_TvSeriesFavoriteListId",
                table: "ItemOfTvList");

            migrationBuilder.DropIndex(
                name: "IX_ItemOfMovieList_MovieFavoriteListId",
                table: "ItemOfMovieList");

            migrationBuilder.DropColumn(
                name: "TvSeriesFavoriteListId",
                table: "ItemOfTvList");

            migrationBuilder.DropColumn(
                name: "MovieFavoriteListId",
                table: "ItemOfMovieList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TvSeriesFavoriteListId",
                table: "ItemOfTvList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieFavoriteListId",
                table: "ItemOfMovieList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfTvList_TvSeriesFavoriteListId",
                table: "ItemOfTvList",
                column: "TvSeriesFavoriteListId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfMovieList_MovieFavoriteListId",
                table: "ItemOfMovieList",
                column: "MovieFavoriteListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOfMovieList_MovieFavoriteList_MovieFavoriteListId",
                table: "ItemOfMovieList",
                column: "MovieFavoriteListId",
                principalTable: "MovieFavoriteList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOfTvList_TvSeriesFavoriteList_TvSeriesFavoriteListId",
                table: "ItemOfTvList",
                column: "TvSeriesFavoriteListId",
                principalTable: "TvSeriesFavoriteList",
                principalColumn: "Id");
        }
    }
}
