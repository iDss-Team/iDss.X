using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddShipmentDetailToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.3.2");

            migrationBuilder.CreateTable(
                name: "trx_shipmentdetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    refno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    apireqid = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    donumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    buyerorderno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    linehaul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    deliveryitem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    pickupdate = table.Column<DateOnly>(type: "date", nullable: false),
                    hubcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    pieces = table.Column<int>(type: "int", nullable: false),
                    actweight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    volweight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    chargeweight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    unitweight = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    service = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    packingtype = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    itemvalue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    curr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    isinsurance = table.Column<int>(type: "int", nullable: false),
                    intruction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sla = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    trxtype = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    session = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vouchercode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    iscod = table.Column<int>(type: "int", nullable: false),
                    isnfd = table.Column<int>(type: "int", nullable: false),
                    isrev = table.Column<int>(type: "int", nullable: false),
                    isedit = table.Column<int>(type: "int", nullable: false),
                    isnotif = table.Column<int>(type: "int", nullable: false),
                    isprint = table.Column<int>(type: "int", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_shipmentdetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_shipmentdetail_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.3.1",
                column: "parentid",
                value: "6.3");

            migrationBuilder.CreateIndex(
                name: "IX_trx_shipmentdetail_awb",
                table: "trx_shipmentdetail",
                column: "awb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trx_shipmentdetail_pickupno",
                table: "trx_shipmentdetail",
                column: "pickupno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trx_shipmentdetail");

            migrationBuilder.UpdateData(
                table: "app_menu",
                keyColumn: "menuid",
                keyValue: "6.3.1",
                column: "parentid",
                value: "6.2");

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[] { "6.3.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "TBA", 2, null, null, "106", "6.2", "", null });
        }
    }
}
