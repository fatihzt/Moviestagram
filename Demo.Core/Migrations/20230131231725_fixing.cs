using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Core.Migrations
{
    public partial class fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOfMovieList_MovieFavoriteList_MovieFavoriteListId",
                table: "ItemOfMovieList");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOfTvList_TvSeriesFavoriteList_TvSeriesFavoriteListId",
                table: "ItemOfTvList");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieFavoriteList_ItemOfMovieList_ItemOfMovieListId",
                table: "MovieFavoriteList");

            migrationBuilder.DropForeignKey(
                name: "FK_TvSeriesFavoriteList_ItemOfTvList_ItemOfTvListId",
                table: "TvSeriesFavoriteList");

            migrationBuilder.DropIndex(
                name: "IX_TvSeriesFavoriteList_ItemOfTvListId",
                table: "TvSeriesFavoriteList");

            migrationBuilder.DropIndex(
                name: "IX_MovieFavoriteList_ItemOfMovieListId",
                table: "MovieFavoriteList");

            migrationBuilder.DropIndex(
                name: "IX_ItemOfTvList_TvSeriesFavoriteListId",
                table: "ItemOfTvList");

            migrationBuilder.DropIndex(
                name: "IX_ItemOfMovieList_MovieFavoriteListId",
                table: "ItemOfMovieList");

            migrationBuilder.DropColumn(
                name: "ItemOfTvListId",
                table: "TvSeriesFavoriteList");

            migrationBuilder.DropColumn(
                name: "ItemOfMovieListId",
                table: "MovieFavoriteList");

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
                name: "ItemOfTvListId",
                table: "TvSeriesFavoriteList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemOfMovieListId",
                table: "MovieFavoriteList",
                type: "int",
                nullable: true);

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
                name: "IX_TvSeriesFavoriteList_ItemOfTvListId",
                table: "TvSeriesFavoriteList",
                column: "ItemOfTvListId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFavoriteList_ItemOfMovieListId",
                table: "MovieFavoriteList",
                column: "ItemOfMovieListId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFavoriteList_ItemOfMovieList_ItemOfMovieListId",
                table: "MovieFavoriteList",
                column: "ItemOfMovieListId",
                principalTable: "ItemOfMovieList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TvSeriesFavoriteList_ItemOfTvList_ItemOfTvListId",
                table: "TvSeriesFavoriteList",
                column: "ItemOfTvListId",
                principalTable: "ItemOfTvList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
