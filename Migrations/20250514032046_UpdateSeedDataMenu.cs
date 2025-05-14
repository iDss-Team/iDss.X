using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.4.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.4.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.6.2");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1.4",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.2",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.3",
                columns: new[] { "parentid", "path" },
                values: new object[] { "", null });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1.1",
                column: "icon",
                value: "fa-solid fa-list-ol");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1.2",
                column: "icon",
                value: "fa-solid fa-filter");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.3",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.4",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.5",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.6",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.6.1",
                column: "menuname",
                value: "Reconcile AWB");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.7",
                column: "path",
                value: null);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.7.2",
                column: "icon",
                value: "fa-solid fa-sack-xmark");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1",
                column: "path",
                value: "/pickup/pickuprequest");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1.4",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.2",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.3",
                columns: new[] { "parentid", "path" },
                values: new object[] { "6.2", "" });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1.1",
                column: "icon",
                value: "fa-solid fa-diamond");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1.2",
                column: "icon",
                value: "fa-solid fa-diamond");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.3",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.4",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.5",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.6",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.6.1",
                column: "menuname",
                value: "Reconcile Data");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.7",
                column: "path",
                value: "");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.7.2",
                column: "icon",
                value: "fa-solid fa-sack");

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[,]
                {
                    { "7.4.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "TBA", 2, null, null, "107", "7.4", "", null },
                    { "7.4.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "TBA", 3, null, null, "107", "7.4", "", null },
                    { "7.6.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "TBA", 2, null, null, "107", "7.6", "", null }
                });
        }
    }
}
