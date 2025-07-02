using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddStagingTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trx_staging",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    refno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    apireqid = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    donumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    buyerorderno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    pickupdate = table.Column<DateOnly>(type: "date", nullable: true),
                    linehaul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    deliveryitem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hubcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    pieces = table.Column<int>(type: "int", nullable: false),
                    actweight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    volweight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    chargeweight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    unitweight = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    service = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    packingtype = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    itemvalue = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    curr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    intruction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trxtype = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    session = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    branchori = table.Column<int>(type: "int", nullable: false),
                    acctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    shippername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    s_attname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    s_addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    s_addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    s_countrycode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    s_distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    s_cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    s_provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    s_postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    shplat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    shplong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    s_phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    s_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    oricode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    costcenter = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    branchcne = table.Column<int>(type: "int", nullable: true),
                    cnename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    c_attname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    c_addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    c_addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    c_countrycode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    c_distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    c_cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    c_provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    c_postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    cnelat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cnelong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    c_phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    c_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    descode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    attach1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    attach2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    vouchercode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isinsurance = table.Column<int>(type: "int", nullable: false),
                    iscod = table.Column<int>(type: "int", nullable: false),
                    codtype = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    codamount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    isnfd = table.Column<int>(type: "int", nullable: false),
                    isrev = table.Column<int>(type: "int", nullable: false),
                    isnotif = table.Column<int>(type: "int", nullable: false),
                    isdrop = table.Column<int>(type: "int", nullable: false),
                    isprod = table.Column<int>(type: "int", nullable: false),
                    deliverycost = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    packingcost = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    insurancecost = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    addcost = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    totaldiscount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    paymenttype = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    paymentgateway = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    refpayid = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    paymentstatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_staging", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_staging_mdt_account_acctno",
                        column: x => x.acctno,
                        principalTable: "mdt_account",
                        principalColumn: "acctno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_staging_mdt_branch_branchcne",
                        column: x => x.branchcne,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_staging_mdt_branch_branchori",
                        column: x => x.branchori,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_staging_mdt_district_c_distid",
                        column: x => x.c_distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_staging_mdt_district_s_distid",
                        column: x => x.s_distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_staging_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trx_staging_acctno",
                table: "trx_staging",
                column: "acctno");

            migrationBuilder.CreateIndex(
                name: "IX_trx_staging_branchcne",
                table: "trx_staging",
                column: "branchcne");

            migrationBuilder.CreateIndex(
                name: "IX_trx_staging_branchori",
                table: "trx_staging",
                column: "branchori");

            migrationBuilder.CreateIndex(
                name: "IX_trx_staging_c_distid",
                table: "trx_staging",
                column: "c_distid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_staging_pickupno",
                table: "trx_staging",
                column: "pickupno");

            migrationBuilder.CreateIndex(
                name: "IX_trx_staging_s_distid",
                table: "trx_staging",
                column: "s_distid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trx_staging");
        }
    }
}
