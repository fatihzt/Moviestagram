using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Core.Migrations
{
    public partial class güncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TvSeriesFavoriteList_UserId",
                table: "TvSeriesFavoriteList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFavoriteList_UserId",
                table: "MovieFavoriteList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFavoriteList_User_UserId",
                table: "MovieFavoriteList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TvSeriesFavoriteList_User_UserId",
                table: "TvSeriesFavoriteList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieFavoriteList_User_UserId",
                table: "MovieFavoriteList");

            migrationBuilder.DropForeignKey(
                name: "FK_TvSeriesFavoriteList_User_UserId",
                table: "TvSeriesFavoriteList");

            migrationBuilder.DropIndex(
                name: "IX_TvSeriesFavoriteList_UserId",
                table: "TvSeriesFavoriteList");

            migrationBuilder.DropIndex(
                name: "IX_MovieFavoriteList_UserId",
                table: "MovieFavoriteList");
        }
    }
}
