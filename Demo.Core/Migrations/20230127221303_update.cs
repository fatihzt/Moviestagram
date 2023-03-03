using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Core.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentedFavoriteList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FavoriteListId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    TvSeriesId = table.Column<int>(type: "int", nullable: true),
                    CommentBody = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentedFavoriteList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LikedFavoriteList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FavoriteListId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    TvSeriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedFavoriteList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemOfMovieList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieFavoriteListId = table.Column<int>(type: "int", nullable: true),
                    FavoriteListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOfMovieList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieFavoriteList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemOfMovieListId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieFavoriteList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieFavoriteList_ItemOfMovieList_ItemOfMovieListId",
                        column: x => x.ItemOfMovieListId,
                        principalTable: "ItemOfMovieList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieFavoriteList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOfTvList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TvId = table.Column<int>(type: "int", nullable: false),
                    TvSeriesFavoriteListId = table.Column<int>(type: "int", nullable: true),
                    FavoriteListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOfTvList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvSeriesFavoriteList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemOfTvListId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeriesFavoriteList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvSeriesFavoriteList_ItemOfTvList_ItemOfTvListId",
                        column: x => x.ItemOfTvListId,
                        principalTable: "ItemOfTvList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeriesFavoriteList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfMovieList_MovieFavoriteListId",
                table: "ItemOfMovieList",
                column: "MovieFavoriteListId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfTvList_TvSeriesFavoriteListId",
                table: "ItemOfTvList",
                column: "TvSeriesFavoriteListId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFavoriteList_ItemOfMovieListId",
                table: "MovieFavoriteList",
                column: "ItemOfMovieListId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFavoriteList_UserId",
                table: "MovieFavoriteList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeriesFavoriteList_ItemOfTvListId",
                table: "TvSeriesFavoriteList",
                column: "ItemOfTvListId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeriesFavoriteList_UserId",
                table: "TvSeriesFavoriteList",
                column: "UserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOfMovieList_MovieFavoriteList_MovieFavoriteListId",
                table: "ItemOfMovieList");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOfTvList_TvSeriesFavoriteList_TvSeriesFavoriteListId",
                table: "ItemOfTvList");

            migrationBuilder.DropTable(
                name: "CommentedFavoriteList");

            migrationBuilder.DropTable(
                name: "LikedFavoriteList");

            migrationBuilder.DropTable(
                name: "MovieFavoriteList");

            migrationBuilder.DropTable(
                name: "ItemOfMovieList");

            migrationBuilder.DropTable(
                name: "TvSeriesFavoriteList");

            migrationBuilder.DropTable(
                name: "ItemOfTvList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
