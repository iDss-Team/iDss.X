using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AppendMasterTableToDb250528 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mdt_packingtype",
                columns: table => new
                {
                    packingcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    packingname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_packingtype", x => x.packingcode);
                });

            migrationBuilder.CreateTable(
                name: "mdt_service",
                columns: table => new
                {
                    servicecode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    servicename = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_service", x => x.servicecode);
                });

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[,]
                {
                    { "2.2.10", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-filter-circle-dollar", "Cost Component", 10, null, null, "102", "2.2", "/master/costcomponent", null },
                    { "2.2.11", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-circle-dollar-to-slot", "Payment Gateway", 11, null, null, "102", "2.2", "/master/paymentgateway", null },
                    { "2.2.6", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-people-arrows", "Relation Code", 6, null, null, "102", "2.2", "/master/relation", null },
                    { "2.2.7", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-road-circle-exclamation", "Reason fo Undelivered", 7, null, null, "102", "2.2", "/master/reasonun", null },
                    { "2.2.8", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-bell-concierge", "Service Code", 8, null, null, "102", "2.2", "/master/service", null },
                    { "2.2.9", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-boxes-packing", "Packing Type", 9, null, null, "102", "2.2", "/master/packingtype", null },
                    { "2.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-map-location-dot", "Area", 5, null, null, "102", "", "", null },
                    { "2.5.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-mountain-city", "Province", 1, null, null, "102", "2.5", "/master/province", null },
                    { "2.5.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-tree-city", "City", 2, null, null, "102", "2.5", "/master/city", null },
                    { "2.5.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-bridge-circle-exclamation", "District", 3, null, null, "102", "2.5", "/master/district", null },
                    { "2.5.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Village", 4, null, null, "102", "2.5", "/master/village", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdt_packingtype");

            migrationBuilder.DropTable(
                name: "mdt_service");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.10");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.11");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.6");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.7");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.8");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.9");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.5.4");
        }
    }
}
