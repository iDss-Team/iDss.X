using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AppendSeedNavToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.7");

            migrationBuilder.AlterColumn<string>(
                name: "branchname",
                table: "pum_pickuprequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "mdt_reasonpickup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reasonname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    reasoncode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    reasongroup = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_reasonpickup", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.1",
                columns: new[] { "menuname", "path" },
                values: new object[] { "Country", "/master/country" });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.2",
                columns: new[] { "icon", "menuname", "path" },
                values: new object[] { "fa-solid fa-mountain-city", "Province", "/master/province" });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.3",
                columns: new[] { "icon", "menuname", "path" },
                values: new object[] { "fa-solid fa-tree-city", "City", "/master/city" });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.4",
                columns: new[] { "icon", "menuname", "path" },
                values: new object[] { "fa-solid fa-tree-city", "City International", "/master/cityintl" });

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[,]
                {
                    { "2.2.12", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-road-circle-exclamation", "Reason for Undelivered", 11, null, null, "102", "2.2", "/master/reasonun", null },
                    { "2.2.13", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-road-circle-exclamation", "Reason Pickup", 12, null, null, "102", "2.2", "/master/reasonpickup", null },
                    { "2.5.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-bridge-circle-exclamation", "District", 5, null, null, "102", "2.5", "/master/district", null },
                    { "2.5.6", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Village", 6, null, null, "102", "2.5", "/master/village", null },
                    { "2.5.7", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Postal Code", 7, null, null, "102", "2.5", "/master/postcode", null },
                    { "2.5.8", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Zone", 8, null, null, "102", "2.5", "/master/zone", null },
                    { "21.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-tag", "Price Regular", 1, null, null, "121", "", "/master/priceregular", null },
                    { "21.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-tag", "Price Custom", 2, null, null, "121", "", "/master/pricecustom", null }
                });

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "121",
                columns: new[] { "icon", "modulename" },
                values: new object[] { "fa-solid fa-tags", "NCS Pricing Module" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdt_reasonpickup");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.12");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.13");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.5");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.6");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.7");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.8");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "21.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "21.2");

            migrationBuilder.AlterColumn<string>(
                name: "branchname",
                table: "pum_pickuprequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.1",
                columns: new[] { "menuname", "path" },
                values: new object[] { "Province", "/master/province" });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.2",
                columns: new[] { "icon", "menuname", "path" },
                values: new object[] { "fa-solid fa-tree-city", "City", "/master/city" });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.3",
                columns: new[] { "icon", "menuname", "path" },
                values: new object[] { "fa-solid fa-bridge-circle-exclamation", "District", "/master/district" });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.4",
                columns: new[] { "icon", "menuname", "path" },
                values: new object[] { "fa-solid fa-diamond", "Village", "/master/village" });

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[] { "2.2.7", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-road-circle-exclamation", "Reason fo Undelivered", 7, null, null, "102", "2.2", "/master/reasonun", null });

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "121",
                columns: new[] { "icon", "modulename" },
                values: new object[] { "fa-solid fa-rotate", "Data Synchronization" });
        }
    }
}
