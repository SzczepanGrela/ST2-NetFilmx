using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetFilmx_Storage.Migrations
{
    /// <inheritdoc />
    public partial class dodanieZakupow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "VideoTag",
                schema: "NetFilmx_noweEntities",
                newName: "VideoTag",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "VideoSeries",
                schema: "NetFilmx_noweEntities",
                newName: "VideoSeries",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "Videos",
                schema: "NetFilmx_noweEntities",
                newName: "Videos",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "VideoCategory",
                schema: "NetFilmx_noweEntities",
                newName: "VideoCategory",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "NetFilmx_noweEntities",
                newName: "Users",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "Tags",
                schema: "NetFilmx_noweEntities",
                newName: "Tags",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "Series",
                schema: "NetFilmx_noweEntities",
                newName: "Series",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "Likes",
                schema: "NetFilmx_noweEntities",
                newName: "Likes",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "NetFilmx_noweEntities",
                newName: "Comments",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "NetFilmx_noweEntities",
                newName: "Categories",
                newSchema: "NetFilmx_dodaneZakupy");

            migrationBuilder.CreateTable(
                name: "SeriesPurchases",
                schema: "NetFilmx_dodaneZakupy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesPurchases_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "NetFilmx_dodaneZakupy",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesPurchases_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx_dodaneZakupy",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoPurchases",
                schema: "NetFilmx_dodaneZakupy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoPurchases_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "NetFilmx_dodaneZakupy",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoPurchases_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "NetFilmx_dodaneZakupy",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2725), new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2727) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2730), new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2732) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2735));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2738));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7566), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7613) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7618), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7621) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7624), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7637), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7642) });

            migrationBuilder.InsertData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                columns: new[] { "Id", "PurchaseDate", "SeriesId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2748), 1, 1 },
                    { 2, new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2751), 2, 1 },
                    { 3, new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2753), 3, 1 },
                    { 4, new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2772), 4, 1 },
                    { 5, new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2774), 2, 2 }
                });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 24, 124, DateTimeKind.Local).AddTicks(3626), "$2a$11$lQMBtGw9doeLxu49DX/zMe1kqEUyG.k48gVnvmNaObJIoq4dbBnX6", new DateTime(2024, 7, 30, 5, 10, 24, 124, DateTimeKind.Local).AddTicks(3714) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 24, 255, DateTimeKind.Local).AddTicks(8120), "$2a$11$3rTtw21f5U04P46HbU1tNuDKirE9a1Mh6uhqXZtZfTYoF9Bo6TGVK", new DateTime(2024, 7, 30, 5, 10, 24, 255, DateTimeKind.Local).AddTicks(8178) });

            migrationBuilder.InsertData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[] { 3, new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2659), "user3@example.com", "$2a$11$JUyuyLvp6BNqXx2DDM7.5epTQhwcFOW8FvC5ZQYSGqHqVCQJtC5m6", new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2707), "User3" });

            migrationBuilder.InsertData(
                schema: "NetFilmx_dodaneZakupy",
                table: "VideoPurchases",
                columns: new[] { "Id", "PurchaseDate", "UserId", "VideoId" },
                values: new object[] { 1, new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2743), 2, 4 });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7743), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7745) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7753), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7755) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7769), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7771) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7779), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7781) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7788), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7797), new DateTime(2024, 7, 30, 5, 10, 23, 998, DateTimeKind.Local).AddTicks(7799) });

            migrationBuilder.InsertData(
                schema: "NetFilmx_dodaneZakupy",
                table: "VideoPurchases",
                columns: new[] { "Id", "PurchaseDate", "UserId", "VideoId" },
                values: new object[] { 2, new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2745), 3, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesPurchases_SeriesId",
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesPurchases_UserId",
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoPurchases_UserId",
                schema: "NetFilmx_dodaneZakupy",
                table: "VideoPurchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoPurchases_VideoId",
                schema: "NetFilmx_dodaneZakupy",
                table: "VideoPurchases",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriesPurchases",
                schema: "NetFilmx_dodaneZakupy");

            migrationBuilder.DropTable(
                name: "VideoPurchases",
                schema: "NetFilmx_dodaneZakupy");

            migrationBuilder.DeleteData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.EnsureSchema(
                name: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "VideoTag",
                schema: "NetFilmx_dodaneZakupy",
                newName: "VideoTag",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "VideoSeries",
                schema: "NetFilmx_dodaneZakupy",
                newName: "VideoSeries",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "Videos",
                schema: "NetFilmx_dodaneZakupy",
                newName: "Videos",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "VideoCategory",
                schema: "NetFilmx_dodaneZakupy",
                newName: "VideoCategory",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "NetFilmx_dodaneZakupy",
                newName: "Users",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "Tags",
                schema: "NetFilmx_dodaneZakupy",
                newName: "Tags",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "Series",
                schema: "NetFilmx_dodaneZakupy",
                newName: "Series",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "Likes",
                schema: "NetFilmx_dodaneZakupy",
                newName: "Likes",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "NetFilmx_dodaneZakupy",
                newName: "Comments",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "NetFilmx_dodaneZakupy",
                newName: "Categories",
                newSchema: "NetFilmx_noweEntities");

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7704), new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7707) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7710), new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7723) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2501), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2547) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2551), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2552) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2554), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2568) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Series",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2571), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2573) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 242, DateTimeKind.Local).AddTicks(7312), "$2a$11$PPjK1Tnp1mGAzhRqkVbfHOaRG8KS16GLYEZeBa7ny7ZA6otz/pgoC", new DateTime(2024, 7, 30, 2, 6, 27, 242, DateTimeKind.Local).AddTicks(7353) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7636), "$2a$11$DCZKLmZVTMToZf9V5UjK7OuVbxKao5Q0X8PaqIXwfk0tfqY2cOn1C", new DateTime(2024, 7, 30, 2, 6, 27, 365, DateTimeKind.Local).AddTicks(7693) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2616), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2642) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2649), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2650) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2655), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2657) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2662), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2664) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2669), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2671) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_noweEntities",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2676), new DateTime(2024, 7, 30, 2, 6, 27, 127, DateTimeKind.Local).AddTicks(2678) });
        }
    }
}
