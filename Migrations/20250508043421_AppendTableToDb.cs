using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AppendTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_mdt_courier_couriercode",
                table: "mdt_courier",
                column: "couriercode");

            migrationBuilder.CreateTable(
                name: "mdt_awbinventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    userlock = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    flagprint = table.Column<int>(type: "int", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_awbinventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_mdt_awbinventory_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pum_pickuprequest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    apireqid = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    pickuptype = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    acctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    acctname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pickuppoint = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    addr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    postcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    picname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    branchid = table.Column<int>(type: "int", nullable: true),
                    branchname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    couriercode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    couriername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    transporttype = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    pickupdate = table.Column<DateOnly>(type: "date", nullable: false),
                    timefrom = table.Column<TimeOnly>(type: "time", nullable: false),
                    timeto = table.Column<TimeOnly>(type: "time", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_pickuprequest", x => x.id);
                    table.UniqueConstraint("AK_pum_pickuprequest_pickupno", x => x.pickupno);
                    table.ForeignKey(
                        name: "FK_pum_pickuprequest_mdt_account_acctno",
                        column: x => x.acctno,
                        principalTable: "mdt_account",
                        principalColumn: "acctno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pum_pickuprequest_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pum_pickuprequest_mdt_courier_couriercode",
                        column: x => x.couriercode,
                        principalTable: "mdt_courier",
                        principalColumn: "couriercode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pum_pickuprequest_mdt_district_distid",
                        column: x => x.distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pum_pickupstatuspool",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pickupstatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_pickupstatuspool", x => x.id);
                    table.ForeignKey(
                        name: "FK_pum_pickupstatuspool_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "101",
                column: "icon",
                value: "fa-solid fa-user-tie");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "102",
                column: "icon",
                value: "fa-solid fa-database");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "103",
                column: "icon",
                value: "fa-solid fa-handshake-simple");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "104",
                column: "icon",
                value: "fa-solid fa-people-group");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "105",
                column: "icon",
                value: "fa-solid fa-magnifying-glass-chart");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "106",
                column: "icon",
                value: "fa-solid fa-truck-moving");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "107",
                column: "icon",
                value: "fa-solid fa-plane-departure");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "108",
                column: "icon",
                value: "fa-solid fa-truck-plane");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "109",
                column: "icon",
                value: "fa-solid fa-plane-arrival");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "110",
                column: "icon",
                value: "fa-solid fa-reply");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "111",
                column: "icon",
                value: "fa-solid fa-file-invoice");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "112",
                column: "icon",
                value: "fa-solid fa-credit-card");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "113",
                column: "icon",
                value: "fa-solid fa-money-bill-wave");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "114",
                column: "icon",
                value: "fa-solid fa-shoe-prints");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "115",
                column: "icon",
                value: "fa-solid fa-glasses");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "116",
                column: "icon",
                value: "fa-solid fa-chart-line");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "117",
                column: "icon",
                value: "fa-solid fa-sack-dollar");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "118",
                column: "icon",
                value: "fa-solid fa-headset");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "119",
                column: "icon",
                value: "fa-solid fa-scale-balanced");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "120",
                column: "icon",
                value: "fa-solid fa-code-compare");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "121",
                column: "icon",
                value: "fa-solid fa-rotate");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "122",
                column: "icon",
                value: "fa-solid fa-list-check");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_courier_couriercode",
                table: "mdt_courier",
                column: "couriercode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mdt_awbinventory_awb",
                table: "mdt_awbinventory",
                column: "awb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mdt_awbinventory_branchid",
                table: "mdt_awbinventory",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickuprequest_acctno",
                table: "pum_pickuprequest",
                column: "acctno");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickuprequest_branchid",
                table: "pum_pickuprequest",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickuprequest_couriercode",
                table: "pum_pickuprequest",
                column: "couriercode");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickuprequest_distid",
                table: "pum_pickuprequest",
                column: "distid");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickuprequest_pickupno",
                table: "pum_pickuprequest",
                column: "pickupno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickupstatuspool_pickupno",
                table: "pum_pickupstatuspool",
                column: "pickupno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdt_awbinventory");

            migrationBuilder.DropTable(
                name: "pum_pickupstatuspool");

            migrationBuilder.DropTable(
                name: "pum_pickuprequest");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_mdt_courier_couriercode",
                table: "mdt_courier");

            migrationBuilder.DropIndex(
                name: "IX_mdt_courier_couriercode",
                table: "mdt_courier");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "101",
                column: "icon",
                value: "idcard");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "102",
                column: "icon",
                value: "database");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "103",
                column: "icon",
                value: "schedule");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "104",
                column: "icon",
                value: "schedule");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "105",
                column: "icon",
                value: "schedule");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "106",
                column: "icon",
                value: "schedule");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "107",
                column: "icon",
                value: "bank");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "108",
                column: "icon",
                value: "car");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "109",
                column: "icon",
                value: "interaction");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "110",
                column: "icon",
                value: "interaction");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "111",
                column: "icon",
                value: "interaction");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "112",
                column: "icon",
                value: "interaction");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "113",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "114",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "115",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "116",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "117",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "118",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "119",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "120",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "121",
                column: "icon",
                value: "fund");

            migrationBuilder.UpdateData(
                table: "app_module",
                keyColumn: "moduleid",
                keyValue: "122",
                column: "icon",
                value: "fund");
        }
    }
}
