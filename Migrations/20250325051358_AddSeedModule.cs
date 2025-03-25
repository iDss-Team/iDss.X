using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "114",
                column: "modulectgid",
                value: 4);

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "115",
                column: "modulectgid",
                value: 4);

            migrationBuilder.InsertData(
                table: "app_module",
                columns: new[] { "moduleid", "createdby", "createddate", "description", "flag", "icon", "modifieddate", "modifier", "modulectgid", "modulename", "modulesort" },
                values: new object[,]
                {
                    { "120", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages connections with external systems, APIs, and third-party services to ensure seamless data exchange and interoperability.", 1, "fund", null, null, 1, "Integration Management", 20 },
                    { "121", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensures consistency across multiple systems by managing automated data imports, exports, and synchronization processes.", 1, "fund", null, null, 2, "Data Synchronization", 21 },
                    { "122", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maintains data accuracy and reliability by implementing validation rules, detecting duplicates, and managing data correction processes.", 1, "fund", null, null, 2, "Data Quality & Validation", 22 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "120");

            migrationBuilder.DeleteData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "121");

            migrationBuilder.DeleteData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "122");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "114",
                column: "modulectgid",
                value: 5);

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "115",
                column: "modulectgid",
                value: 5);
        }
    }
}
