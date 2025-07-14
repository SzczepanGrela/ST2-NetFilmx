using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetFilmx_Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEnhancements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoCategory",
                keyColumns: new[] { "CategoryId", "VideoId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoPurchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoPurchases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoSeries",
                keyColumns: new[] { "SeriesId", "VideoId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "VideoTag",
                keyColumns: new[] { "TagId", "VideoId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Series",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Series",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Series",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Series",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "NetFilmx",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.CreateTable(
                name: "Carts",
                schema: "NetFilmx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                schema: "NetFilmx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: true),
                    SeriesId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "NetFilmx",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "NetFilmx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                schema: "NetFilmx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EmailNotifications = table.Column<bool>(type: "bit", nullable: false),
                    AutoplayEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HighQualityDefault = table.Column<bool>(type: "bit", nullable: false),
                    ShowAdultContent = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewHistory",
                schema: "NetFilmx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    WatchTimeSeconds = table.Column<int>(type: "int", nullable: false),
                    VideoDurationSeconds = table.Column<int>(type: "int", nullable: true),
                    ViewedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewHistory_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViewHistory_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                schema: "NetFilmx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: true),
                    SeriesId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalSchema: "NetFilmx",
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "NetFilmx",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                schema: "NetFilmx",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_SeriesId",
                schema: "NetFilmx",
                table: "CartItems",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_VideoId",
                schema: "NetFilmx",
                table: "CartItems",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                schema: "NetFilmx",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_SeriesId",
                schema: "NetFilmx",
                table: "Favorites",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId_VideoId_SeriesId",
                schema: "NetFilmx",
                table: "Favorites",
                columns: new[] { "UserId", "VideoId", "SeriesId" },
                unique: true,
                filter: "[VideoId] IS NOT NULL AND [SeriesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_VideoId",
                schema: "NetFilmx",
                table: "Favorites",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                schema: "NetFilmx",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                schema: "NetFilmx",
                table: "UserSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViewHistory_UserId_VideoId",
                schema: "NetFilmx",
                table: "ViewHistory",
                columns: new[] { "UserId", "VideoId" });

            migrationBuilder.CreateIndex(
                name: "IX_ViewHistory_VideoId",
                schema: "NetFilmx",
                table: "ViewHistory",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems",
                schema: "NetFilmx");

            migrationBuilder.DropTable(
                name: "Favorites",
                schema: "NetFilmx");

            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "NetFilmx");

            migrationBuilder.DropTable(
                name: "UserSettings",
                schema: "NetFilmx");

            migrationBuilder.DropTable(
                name: "ViewHistory",
                schema: "NetFilmx");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "NetFilmx");

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Podziwiaj niesamowity świat natury", "Zwierzęta" },
                    { 2, "Filmy edukacyjne", "Rozwój" },
                    { 3, "Zabawne i edukacyjne filmy", "Rozrywka" }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Series",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6602), "Kup zestaw oryginalnych 9 filmów dostępnych na platformie", "Pakiet wszystkich startowych filmów", 149.99m, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6649) },
                    { 2, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6653), "Zestaw zawierający 6 filmów poświęconych zwierzętom", "Pakiet świata zwierząt", 49.99m, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6655) },
                    { 3, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6658), "Zestaw zawierający 3 filmy edukacyjne", "Pakiet rozwoju", 59.99m, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6660) },
                    { 4, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6669), "Zestaw zawierający 3 filmy promocyjne, po jednym z każdej kategorii", "Pakiet promocyjny", 19.99m, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6671) }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Zwierzęta" },
                    { 2, "Koty" },
                    { 3, "Rozrywka" },
                    { 4, "Zabawne" },
                    { 5, "Edukacyjne" },
                    { 6, "Rozwój" },
                    { 7, "Programowanie" },
                    { 8, "Lockpicking" }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 3, 21, 45, 56, 809, DateTimeKind.Local).AddTicks(1400), "user1@example.com", "$2a$11$rReehj4aoeAoHc4VEOM86epohmfvppTZ58i9WwZjKUw9L67B11W4m", new DateTime(2024, 8, 3, 21, 45, 56, 809, DateTimeKind.Local).AddTicks(1451), "User1" },
                    { 2, new DateTime(2024, 8, 3, 21, 45, 56, 929, DateTimeKind.Local).AddTicks(9754), "user2@example.com", "$2a$11$zYqNtTzAr/nK9U1utUnXCOen/ptIUaGQ0JbeVCIzmFpldWbvFOz/i", new DateTime(2024, 8, 3, 21, 45, 56, 929, DateTimeKind.Local).AddTicks(9796), "User2" },
                    { 3, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(954), "user3@example.com", "$2a$11$yjlPbtdMP4SglfZzTMXWp.c6ezunVY05tuIw93YIstv1JRX8cPlPu", new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(989), "User3" }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Videos",
                columns: new[] { "Id", "CreatedAt", "Description", "Price", "ThumbnailUrl", "Title", "UpdatedAt", "VideoUrl", "Views" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover amazing wildlife and relax! ...", 9.99m, "https://i.ytimg.com/vi/5kozt0uDa4c/hqdefault.jpg", "Amazing Scene of Wild Animals In 4K", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6698), "5kozt0uDa4c", 0 },
                    { 2, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultimate Wild Animals Collection in 8K ULTRA HD ...", 4.99m, "https://i.ytimg.com/vi/Zv11L-ZfrSg/hqdefault.jpg", "Ultimate Wild Animals Collection in 8K ULTRA HD", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6734), "Zv11L-ZfrSg", 0 },
                    { 3, new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sit back and relax while enjoying this scenic film ...", 6.99m, "https://i.ytimg.com/vi/oRDRfikj2z8/hqdefault.jpg", "Baby Animals 4K - Amazing World Of Young Animals", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6742), "oRDRfikj2z8", 0 },
                    { 4, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6750), "Cute, cuddly, and utterly chaotic! ...", 14.99m, "https://i.ytimg.com/vi/y0sF5xhGreA/hqdefault.jpg", "20 Minutes of Adorable Kittens", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6752), "y0sF5xhGreA", 0 },
                    { 5, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6759), "Watching funny baby cats is the hardest try not to laugh challenge.", 19.99m, "https://i.ytimg.com/vi/cytJLvf-eVs/hqdefault.jpg", "Baby Cats - Cute and Funny Cat Videos Compilation", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6761), "cytJLvf-eVs", 0 },
                    { 6, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6769), "Hoomans! Rufus here! ...", 12.99m, "https://i.ytimg.com/vi/tpiyEe_CqB4/hqdefault.jpg", "Cute and Funny Cat Videos to Keep You Smiling!", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6771), "tpiyEe_CqB4", 0 },
                    { 7, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6778), "Asp.net core MVC 6.0 tutorial for beginners.", 14.99m, "https://i.ytimg.com/vi/fFY9nxfILJQ/hqdefault.jpg", "Entity Framework Core Migration", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6781), "fFY9nxfILJQ", 0 },
                    { 8, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6788), "This video explores a significant security flaw discussed by LockPickingLawyer.", 19.99m, "https://i.ytimg.com/vi/U5-qy2tbDG8/hqdefault.jpg", "The Most Significant Security Flaw in North America", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6790), "U5-qy2tbDG8", 0 },
                    { 9, new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6797), "Unity is an amazingly powerful game engine - but it can be hard to learn ...", 12.99m, "https://i.ytimg.com/vi/XtQMytORBmM/hqdefault.jpg", "The Unity Tutorial For Complete Beginners", new DateTime(2024, 8, 3, 21, 45, 56, 686, DateTimeKind.Local).AddTicks(6799), "XtQMytORBmM", 0 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, "This is a comment for the first video.", new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1001), new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1003), 1, 1 },
                    { 2, "This is a comment for the second video.", new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1006), new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1008), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Likes",
                columns: new[] { "Id", "CreatedAt", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1014), 1, 1 },
                    { 2, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1017), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "SeriesPurchases",
                columns: new[] { "Id", "PurchaseDate", "SeriesId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1032), 1, 1 },
                    { 2, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1055), 2, 1 },
                    { 3, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1057), 3, 1 },
                    { 4, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1060), 4, 1 },
                    { 5, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1062), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "VideoCategory",
                columns: new[] { "CategoryId", "VideoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 8 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "VideoPurchases",
                columns: new[] { "Id", "PurchaseDate", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1023), 2, 4 },
                    { 2, new DateTime(2024, 8, 3, 21, 45, 57, 50, DateTimeKind.Local).AddTicks(1025), 3, 5 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "VideoSeries",
                columns: new[] { "SeriesId", "VideoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "VideoTag",
                columns: new[] { "TagId", "VideoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 7 },
                    { 6, 9 },
                    { 7, 7 },
                    { 7, 9 },
                    { 8, 8 }
                });
        }
    }
}
