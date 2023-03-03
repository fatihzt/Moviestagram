using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Core.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieFavoriteList_ItemOfMovieList_ItemOfMovieListId",
                table: "MovieFavoriteList");

            migrationBuilder.AlterColumn<int>(
                name: "ItemOfMovieListId",
                table: "MovieFavoriteList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFavoriteList_ItemOfMovieList_ItemOfMovieListId",
                table: "MovieFavoriteList",
                column: "ItemOfMovieListId",
                principalTable: "ItemOfMovieList",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieFavoriteList_ItemOfMovieList_ItemOfMovieListId",
                table: "MovieFavoriteList");

            migrationBuilder.AlterColumn<int>(
                name: "ItemOfMovieListId",
                table: "MovieFavoriteList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFavoriteList_ItemOfMovieList_ItemOfMovieListId",
                table: "MovieFavoriteList",
                column: "ItemOfMovieListId",
                principalTable: "ItemOfMovieList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
