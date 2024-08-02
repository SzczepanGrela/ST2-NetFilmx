using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetFilmx_Storage.Migrations
{
    /// <inheritdoc />
    public partial class EmptyMigration : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { 1, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(620), "Kup zestaw oryginalnych 9 filmów dostępnych na platformie", "Pakiet wszystkich startowych filmów", 149.99m, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(674) },
                    { 2, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(679), "Zestaw zawierający 6 filmów poświęconych zwierzętom", "Pakiet świata zwierząt", 49.99m, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(681) },
                    { 3, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(684), "Zestaw zawierający 3 filmy edukacyjne", "Pakiet rozwoju", 59.99m, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(686) },
                    { 4, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(689), "Zestaw zawierający 3 filmy promocyjne, po jednym z każdej kategorii", "Pakiet promocyjny", 19.99m, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(693) }
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
                    { 1, new DateTime(2024, 8, 2, 21, 48, 34, 406, DateTimeKind.Local).AddTicks(4782), "user1@example.com", "$2a$11$gPYG9S5fXD7TlJBQY3d0iuq7ySLaP9Q7Hq3Fzq.Gnl0RfHoFEvNf6", new DateTime(2024, 8, 2, 21, 48, 34, 406, DateTimeKind.Local).AddTicks(4819), "User1" },
                    { 2, new DateTime(2024, 8, 2, 21, 48, 34, 525, DateTimeKind.Local).AddTicks(7851), "user2@example.com", "$2a$11$7hQQsSN.SclH.vRA6Cf.5egKuescsCXrEluhP2ZyOqOgJhIvG9sWy", new DateTime(2024, 8, 2, 21, 48, 34, 525, DateTimeKind.Local).AddTicks(7917), "User2" },
                    { 3, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3109), "user3@example.com", "$2a$11$3IbCQq2adzhroCZ7hdPJjOsaXCwQ/6U7ZNZr1T7Ww8/CiW1hmrFLW", new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3156), "User3" }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Videos",
                columns: new[] { "Id", "CreatedAt", "Description", "Price", "ThumbnailUrl", "Title", "UpdatedAt", "VideoUrl", "Views" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover amazing wildlife and relax! ...", 9.99m, "https://i.ytimg.com/vi/5kozt0uDa4c/hqdefault.jpg", "Amazing Scene of Wild Animals In 4K", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(714), "https://www.youtube.com/watch?v=5kozt0uDa4c", 0 },
                    { 2, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultimate Wild Animals Collection in 8K ULTRA HD ...", 4.99m, "https://i.ytimg.com/vi/Zv11L-ZfrSg/hqdefault.jpg", "Ultimate Wild Animals Collection in 8K ULTRA HD", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(748), "https://www.youtube.com/watch?v=Zv11L-ZfrSg", 0 },
                    { 3, new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sit back and relax while enjoying this scenic film ...", 6.99m, "https://i.ytimg.com/vi/oRDRfikj2z8/hqdefault.jpg", "Baby Animals 4K - Amazing World Of Young Animals", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(757), "https://www.youtube.com/watch?v=oRDRfikj2z8", 0 },
                    { 4, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(764), "Cute, cuddly, and utterly chaotic! ...", 14.99m, "https://i.ytimg.com/vi/y0sF5xhGreA/hqdefault.jpg", "20 Minutes of Adorable Kittens", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(766), "https://www.youtube.com/watch?v=y0sF5xhGreA", 0 },
                    { 5, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(773), "Watching funny baby cats is the hardest try not to laugh challenge.", 19.99m, "https://i.ytimg.com/vi/cytJLvf-eVs/hqdefault.jpg", "Baby Cats - Cute and Funny Cat Videos Compilation", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(775), "https://www.youtube.com/watch?v=cytJLvf-eVs", 0 },
                    { 6, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(783), "Hoomans! Rufus here! ...", 12.99m, "https://i.ytimg.com/vi/tpiyEe_CqB4/hqdefault.jpg", "Cute and Funny Cat Videos to Keep You Smiling!", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(785), "https://www.youtube.com/watch?v=tpiyEe_CqB4", 0 },
                    { 7, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(792), "Asp.net core MVC 6.0 tutorial for beginners.", 14.99m, "https://i.ytimg.com/vi/fFY9nxfILJQ/hqdefault.jpg", "Entity Framework Core Migration", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(794), "https://www.youtube.com/watch?v=fFY9nxfILJQ", 0 },
                    { 8, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(801), "This video explores a significant security flaw discussed by LockPickingLawyer.", 19.99m, "https://i.ytimg.com/vi/U5-qy2tbDG8/hqdefault.jpg", "The Most Significant Security Flaw in North America", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(803), "https://www.youtube.com/watch?v=U5-qy2tbDG8", 0 },
                    { 9, new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(810), "Unity is an amazingly powerful game engine - but it can be hard to learn ...", 12.99m, "https://i.ytimg.com/vi/XtQMytORBmM/hqdefault.jpg", "The Unity Tutorial For Complete Beginners", new DateTime(2024, 8, 2, 21, 48, 34, 292, DateTimeKind.Local).AddTicks(812), "https://www.youtube.com/watch?v=XtQMytORBmM", 0 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, "This is a comment for the first video.", new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3166), new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3168), 1, 1 },
                    { 2, "This is a comment for the second video.", new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3171), new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3173), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "Likes",
                columns: new[] { "Id", "CreatedAt", "UserId", "VideoId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3177), 1, 1 },
                    { 2, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3180), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "NetFilmx",
                table: "SeriesPurchases",
                columns: new[] { "Id", "PurchaseDate", "SeriesId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3191), 1, 1 },
                    { 2, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3194), 2, 1 },
                    { 3, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3196), 3, 1 },
                    { 4, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3212), 4, 1 },
                    { 5, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3214), 2, 2 }
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
                    { 1, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3184), 2, 4 },
                    { 2, new DateTime(2024, 8, 2, 21, 48, 34, 653, DateTimeKind.Local).AddTicks(3187), 3, 5 }
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
