using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetFilmx_Storage.Migrations
{
    /// <inheritdoc />
    public partial class ostatniezmiany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "NetFilmx_dodaneZakupy",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "NetFilmx_dodaneZakupy",
                table: "Categories",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3931), new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3933) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3937), new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3939) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3942));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3946));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8820), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8877) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8881), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8884) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8887), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8888) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8897), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8899) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 3,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 4,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 5,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 656, DateTimeKind.Local).AddTicks(5415), "$2a$11$h2MRaNMViwmYkVx/XJ8K4uuz9YY83DJwMLl3pvkDKNlbFynUpGwHG", new DateTime(2024, 7, 31, 8, 58, 39, 656, DateTimeKind.Local).AddTicks(5437) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 774, DateTimeKind.Local).AddTicks(2067), "$2a$11$ZnApsSTmWTztxv6UiG7SF.3uEeB2vKPK58hGltuZP5shuq/qz/aQq", new DateTime(2024, 7, 31, 8, 58, 39, 774, DateTimeKind.Local).AddTicks(2119) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3882), "$2a$11$kBghREXPwnPoB61MFCc0GeKLK/RFL4e1FG.IDeCJ.sTpvsLWVl9Y2", new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3921) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "VideoPurchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "VideoPurchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 891, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8917));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8969), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8971) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8985), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8986) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8993), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(8995) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(9002), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(9004) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(9010), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(9012) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(9019), new DateTime(2024, 7, 31, 8, 58, 39, 541, DateTimeKind.Local).AddTicks(9021) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "NetFilmx_dodaneZakupy",
                table: "Videos",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "NetFilmx_dodaneZakupy",
                table: "Series",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "NetFilmx_dodaneZakupy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "NetFilmx_dodaneZakupy",
                table: "Categories",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 3,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 4,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "SeriesPurchases",
                keyColumn: "Id",
                keyValue: 5,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2774));

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

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2659), "$2a$11$JUyuyLvp6BNqXx2DDM7.5epTQhwcFOW8FvC5ZQYSGqHqVCQJtC5m6", new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2707) });

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "VideoPurchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2743));

            migrationBuilder.UpdateData(
                schema: "NetFilmx_dodaneZakupy",
                table: "VideoPurchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "PurchaseDate",
                value: new DateTime(2024, 7, 30, 5, 10, 24, 389, DateTimeKind.Local).AddTicks(2745));

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
        }
    }
}
