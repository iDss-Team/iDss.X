using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchSizeToBranch250610 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mdt_packingsize",
                keyColumn: "sizecode",
                keyValue: "X");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "mdt_counter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "branchsize",
                table: "mdt_branch",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.9",
                columns: new[] { "menuname", "path" },
                values: new object[] { "Packing", "" });

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[,]
                {
                    { "2.2.9.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-boxes-packing", "Packing Type", 1, null, null, "102", "2.2.9", "/master/packingtype", null },
                    { "2.2.9.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-boxes-packing", "Packing Size", 2, null, null, "102", "2.2.9", "/master/packingsize", null },
                    { "2.2.9.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-boxes-packing", "Packing Price", 3, null, null, "102", "2.2.9", "/master/packingprice", null }
                });

            migrationBuilder.UpdateData(
                table: "mdt_branch",
                keyColumn: "branchid",
                keyValue: 1,
                column: "branchsize",
                value: null);

            migrationBuilder.UpdateData(
                table: "mdt_branch",
                keyColumn: "branchid",
                keyValue: 2,
                column: "branchsize",
                value: null);

            migrationBuilder.InsertData(
                table: "mdt_packingsize",
                columns: new[] { "sizecode", "createdby", "createddate", "flag", "remarks", "sizename" },
                values: new object[] { "s", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Small" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.9.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.9.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "2.2.9.3");

            migrationBuilder.DeleteData(
                table: "mdt_packingsize",
                keyColumn: "sizecode",
                keyValue: "s");

            migrationBuilder.DropColumn(
                name: "branchsize",
                table: "mdt_branch");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "mdt_counter",
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
                keyValue: "2.2.9",
                columns: new[] { "menuname", "path" },
                values: new object[] { "Packing Type", "/master/packingtype" });

            migrationBuilder.InsertData(
                table: "mdt_packingsize",
                columns: new[] { "sizecode", "createdby", "createddate", "flag", "remarks", "sizename" },
                values: new object[] { "X", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Small" });
        }
    }
}
