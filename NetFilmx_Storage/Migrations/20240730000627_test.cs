using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetFilmx_Storage.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NetFilmx_noweEntities");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoCategory",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategory", x => new { x.CategoryId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_VideoCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCategory_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoSeries",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoSeries", x => new { x.SeriesId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_VideoSeries_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoSeries_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoTag",
                schema: "NetFilmx_noweEntities",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTag", x => new { x.TagId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_VideoTag_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoTag_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_noweEntities",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_noweEntities",
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Podziwiaj niesamowity świat natury", "Zwierzęta" },
                    { 2, "Filmy edukacyjne", "Rozwój" },
                    { 3, "Zabawne i edukacyjne filmy", "Rozrywka" }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_noweEntities",
                table: "Series",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2501), "Kup zestaw oryginalnych 9 filmów dostępnych na platformie", "Pakiet wszystkich startowych filmów", 149.99m, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2547) },
                    { 2, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2551), "Zestaw zawierający 6 filmów poświęconych zwierzętom", "Pakiet świata zwierząt", 49.99m, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2552) },
                    { 3, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2554), "Zestaw zawierający 3 filmy edukacyjne", "Pakiet rozwoju", 59.99m, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2568) },
                    { 4, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2571), "Zestaw zawierający 3 filmy promocyjne, po jednym z każdej kategorii", "Pakiet promocyjny", 19.99m, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2573) }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_noweEntities",
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
                schema: "NetFilmx_noweEntities",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 30, 2, 6, 27, 242, DateTimeKind.Local).AddTicks(7312), "user1@example.com", "$2a$11$PPjK1Tnp1mGAzhRqkVbfHOaRG8KS16GLYEZeBa7ny7ZA6otz/pgoC", new DateTime(2024, 7, 30, 2, 6, 27, 242, DateTimeKind.Local).AddTicks(7353), "User1" },
                    { 2, new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7636), "user2@example.com", "$2a$11$DCZKLmZVTMToZf9V5UjK7OuVbxKao5Q0X8PaqIXwfk0tfqY2cOn1C", new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7693), "User2" }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                columns: new[] { "Id", "CreatedAt", "Description", "Price", "ThumbnailUrl", "Title", "UpdatedAt", "VideoUrl", "Views" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover amazing wildlife and relax! ...", 9.99m, "https://i.ytimg.com/vi/5kozt0uDa4c/hqdefault.jpg", "Amazing Scene of Wild Animals In 4K", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2594), "https://www.youtube.com/watch?v=5kozt0uDa4c", 0 },
                    { 2, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultimate Wild Animals Collection in 8K ULTRA HD ...", 4.99m, "https://i.ytimg.com/vi/Zv11L-ZfrSg/hqdefault.jpg", "Ultimate Wild Animals Collection in 8K ULTRA HD", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2601), "https://www.youtube.com/watch?v=Zv11L-ZfrSg", 0 },
                    { 3, new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sit back and relax while enjoying this scenic film ...", 6.99m, "https://i.ytimg.com/vi/oRDRfikj2z8/hqdefault.jpg", "Baby Animals 4K - Amazing World Of Young Animals", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2609), "https://www.youtube.com/watch?v=oRDRfikj2z8", 0 },
                    { 4, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2616), "Cute, cuddly, and utterly chaotic! ...", 14.99m, "https://i.ytimg.com/vi/y0sF5xhGreA/hqdefault.jpg", "20 Minutes of Adorable Kittens", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2642), "https://www.youtube.com/watch?v=y0sF5xhGreA", 0 },
                    { 5, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2649), "Watching funny baby cats is the hardest try not to laugh challenge.", 19.99m, "https://i.ytimg.com/vi/cytJLvf-eVs/hqdefault.jpg", "Baby Cats - Cute and Funny Cat Videos Compilation", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2650), "https://www.youtube.com/watch?v=cytJLvf-eVs", 0 },
                    { 6, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2655), "Hoomans! Rufus here! ...", 12.99m, "https://i.ytimg.com/vi/tpiyEe_CqB4/hqdefault.jpg", "Cute and Funny Cat Videos to Keep You Smiling!", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2657), "https://www.youtube.com/watch?v=tpiyEe_CqB4", 0 },
                    { 7, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2662), "Asp.net core MVC 6.0 tutorial for beginners.", 14.99m, "https://i.ytimg.com/vi/fFY9nxfILJQ/hqdefault.jpg", "Entity Framework Core Migration", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2664), "https://www.youtube.com/watch?v=fFY9nxfILJQ", 0 },
                    { 8, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2669), "This video explores a significant security flaw discussed by LockPickingLawyer.", 19.99m, "https://i.ytimg.com/vi/U5-qy2tbDG8/hqdefault.jpg", "The Most Significant Security Flaw in North America", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2671), "https://www.youtube.com/watch?v=U5-qy2tbDG8", 0 },
                    { 9, new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2676), "Unity is an amazingly powerful game engine - but it can be hard to learn ...", 12.99m, "https://i.ytimg.com/vi/XtQMytORBmM/hqdefault.jpg", "The Unity Tutorial For Complete Beginners", new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2678), "https://www.youtube.com/watch?v=XtQMytORBmM", 0 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_noweEntities",
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, "This is a comment for the first video.", new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7704), new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7707), 1, 1 },
                    { 2, "This is a comment for the second video.", new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7710), new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7723), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_noweEntities",
                table: "Likes",
                columns: new[] { "Id", "CreatedAt", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7730), 1, 1 },
                    { 2, new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7734), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_noweEntities",
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
                schema: "NetFilmx_noweEntities",
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
                schema: "NetFilmx_noweEntities",
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                schema: "NetFilmx_noweEntities",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VideoId",
                schema: "NetFilmx_noweEntities",
                table: "Comments",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                schema: "NetFilmx_noweEntities",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_VideoId",
                schema: "NetFilmx_noweEntities",
                table: "Likes",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategory_VideoId",
                schema: "NetFilmx_noweEntities",
                table: "VideoCategory",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoSeries_VideoId",
                schema: "NetFilmx_noweEntities",
                table: "VideoSeries",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoTag_VideoId",
                schema: "NetFilmx_noweEntities",
                table: "VideoTag",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "Likes",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "VideoCategory",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "VideoSeries",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "VideoTag",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "Series",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "NetFilmx_noweEntities");

            migrationBuilder.DropTable(
                name: "Videos",
                schema: "NetFilmx_noweEntities");
        }
    }
}
