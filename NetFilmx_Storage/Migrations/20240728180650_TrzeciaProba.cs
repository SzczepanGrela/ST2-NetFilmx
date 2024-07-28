using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetFilmx_Storage.Migrations
{
    /// <inheritdoc />
    public partial class TrzeciaProba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NetFilmx_projekt");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "NetFilmx_projekt",
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
                schema: "NetFilmx_projekt",
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
                schema: "NetFilmx_projekt",
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
                schema: "NetFilmx_projekt",
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
                schema: "NetFilmx_projekt",
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
                schema: "NetFilmx_projekt",
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
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                schema: "NetFilmx_projekt",
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
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video_Categories",
                schema: "NetFilmx_projekt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Video_Categories_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video_Series",
                schema: "NetFilmx_projekt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Series_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Video_Series_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video_Tags",
                schema: "NetFilmx_projekt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Tags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Video_Tags_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_projekt",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Podziwiaj niesamowity świat natury", "Zwierzęta" },
                    { 2, "Filmy edukacyjne", "Rozwój" },
                    { 3, "Zabawne i edukacyjne filmy", "Rozrywka" }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
                table: "Series",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3459), "Kup zestaw oryginalnych 9 filmów dostępnych na platformie", "Pakiet wszystkich startowych filmów", 149.99m, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3461) },
                    { 2, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3463), "Zestaw zawierający 6 filmów poświęconych zwierzętom", "Pakiet świata zwierząt", 49.99m, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3465) },
                    { 3, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3467), "Zestaw zawierający 3 filmy edukacyjne", "Pakiet rozwoju", 59.99m, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3468) },
                    { 4, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3471), "Zestaw zawierający 3 filmy promocyjne, po jednym z każdej kategorii", "Pakiet promocyjny", 19.99m, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3472) }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
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
                schema: "NetFilmx_projekt",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 28, 20, 6, 49, 587, DateTimeKind.Local).AddTicks(7714), "user1@example.com", "$2a$11$2z8LDZXfMaHzEdQPxjKF8.22mEX8RSOEBeW788avvzKcUfzXfdJwi", new DateTime(2024, 7, 28, 20, 6, 49, 587, DateTimeKind.Local).AddTicks(7757), "User1" },
                    { 2, new DateTime(2024, 7, 28, 20, 6, 49, 706, DateTimeKind.Local).AddTicks(2582), "user2@example.com", "$2a$11$FZq84iCLAxBFrUsknRn7aOGmdu/wRi4.iB55uluYmc.Ve8dGiQw6.", new DateTime(2024, 7, 28, 20, 6, 49, 706, DateTimeKind.Local).AddTicks(2643), "User2" }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
                table: "Videos",
                columns: new[] { "Id", "CreatedAt", "Description", "Price", "ThumbnailUrl", "Title", "UpdatedAt", "VideoUrl", "Views" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover amazing wildlife and relax! In this nature film you will see the most incredible and stunning wild animals and birds! These are some of them: Lion, Cheetah, Southern Giraffe, Tawny Eagle, Hippopotamus, African Elephant, Tiger, Zebra, Gorilla, Vulture, Bull, Deer, Monkey, Rhino, Panda, Red Panda, Bear and more. Hope you enjoy this scene with the most incredible wild animals captured on 4K ULTRA HD footage. This scenic relaxation film shows scenes of one of the most amazing landscapes in the wild world.", 9.99m, "https://i.ytimg.com/vi/5kozt0uDa4c/hqdefault.jpg", "Amazing Scene of Wild Animals In 4K", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3339), "https://www.youtube.com/watch?v=5kozt0uDa4c", 0 },
                    { 2, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultimate Wild Animals Collection in 8K ULTRA HD / 8K TV\r\nHigh Quality Animals from the World Video In Exceptional 8K HDR 60FPS Quality For Your 8K resolution device.\r\nYou can watch this collection of Ultimate Wild Animals Collection in 8K ULTRA HD / 8K TV in your TV For The Living Room, Office 365, Lounge, Waiting Room Business, Spa at home, Spa music, Showroom , Restaurant Music and much more.", 4.99m, "https://i.ytimg.com/vi/Zv11L-ZfrSg/hqdefault.jpg", "Ultimate Wild Animals Collection in 8K ULTRA HD", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3363), "https://www.youtube.com/watch?v=Zv11L-ZfrSg", 0 },
                    { 3, new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sit back and relax while enjoying this scenic film captures the marvelous and amazing world of cute baby animals. In this relaxation film you will find a beautiful collection of wild young babies around the world including lion cubs, bear cubs, baby elephant, baby giraffe, baby rhino and hippo, polar bear cubs, baby fox, deer, monkey and many more.", 6.99m, "https://i.ytimg.com/vi/oRDRfikj2z8/hqdefault.jpg", "Baby Animals 4K - Amazing World Of Young Animals", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3369), "https://www.youtube.com/watch?v=oRDRfikj2z8", 0 },
                    { 4, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3375), "Cute, cuddly, and utterly chaotic! These adorable kittens are jumping in the dog-pile in this collection of cute and hilarious kitty clips!", 14.99m, "https://i.ytimg.com/vi/y0sF5xhGreA/hqdefault.jpg", "20 Minutes of Adorable Kittens", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3376), "https://www.youtube.com/watch?v=y0sF5xhGreA", 0 },
                    { 5, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3381), "Watching funny baby cats is the hardest try not to laugh challenge.", 19.99m, "https://i.ytimg.com/vi/cytJLvf-eVs/hqdefault.jpg", "Baby Cats - Cute and Funny Cat Videos Compilation", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3385), "https://www.youtube.com/watch?v=cytJLvf-eVs", 0 },
                    { 6, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3392), "Hoomans! Rufus here! Cats are my best frens! I made this brand new compilation for you of my favorite Cat, Kittens and even newborn kittens pets and animals! This video is so cute! Rufus approved!", 12.99m, "https://i.ytimg.com/vi/tpiyEe_CqB4/hqdefault.jpg", "Cute and Funny Cat Videos to Keep You Smiling!", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3418), "https://www.youtube.com/watch?v=tpiyEe_CqB4", 0 },
                    { 7, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3424), "Asp.net core MVC 6.0 tutorial for beginners.", 14.99m, "https://i.ytimg.com/vi/fFY9nxfILJQ/hqdefault.jpg", "Entity Framework Core Migration", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3425), "https://www.youtube.com/watch?v=fFY9nxfILJQ", 0 },
                    { 8, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3431), "This video explores a significant security flaw discussed by LockPickingLawyer.", 19.99m, "https://i.ytimg.com/vi/U5-qy2tbDG8/hqdefault.jpg", "The Most Significant Security Flaw in North America", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3432), "https://www.youtube.com/watch?v=U5-qy2tbDG8", 0 },
                    { 9, new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3438), "Unity is an amazingly powerful game engine - but it can be hard to learn. Especially if you find tutorials hard to follow and prefer to learn by doing", 12.99m, "https://i.ytimg.com/vi/XtQMytORBmM/hqdefault.jpg", "The Unity Tutorial For Complete Beginners", new DateTime(2024, 7, 28, 20, 6, 49, 471, DateTimeKind.Local).AddTicks(3439), "https://www.youtube.com/watch?v=XtQMytORBmM", 0 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, "This is a comment for the first video.", new DateTime(2024, 7, 28, 20, 6, 49, 706, DateTimeKind.Local).AddTicks(2656), new DateTime(2024, 7, 28, 20, 6, 49, 706, DateTimeKind.Local).AddTicks(2659), 1, 1 },
                    { 2, "This is a comment for the second video.", new DateTime(2024, 7, 28, 20, 6, 49, 706, DateTimeKind.Local).AddTicks(2663), new DateTime(2024, 7, 28, 20, 6, 49, 706, DateTimeKind.Local).AddTicks(2674), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
                table: "Likes",
                columns: new[] { "Id", "CreatedAt", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 28, 20, 6, 49, 706, DateTimeKind.Local).AddTicks(2682), 1, 1 },
                    { 2, new DateTime(2024, 7, 28, 20, 6, 49, 706, DateTimeKind.Local).AddTicks(2686), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
                table: "Video_Categories",
                columns: new[] { "Id", "CategoryId", "VideoId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 3, 1 },
                    { 5, 3, 2 },
                    { 6, 3, 3 },
                    { 7, 1, 4 },
                    { 8, 3, 4 },
                    { 9, 1, 5 },
                    { 10, 3, 5 },
                    { 11, 1, 6 },
                    { 12, 3, 6 },
                    { 13, 2, 7 },
                    { 14, 2, 8 },
                    { 15, 2, 9 },
                    { 16, 3, 8 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
                table: "Video_Series",
                columns: new[] { "Id", "SeriesId", "VideoId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 },
                    { 7, 4, 7 },
                    { 8, 4, 8 },
                    { 9, 4, 9 },
                    { 10, 2, 1 },
                    { 11, 2, 2 },
                    { 12, 2, 3 },
                    { 13, 2, 4 },
                    { 14, 2, 5 },
                    { 15, 2, 6 },
                    { 16, 3, 7 },
                    { 17, 3, 8 },
                    { 18, 3, 9 },
                    { 19, 4, 1 },
                    { 20, 4, 4 },
                    { 21, 4, 7 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx_projekt",
                table: "Video_Tags",
                columns: new[] { "Id", "TagId", "VideoId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 5, 1 },
                    { 3, 1, 2 },
                    { 4, 5, 2 },
                    { 5, 1, 3 },
                    { 6, 5, 3 },
                    { 7, 2, 4 },
                    { 8, 4, 4 },
                    { 9, 2, 5 },
                    { 10, 4, 5 },
                    { 11, 2, 6 },
                    { 12, 4, 6 },
                    { 13, 1, 6 },
                    { 14, 1, 5 },
                    { 15, 1, 4 },
                    { 16, 7, 7 },
                    { 17, 8, 8 },
                    { 18, 6, 9 },
                    { 19, 7, 9 },
                    { 20, 6, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                schema: "NetFilmx_projekt",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VideoId",
                schema: "NetFilmx_projekt",
                table: "Comments",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                schema: "NetFilmx_projekt",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_VideoId",
                schema: "NetFilmx_projekt",
                table: "Likes",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_Categories_CategoryId",
                schema: "NetFilmx_projekt",
                table: "Video_Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_Categories_VideoId",
                schema: "NetFilmx_projekt",
                table: "Video_Categories",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_Series_SeriesId",
                schema: "NetFilmx_projekt",
                table: "Video_Series",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_Series_VideoId",
                schema: "NetFilmx_projekt",
                table: "Video_Series",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_Tags_TagId",
                schema: "NetFilmx_projekt",
                table: "Video_Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_Tags_VideoId",
                schema: "NetFilmx_projekt",
                table: "Video_Tags",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Likes",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Video_Categories",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Video_Series",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Video_Tags",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Series",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "NetFilmx_projekt");

            migrationBuilder.DropTable(
                name: "Videos",
                schema: "NetFilmx_projekt");
        }
    }
}
