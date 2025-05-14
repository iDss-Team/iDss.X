using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AppendMenuDataToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "menuname",
                table: "app_menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "1.1.2",
                column: "menusort",
                value: 2);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "1.2.2",
                column: "menusort",
                value: 2);

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[,]
                {
                    { "6.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-truck-ramp-box", "Pickup Entry", 1, null, null, "106", "", "/pickup/pickuprequest", null },
                    { "6.1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-calendar-plus", "Create Pickup Schedule", 1, null, null, "106", "6.1", "/pickup/entrypickupschedule", null },
                    { "6.1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-phone-volume", "Entry Pickup On-Call", 2, null, null, "106", "6.1", "/pickup/entrypickuponcall", null },
                    { "6.1.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-user-pen", "Entry Pickup Client", 3, null, null, "106", "6.1", "/pickup/entrypickupclient", null },
                    { "6.1.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Entry Pickup Custom", 4, null, null, "106", "6.1", "", null },
                    { "6.1.4.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Entry Pickup Danamon (Pickup)", 1, null, null, "106", "6.1.4", "/pickup/pickupdanamon", null },
                    { "6.1.4.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Entry Pickup Danamon (Retrieval)", 2, null, null, "106", "6.1.4", "/pickup/pickupdanamon", null },
                    { "6.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-cube", "Pickup Status", 2, null, null, "106", "", "", null },
                    { "6.2.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Assign Branch in Charge", 1, null, null, "106", "6.2", "/pickup/assignpickup", null },
                    { "6.2.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Assign Courier", 2, null, null, "106", "6.2", "/pickup/assigncourier", null },
                    { "6.2.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Reschedule Pickup", 3, null, null, "106", "6.2", "/pickup/reschedulepickup", null },
                    { "6.2.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Dispatch to Courier", 4, null, null, "106", "6.2", "/pickup/dispatchtocourier", null },
                    { "6.2.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Success Pikup", 5, null, null, "106", "6.2", "/pickup/successpickup", null },
                    { "6.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-cube", "Monitoring Pickup", 3, null, null, "106", "6.2", "", null },
                    { "6.3.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "View Timeline Status", 1, null, null, "106", "6.2", "/pickup/viewstatuspickup", null },
                    { "6.3.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "TBA", 2, null, null, "106", "6.2", "", null },
                    { "7.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-cube", "Pra-Delivery", 1, null, null, "107", "", "", null },
                    { "7.1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Airwaybill Inventory", 1, null, null, "107", "7.1", "/ocl/awbinventory", null },
                    { "7.1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Pra-Upload", 2, null, null, "107", "7.1", "/ocl/praupload", null },
                    { "7.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-floppy-disk", "Corporate Data Entry", 2, null, null, "107", "", "", null },
                    { "7.2.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data Primary", 1, null, null, "107", "7.2", "/ocl/entrydataprimary", null },
                    { "7.2.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data National", 2, null, null, "107", "7.2", "/ocl/entrydatanational", null },
                    { "7.2.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data Internal", 3, null, null, "107", "7.2", "/ocl/entrydatainternal", null },
                    { "7.2.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data COD", 4, null, null, "107", "7.2", "/ocl/entrydatacod", null },
                    { "7.2.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data Preprinted", 5, null, null, "107", "7.2", "/ocl/entrydatapriprinted", null },
                    { "7.2.6", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data trucking", 6, null, null, "107", "7.2", "/ocl/entrydatatrucking", null },
                    { "7.2.7", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data API", 7, null, null, "107", "7.2", "/ocl/entrydataapi", null },
                    { "7.2.8", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-file-excel", "Upload Data Primary", 8, null, null, "107", "7.2", "/ocl/uploaddataprimary", null },
                    { "7.2.9", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-file-excel", "Upload Data COD", 9, null, null, "107", "7.2", "/ocl/uploaddatacod", null },
                    { "7.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-floppy-disk", "Retail Data Entry", 3, null, null, "107", "", "", null },
                    { "7.3.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Retail Regular", 1, null, null, "107", "7.3", "/ocl/entryretailprimary", null },
                    { "7.3.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Retail NFD", 2, null, null, "107", "7.3", "/ocl/entryretailnfd", null },
                    { "7.3.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Retail API", 3, null, null, "107", "7.3", "/ocl/entryretailapi", null },
                    { "7.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-earth-americas", "International Data Entry", 4, null, null, "107", "", "", null },
                    { "7.4.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Intl Regular", 1, null, null, "107", "7.4", "/ocl/entrydataintl", null },
                    { "7.4.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "TBA", 2, null, null, "107", "7.4", "", null },
                    { "7.4.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "TBA", 3, null, null, "107", "7.4", "", null },
                    { "7.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-tags", "Shipping Label", 5, null, null, "107", "", "", null },
                    { "7.5.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-print", "Print AWB Primary", 1, null, null, "107", "7.5", "/ocl/printawbprimary", null },
                    { "7.5.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-print", "Print AWB Internal", 2, null, null, "107", "7.5", "/ocl/printawbinternal", null },
                    { "7.5.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-print", "Print AWB Intl", 3, null, null, "107", "7.5", "/ocl/printawbnational", null },
                    { "7.6", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-cube", "Shipment Validation", 6, null, null, "107", "", "", null },
                    { "7.6.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Reconcile Data", 1, null, null, "107", "7.6", "/ocl/shipmentreconcile", null },
                    { "7.6.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "TBA", 2, null, null, "107", "7.6", "", null },
                    { "7.7", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-box-open", "Bagging", 7, null, null, "107", "", "", null },
                    { "7.7.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-box", "Mother Bag", 1, null, null, "107", "7.7", "/ocl/motherbag", null },
                    { "7.7.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-sack", "Baby Bag", 2, null, null, "107", "7.7", "/ocl/babybag", null },
                    { "7.7.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-boxes-packing", "Loose Bag", 3, null, null, "107", "7.7", "/ocl/loosebag", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1.4");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1.4.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.1.4.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.2.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.2.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.2.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.2.4");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.2.5");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.3.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.3.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.1.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.4");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.5");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.6");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.7");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.8");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.2.9");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.3.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.3.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.3.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.4");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.4.1");

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
                keyValue: "7.5");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.5.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.5.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.5.3");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.6");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.6.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.6.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.7");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.7.1");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.7.2");

            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "7.7.3");

            migrationBuilder.AlterColumn<string>(
                name: "menuname",
                table: "app_menu",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "1.1.2",
                column: "menusort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "1.2.2",
                column: "menusort",
                value: 1);
        }
    }
}
