using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_modulectg",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modulectgname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modulectgsort = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_modulectg", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mdt_checkpoint",
                columns: table => new
                {
                    cpcode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    cpname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_checkpoint", x => x.cpcode);
                });

            migrationBuilder.CreateTable(
                name: "mdt_industry",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    industryname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_industry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mdt_province",
                columns: table => new
                {
                    provid = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_province", x => x.provid);
                });

            migrationBuilder.CreateTable(
                name: "app_module",
                columns: table => new
                {
                    moduleid = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    modulename = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modulesort = table.Column<int>(type: "int", nullable: false),
                    modulectgid = table.Column<int>(type: "int", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_module", x => x.moduleid);
                    table.ForeignKey(
                        name: "FK_app_module_app_modulectg_modulectgid",
                        column: x => x.modulectgid,
                        principalTable: "app_modulectg",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_city",
                columns: table => new
                {
                    cityid = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    citymerger = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    citycode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    hubcode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    provid = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_city", x => x.cityid);
                    table.ForeignKey(
                        name: "FK_mdt_city_mdt_province_provid",
                        column: x => x.provid,
                        principalTable: "mdt_province",
                        principalColumn: "provid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "app_menu",
                columns: table => new
                {
                    menuid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    menuname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menusort = table.Column<int>(type: "int", nullable: false),
                    parentid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    moduleid = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    properties = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_menu", x => x.menuid);
                    table.ForeignKey(
                        name: "FK_app_menu_app_module_moduleid",
                        column: x => x.moduleid,
                        principalTable: "app_module",
                        principalColumn: "moduleid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_district",
                columns: table => new
                {
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    distname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cityid = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_district", x => x.distid);
                    table.ForeignKey(
                        name: "FK_mdt_district_mdt_city_cityid",
                        column: x => x.cityid,
                        principalTable: "mdt_city",
                        principalColumn: "cityid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_village",
                columns: table => new
                {
                    villid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    villname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_village", x => x.villid);
                    table.ForeignKey(
                        name: "FK_mdt_village_mdt_district_distid",
                        column: x => x.distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_branch",
                columns: table => new
                {
                    branchid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branchname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    branchcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    branchtype = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    addr3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    villid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    distname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    phonealt = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    honame = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    picname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    picno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    citycode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_branch", x => x.branchid);
                    table.ForeignKey(
                        name: "FK_mdt_branch_mdt_village_villid",
                        column: x => x.villid,
                        principalTable: "mdt_village",
                        principalColumn: "villid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_agent",
                columns: table => new
                {
                    agentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    agentname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    agentcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    addr3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    villid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    distname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    phonealt = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    picname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    picno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    citycode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    comission = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_agent", x => x.agentid);
                    table.ForeignKey(
                        name: "FK_mdt_agent_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mdt_agent_mdt_village_villid",
                        column: x => x.villid,
                        principalTable: "mdt_village",
                        principalColumn: "villid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_cif",
                columns: table => new
                {
                    cif = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    cifname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    industryid = table.Column<int>(type: "int", nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_cif", x => x.cif);
                    table.ForeignKey(
                        name: "FK_mdt_cif_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mdt_cif_mdt_industry_industryid",
                        column: x => x.industryid,
                        principalTable: "mdt_industry",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mdt_counter",
                columns: table => new
                {
                    counterid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    countercode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    addr3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    villid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    distname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    phonealt = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    picname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    picno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    citycode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    comission = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_counter", x => x.counterid);
                    table.ForeignKey(
                        name: "FK_mdt_counter_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mdt_counter_mdt_village_villid",
                        column: x => x.villid,
                        principalTable: "mdt_village",
                        principalColumn: "villid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_courier",
                columns: table => new
                {
                    nip = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    couriername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    couriercode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    freqdelivery = table.Column<int>(type: "int", nullable: true),
                    fuelquota = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_courier", x => x.nip);
                    table.ForeignKey(
                        name: "FK_mdt_courier_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mdt_courier_mdt_district_distid",
                        column: x => x.distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_cro",
                columns: table => new
                {
                    crocode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    croname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nip = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    salestarget = table.Column<int>(type: "int", nullable: true),
                    joindate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_cro", x => x.crocode);
                    table.ForeignKey(
                        name: "FK_mdt_cro_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_account",
                columns: table => new
                {
                    acctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    acctname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    cif = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    lob = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    costcenter = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    bankacctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    bankacctname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    bankcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    frp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    agreedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    agreeexpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    termofpayment = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    creditlimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    creditperiod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    iscod = table.Column<int>(type: "int", nullable: true),
                    feecod = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    isintl = table.Column<int>(type: "int", nullable: true),
                    isnl = table.Column<int>(type: "int", nullable: true),
                    discrates = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    isrev = table.Column<int>(type: "int", nullable: true),
                    istrace = table.Column<int>(type: "int", nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_account", x => x.acctno);
                    table.ForeignKey(
                        name: "FK_mdt_account_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mdt_account_mdt_cif_cif",
                        column: x => x.cif,
                        principalTable: "mdt_cif",
                        principalColumn: "cif",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_accountaddr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    acctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    addrtype = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    addr3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    picname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_accountaddr", x => x.id);
                    table.ForeignKey(
                        name: "FK_mdt_accountaddr_mdt_account_acctno",
                        column: x => x.acctno,
                        principalTable: "mdt_account",
                        principalColumn: "acctno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mdt_accountaddr_mdt_district_distid",
                        column: x => x.distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_accountcro",
                columns: table => new
                {
                    acctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    crocode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_accountcro", x => new { x.acctno, x.crocode });
                    table.ForeignKey(
                        name: "FK_mdt_accountcro_mdt_account_acctno",
                        column: x => x.acctno,
                        principalTable: "mdt_account",
                        principalColumn: "acctno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mdt_accountcro_mdt_cro_crocode",
                        column: x => x.crocode,
                        principalTable: "mdt_cro",
                        principalColumn: "crocode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mdt_branchaccount",
                columns: table => new
                {
                    branchid = table.Column<int>(type: "int", nullable: false),
                    acctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_mdt_branchaccount_mdt_account_acctno",
                        column: x => x.acctno,
                        principalTable: "mdt_account",
                        principalColumn: "acctno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mdt_branchaccount_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "app_modulectg",
                columns: new[] { "id", "createdby", "createddate", "modulectgname", "modulectgsort" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administration & System Management", 1 },
                    { 2, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Management", 2 },
                    { 3, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pre-Delivery", 3 },
                    { 4, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In-Transit", 4 },
                    { 5, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post-Delivery", 5 },
                    { 6, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back Office", 6 },
                    { 7, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warehouse Management", 7 }
                });

            migrationBuilder.InsertData(
                table: "mdt_province",
                columns: new[] { "provid", "provname" },
                values: new object[,]
                {
                    { "11", "ACEH" },
                    { "12", "SUMATERA UTARA" },
                    { "13", "SUMATERA BARAT" },
                    { "14", "RIAU" },
                    { "15", "JAMBI" },
                    { "16", "SUMATERA SELATAN" },
                    { "17", "BENGKULU" },
                    { "18", "LAMPUNG" },
                    { "19", "BANGKA BELITUNG" },
                    { "21", "KEPULAUAN RIAU" },
                    { "31", "DKI JAKARTA" },
                    { "32", "JAWA BARAT" },
                    { "33", "JAWA TENGAH" },
                    { "34", "YOGYAKARTA" },
                    { "35", "JAWA TIMUR" },
                    { "36", "BANTEN" },
                    { "51", "BALI" },
                    { "52", "NUSA TENGGARA BARAT" },
                    { "53", "NUSA TENGGARA TIMUR" },
                    { "61", "KALIMANTAN BARAT" },
                    { "62", "KALIMANTAN TENGAH" },
                    { "63", "KALIMANTAN SELATAN" },
                    { "64", "KALIMANTAN TIMUR" },
                    { "65", "KALIMANTAN UTARA" },
                    { "71", "SULAWESI UTARA" },
                    { "72", "SULAWESI TENGAH" },
                    { "73", "SULAWESI SELATAN" },
                    { "74", "SULAWESI TENGGARA" },
                    { "75", "GORONTALO" },
                    { "76", "SULAWESI BARAT" },
                    { "81", "MALUKU" },
                    { "82", "MALUKU UTARA" },
                    { "91", "PAPUA" },
                    { "92", "PAPUA BARAT" }
                });

            migrationBuilder.InsertData(
                table: "app_module",
                columns: new[] { "moduleid", "createdby", "createddate", "description", "flag", "icon", "modifieddate", "modifier", "modulectgid", "modulename", "modulesort" },
                values: new object[,]
                {
                    { "101", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages system settings, permissions and general platform configurations", 1, "idcard", null, null, 1, "Administrasion", 1 },
                    { "102", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stores and manages core data", 1, "database", null, null, 2, "Master Data", 2 },
                    { "103", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handles potential customer prospects, including registration, analysis, and follow-ups to be regular customers", 1, "schedule", null, null, 3, "Prospect Customer Relationship", 3 },
                    { "104", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages relationships with potential agents, registration, evaluation, and communication to expand the operational network.", 1, "schedule", null, null, 3, "Prospect Agent Relationship", 4 },
                    { "105", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Records and manages the sales process, pricing and monitoring team performance and targets.", 1, "schedule", null, null, 3, "Sales Management", 5 },
                    { "106", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schedules and manages pickup from customers, including route optimization and field team coordination.", 1, "schedule", null, null, 3, "Pickup Management", 6 },
                    { "107", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Controls and manages the outbound shipment of goods from origin distribution centers to final destinations.", 1, "bank", null, null, 4, "Outbound Control Library", 7 },
                    { "108", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitors and manages the movement of goods during intercity or inter-hub transportation.", 1, "car", null, null, 4, "Linehaul Control Library", 8 },
                    { "109", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handles the receiving of incoming shipments from distribution centers until delivery to recipient.", 1, "interaction", null, null, 4, "Inbound Control Library", 9 },
                    { "110", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages the return process due to incorrect shipments, damaged goods, or other return policies.", 1, "interaction", null, null, 4, "Return Management", 10 },
                    { "111", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inbound Processing Center", 0, "interaction", null, null, 4, "Billing Delivery System", 11 },
                    { "112", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inbound Processing Center", 0, "interaction", null, null, 4, "Credit Card System", 12 },
                    { "113", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handles cash payments upon delivery, including transaction recording and coordination with couriers.", 1, "fund", null, null, 5, "Cash on Delivery", 13 },
                    { "114", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides real-time tracking for customers and internal teams to monitor shipment status and locations.", 1, "fund", null, null, 5, "Shipment Tracking Visibility", 14 },
                    { "115", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addresses operational issues such as delivery delays, lost shipments, or customer complaints, and records provided solutions.", 1, "fund", null, null, 5, "Problem Handling & Solution", 15 },
                    { "116", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generates reports and data analysis related to operational performance, sales, and financial aspects to support strategic decision-making.", 1, "fund", null, null, 5, "Analytics & Reporting", 16 },
                    { "117", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages company financials, including transaction records, operational expenses, payment reconciliation, and invoicing.", 1, "fund", null, null, 5, "Finance Management", 17 },
                    { "118", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides customer support to answer inquiries, handle complaints, and offer shipment and service-related information.", 1, "fund", null, null, 5, "Customer Care Services", 18 },
                    { "119", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensures compliance with industry regulations and legal requirements, including document management and audit processes.", 1, "fund", null, null, 6, "Legal & Compliance", 19 }
                });

            migrationBuilder.InsertData(
                table: "mdt_city",
                columns: new[] { "cityid", "citycode", "citymerger", "cityname", "hubcode", "provid" },
                values: new object[,]
                {
                    { "1101", "TTN", "ACEH SELATAN", "KAB ACEH SELATAN", "BTJ", "11" },
                    { "1102", "KTN", "ACEH TENGGARA", "KAB ACEH TENGGARA", "BTJ", "11" },
                    { "1103", "LGS", "ACEH TIMUR", "KAB ACEH TIMUR", "MES", "11" },
                    { "1104", "TKN", "ACEH TENGAH", "KAB ACEH TENGAH", "BTJ", "11" },
                    { "1105", "MBO", "ACEH BARAT", "KAB ACEH BARAT", "BTJ", "11" },
                    { "1106", "JTH", "ACEH BESAR", "KAB ACEH BESAR", "BTJ", "11" },
                    { "1107", "SGI", "PIDIE", "KAB PIDIE", "BTJ", "11" },
                    { "1108", "LSK", "ACEH UTARA", "KAB ACEH UTARA", "MES", "11" },
                    { "1109", "SNB", "SIMEULUE", "KAB SIMEULUE", "BTJ", "11" },
                    { "1110", "SKL", "ACEH SINGKIL", "KAB ACEH SINGKIL", "BTJ", "11" },
                    { "1111", "BIR", "BIREUEN", "KAB BIREUEN", "MES", "11" },
                    { "1112", "BPD", "ACEH BARAT DAYA", "KAB ACEH BARAT DAYA", "BTJ", "11" },
                    { "1113", "BKJ", "GAYO LUES", "KAB GAYO LUES", "BTJ", "11" },
                    { "1114", "CAG", "ACEH JAYA", "KAB ACEH JAYA", "BTJ", "11" },
                    { "1115", "SKM", "NAGAN RAYA", "KAB NAGAN RAYA", "BTJ", "11" },
                    { "1116", "KRB", "ACEH TAMIANG", "KAB ACEH TAMIANG", "MES", "11" },
                    { "1117", "STR", "BENER MERIAH", "KAB BENER MERIAH", "BTJ", "11" },
                    { "1118", "MRN", "PIDIE JAYA", "KAB PIDIE JAYA", "BTJ", "11" },
                    { "1171", "BTJ", "BANDA ACEH", "KOTA BANDA ACEH", "BTJ", "11" },
                    { "1172", "SBG", "SABANG", "KOTA SABANG", "BTJ", "11" },
                    { "1173", "LSW", "LHOKSEUMAWE", "KOTA LHOKSEUMAWE", "MES", "11" },
                    { "1174", "LGS", "LANGSA", "KOTA LANGSA", "MES", "11" },
                    { "1175", "SUS", "SUBULUSSALAM", "KOTA SUBULUSSALAM", "BTJ", "11" },
                    { "1201", "SBG", "TAPANULI", "KAB TAPANULI TENGAH", "MES", "12" },
                    { "1202", "TRT", "TAPANULI", "KAB TAPANULI UTARA", "MES", "12" },
                    { "1203", "PSP", "TAPANULI", "KAB TAPANULI SELATAN", "MES", "12" },
                    { "1204", "GST", "NIAS", "KAB NIAS", "MES", "12" },
                    { "1205", "STB", "LANGKAT", "KAB LANGKAT", "MES", "12" },
                    { "1206", "KBJ", "KARO", "KAB KARO", "MES", "12" },
                    { "1207", "LBP", "DELI SERDANG", "KAB DELI SERDANG", "MES", "12" },
                    { "1208", "SIM", "SIMALUNGUN", "KAB SIMALUNGUN", "MES", "12" },
                    { "1209", "KIS", "ASAHAN", "KAB ASAHAN", "MES", "12" },
                    { "1210", "RTP", "LABUHANBATU", "KAB LABUHANBATU", "MES", "12" },
                    { "1211", "SKD", "DAIRI", "KAB DAIRI", "MES", "12" },
                    { "1212", "BLG", "TOBA SAMOSIR", "KAB TOBA SAMOSIR", "MES", "12" },
                    { "1213", "PYB", "MANDAILING NATAL", "KAB MANDAILING NATAL", "MES", "12" },
                    { "1214", "TLD", "NIAS", "KAB NIAS SELATAN", "MES", "12" },
                    { "1215", "SAL", "PAKPAK BHARAT", "KAB PAKPAK BHARAT", "MES", "12" },
                    { "1216", "DLS", "HUMBANG HASUNDUTAN", "KAB HUMBANG HASUNDUTAN", "MES", "12" },
                    { "1217", "PRR", "SAMOSIR", "KAB SAMOSIR", "MES", "12" },
                    { "1218", "SRH", "SERDANG BEDAGAI", "KAB SERDANG BEDAGAI", "MES", "12" },
                    { "1219", "LPM", "BATU BARA", "KAB BATU BARA", "MES", "12" },
                    { "1220", "GNT", "PADANG LAWAS", "KAB PADANG LAWAS UTARA", "MES", "12" },
                    { "1221", "SBH", "PADANG LAWAS", "KAB PADANG LAWAS", "MES", "12" },
                    { "1222", "KPI", "LABUHANBATU", "KAB LABUHANBATU SELATAN", "MES", "12" },
                    { "1223", "AKK", "LABUHANBATU", "KAB LABUHANBATU UTARA", "MES", "12" },
                    { "1224", "LTU", "NIAS", "KAB NIAS UTARA", "MES", "12" },
                    { "1225", "LHM", "NIAS", "KAB NIAS BARAT", "MES", "12" },
                    { "1271", "MES", "MEDAN", "KOTA MEDAN", "MES", "12" },
                    { "1272", "PMS", "PEMATANG SIANTAR", "KOTA PEMATANG SIANTAR", "MES", "12" },
                    { "1273", "SBG", "SIBOLGA", "KOTA SIBOLGA", "MES", "12" },
                    { "1274", "TJB", "TANJUNG BALAI", "KOTA TANJUNG BALAI", "MES", "12" },
                    { "1275", "BNJ", "BINJAI", "KOTA BINJAI", "MES", "12" },
                    { "1276", "TBT", "TEBING TINGGI", "KOTA TEBING TINGGI", "MES", "12" },
                    { "1277", "PSP", "PADANGSIDIMPUAN", "KOTA PADANGSIDIMPUAN", "MES", "12" },
                    { "1278", "GNS", "GUNUNGSITOLI", "KOTA GUNUNGSITOLI", "MES", "12" },
                    { "1301", "PSR", "PESISIR SELATAN", "KAB PESISIR SELATAN", "PDG", "13" },
                    { "1302", "SOL", "SOLOK", "KAB SOLOK", "PDG", "13" },
                    { "1303", "SJJ", "SIJUNJUNG", "KAB SIJUNJUNG", "PDG", "13" },
                    { "1304", "TDR", "TANAH DATAR", "KAB TANAH DATAR", "PDG", "13" },
                    { "1305", "PPR", "PADANG PARIAMAN", "KAB PADANG PARIAMAN", "PDG", "13" },
                    { "1306", "AGM", "AGAM", "KAB AGAM", "PDG", "13" },
                    { "1307", "LPH", "LIMA PULUH KOTA", "KAB LIMA PULUH KOTA", "PDG", "13" },
                    { "1308", "PSM", "PASAMAN", "KAB PASAMAN", "PDG", "13" },
                    { "1309", "MTW", "KEPULAUAN MENTAWAI", "KAB KEPULAUAN MENTAWAI", "PDG", "13" },
                    { "1310", "DMR", "DHARMASRAYA", "KAB DHARMASRAYA", "PDG", "13" },
                    { "1311", "SSL", "SOLOK", "KAB SOLOK SELATAN", "PDG", "13" },
                    { "1312", "PSB", "PASAMAN", "KAB PASAMAN BARAT", "PDG", "13" },
                    { "1371", "PDG", "PADANG", "KOTA PADANG", "PDG", "13" },
                    { "1372", "SLK", "SOLOK", "KOTA SOLOK", "PDG", "13" },
                    { "1373", "SWL", "SAWAHLUNTO", "KOTA SAWAHLUNTO", "PDG", "13" },
                    { "1374", "PPJ", "PADANG PANJANG", "KOTA PADANG PANJANG", "PDG", "13" },
                    { "1375", "BKT", "BUKITTINGGI", "KOTA BUKITTINGGI", "PDG", "13" },
                    { "1376", "PKY", "PAYAKUMBUH", "KOTA PAYAKUMBUH", "PDG", "13" },
                    { "1377", "PRM", "PARIAMAN", "KOTA PARIAMAN", "PDG", "13" },
                    { "1401", "BKN", "KAMPAR", "KAB KAMPAR", "PKU", "14" },
                    { "1402", "RGT", "INDRAGIRI HULU", "KAB INDRAGIRI HULU", "PKU", "14" },
                    { "1403", "BLS", "BENGKALIS", "KAB BENGKALIS", "PKU", "14" },
                    { "1404", "TBH", "INDRAGIRI HILIR", "KAB INDRAGIRI HILIR", "PKU", "14" },
                    { "1405", "PKK", "PELALAWAN", "KAB PELALAWAN", "PKU", "14" },
                    { "1406", "PRP", "ROKAN HULU", "KAB ROKAN HULU", "PKU", "14" },
                    { "1407", "UJT", "ROKAN HILIR", "KAB ROKAN HILIR", "PKU", "14" },
                    { "1408", "SAK", "SIAK", "KAB SIAK", "PKU", "14" },
                    { "1409", "TLK", "KUANTAN SINGINGI", "KAB KUANTAN SINGINGI", "PKU", "14" },
                    { "1410", "TTG", "KEPULAUAN MERANTI", "KAB KEPULAUAN MERANTI", "PKU", "14" },
                    { "1471", "PKU", "PEKANBARU", "KOTA PEKANBARU", "PKU", "14" },
                    { "1472", "DUM", "DUMAI", "KOTA DUMAI", "PKU", "14" },
                    { "1501", "KRC", "KERINCI", "KAB KERINCI", "DJB", "15" },
                    { "1502", "MRG", "MERANGIN", "KAB MERANGIN", "DJB", "15" },
                    { "1503", "SAR", "SAROLANGUN", "KAB SAROLANGUN", "DJB", "15" },
                    { "1504", "MBO", "BATANGHARI", "KAB BATANGHARI", "DJB", "15" },
                    { "1505", "MJA", "MUARO JAMBI", "KAB MUARO JAMBI", "DJB", "15" },
                    { "1506", "KTU", "TANJUNG JABUNG", "KAB TANJUNG JABUNG BARAT", "DJB", "15" },
                    { "1507", "MSA", "TANJUNG JABUNG", "KAB TANJUNG JABUNG TIMUR", "DJB", "15" },
                    { "1508", "MRB", "BUNGO", "KAB BUNGO", "MRB", "15" },
                    { "1509", "MTE", "TEBO", "KAB TEBO", "DJB", "15" },
                    { "1571", "DJB", "JAMBI", "KOTA JAMBI", "DJB", "15" },
                    { "1572", "SPE", "SUNGAI PENUH", "KOTA SUNGAI PENUH", "DJB", "15" },
                    { "1601", "BTA", "OGAN KOMERING ULU", "KAB OGAN KOMERING ULU", "PLM", "16" },
                    { "1602", "OKI", "OGAN KOMERING ILIR", "KAB OGAN KOMERING ILIR", "PLM", "16" },
                    { "1603", "MRE", "MUARA ENIM", "KAB MUARA ENIM", "PLM", "16" },
                    { "1604", "LHT", "LAHAT", "KAB LAHAT", "PLM", "16" },
                    { "1605", "MRA", "MUSI RAWAS", "KAB MUSI RAWAS", "PLM", "16" },
                    { "1606", "MBA", "MUSI BANYUASIN", "KAB MUSI BANYUASIN", "PLM", "16" },
                    { "1607", "BYA", "BANYUASIN", "KAB BANYUASIN", "PLM", "16" },
                    { "1608", "OKU", "OGAN KOMERING ULU TIMUR", "KAB OGAN KOMERING ULU TIMUR", "PLM", "16" },
                    { "1609", "OKU", "OGAN KOMERING ULU SELATAN", "KAB OGAN KOMERING ULU SELATAN", "PLM", "16" },
                    { "1610", "OGI", "OGAN ILIR", "KAB OGAN ILIR", "PLM", "16" },
                    { "1611", "PDO", "EMPAT LAWANG", "KAB EMPAT LAWANG", "PLM", "16" },
                    { "1612", "PNA", "PENUKAL ABAB", "KAB PENUKAL ABAB", "PLM", "16" },
                    { "1613", "MRU", "MUSI RAWAS UTARA", "KAB MUSI RAWAS UTARA", "PLM", "16" },
                    { "1671", "PLM", "PALEMBANG", "KOTA PALEMBANG", "PLM", "16" },
                    { "1672", "PGA", "PAGAR ALAM", "KOTA PAGAR ALAM", "PLM", "16" },
                    { "1673", "LLG", "LUBUK LINGGAU", "KOTA LUBUK LINGGAU", "PLM", "16" },
                    { "1674", "PRB", "PRABUMULIH", "KOTA PRABUMULIH", "PLM", "16" },
                    { "1701", "MNN", "BENGKULU SELATAN", "KAB BENGKULU SELATAN", "BKS", "17" },
                    { "1702", "CRP", "REJANG LEBONG", "KAB REJANG LEBONG", "BKS", "17" },
                    { "1703", "ARM", "BENGKULU UTARA", "KAB BENGKULU UTARA", "BKS", "17" },
                    { "1704", "BTN", "KAUR", "KAB KAUR", "BKS", "17" },
                    { "1705", "SLM", "SELUMA", "KAB SELUMA", "BKS", "17" },
                    { "1706", "MPC", "MUKO MUKO", "KAB MUKO MUKO", "BKS", "17" },
                    { "1707", "LBG", "LEBONG", "KAB LEBONG", "BKS", "17" },
                    { "1708", "KPH", "KEPAHIANG", "KAB KEPAHIANG", "BKS", "17" },
                    { "1709", "KRT", "BENGKULU TENGAH", "KAB BENGKULU TENGAH", "BKS", "17" },
                    { "1771", "BKS", "BENGKULU", "KOTA BENGKULU", "BKS", "17" },
                    { "1801", "LPS", "LAMPUNG SELATAN", "KAB LAMPUNG SELATAN", "TKG", "18" },
                    { "1802", "LPT", "LAMPUNG TENGAH", "KAB LAMPUNG TENGAH", "TKG", "18" },
                    { "1803", "LPU", "LAMPUNG UTARA", "KAB LAMPUNG UTARA", "TKG", "18" },
                    { "1804", "LPB", "LAMPUNG BARAT", "KAB LAMPUNG BARAT", "TKG", "18" },
                    { "1805", "TBA", "TULANG BAWANG", "KAB TULANG BAWANG", "TKG", "18" },
                    { "1806", "TGS", "TANGGAMUS", "KAB TANGGAMUS", "TKG", "18" },
                    { "1807", "LTM", "LAMPUNG TIMUR", "KAB LAMPUNG TIMUR", "TKG", "18" },
                    { "1808", "WKN", "WAY KANAN", "KAB WAY KANAN", "TKG", "18" },
                    { "1809", "PSR", "PESAWARAN", "KAB PESAWARAN", "TKG", "18" },
                    { "1810", "PSW", "PRINGSEWU", "KAB PRINGSEWU", "TKG", "18" },
                    { "1811", "TBM", "MESUJI", "KAB MESUJI", "TKG", "18" },
                    { "1812", "TBB", "TULANG BAWANG", "KAB TULANG BAWANG BARAT", "TKG", "18" },
                    { "1813", "LPB", "PESISIR BARAT", "KAB PESISIR BARAT", "TKG", "18" },
                    { "1871", "TKG", "BANDAR LAMPUNG", "KOTA BANDAR LAMPUNG", "TKG", "18" },
                    { "1872", "TKG", "METRO", "KOTA METRO", "TKG", "18" },
                    { "1901", "SGL", "BANGKA", "KAB BANGKA", "PGK", "19" },
                    { "1902", "TJQ", "BELITUNG", "KAB BELITUNG", "TJQ", "19" },
                    { "1903", "TBL", "BANGKA SELATAN", "KAB BANGKA SELATAN", "PGK", "19" },
                    { "1904", "KBA", "BANGKA TENGAH", "KAB BANGKA TENGAH", "PGK", "19" },
                    { "1905", "MTK", "BANGKA BARAT", "KAB BANGKA BARAT", "PGK", "19" },
                    { "1906", "MGR", "BELITUNG TIMUR", "KAB BELITUNG TIMUR", "TJQ", "19" },
                    { "1971", "PGK", "PANGKAL PINANG", "KOTA PANGKAL PINANG", "PGK", "19" },
                    { "2101", "TNJ", "BINTAN", "KAB BINTAN", "TNJ", "21" },
                    { "2102", "TBK", "KARIMUN", "KAB KARIMUN", "BTH", "21" },
                    { "2103", "NTX", "NATUNA", "KAB NATUNA", "NTX", "21" },
                    { "2104", "DKL", "LINGGA", "KAB LINGGA", "TNJ", "21" },
                    { "2105", "NWK", "KEPULAUAN ANAMBAS", "KAB KEPULAUAN ANAMBAS", "BTH", "21" },
                    { "2171", "BTH", "BATAM", "KOTA BATAM", "BTH", "21" },
                    { "2172", "TNJ", "TANJUNG PINANG", "KOTA TANJUNG PINANG", "TNJ", "21" },
                    { "3101", "PPJ", "KEPULAUAN SERIBU", "KAB ADM KEP SERIBU", "CGK", "31" },
                    { "3171", "CGK", "JAKARTA PUSAT", "KOTA ADM JAKARTA PUSAT", "CGK", "31" },
                    { "3172", "CGK", "JAKARTA UTARA", "KOTA ADM JAKARTA UTARA", "CGK", "31" },
                    { "3173", "CGK", "JAKARTA BARAT", "KOTA ADM JAKARTA BARAT", "CGK", "31" },
                    { "3174", "CGK", "JAKARTA SELATAN", "KOTA ADM JAKARTA SELATAN", "CGK", "31" },
                    { "3175", "CGK", "JAKARTA TIMUR", "KOTA ADM JAKARTA TIMUR", "CGK", "31" },
                    { "3201", "BOO", "BOGOR", "KAB BOGOR", "BOO", "32" },
                    { "3202", "SMI", "SUKABUMI", "KAB SUKABUMI", "SMI", "32" },
                    { "3203", "CIJ", "CIANJUR", "KAB CIANJUR", "CIJ", "32" },
                    { "3204", "BDO", "BANDUNG", "KAB BANDUNG", "BDO", "32" },
                    { "3205", "GRT", "GARUT", "KAB GARUT", "GRT", "32" },
                    { "3206", "TSY", "TASIKMALAYA", "KAB TASIKMALAYA", "TSY", "32" },
                    { "3207", "CMI", "CIAMIS", "KAB CIAMIS", "TSY", "32" },
                    { "3208", "KGN", "KUNINGAN", "KAB KUNINGAN", "KGN", "32" },
                    { "3209", "CBN", "CIREBON", "KAB CIREBON", "CBN", "32" },
                    { "3210", "KJT", "MAJALENGKA", "KAB MAJALENGKA", "KJT", "32" },
                    { "3211", "BDO", "SUMEDANG", "KAB SUMEDANG", "BDO", "32" },
                    { "3212", "CBN", "INDRAMAYU", "KAB INDRAMAYU", "CBN", "32" },
                    { "3213", "CKP", "SUBANG", "KAB SUBANG", "CKP", "32" },
                    { "3214", "CKP", "PURWAKARTA", "KAB PURWAKARTA", "CKP", "32" },
                    { "3215", "CKP", "KARAWANG", "KAB KARAWANG", "CKP", "32" },
                    { "3216", "BKI", "BEKASI", "KAB BEKASI", "BKI", "32" },
                    { "3217", "BDO", "BANDUNG", "KAB BANDUNG BARAT", "BDO", "32" },
                    { "3218", "BJR", "PANGANDARAN", "KAB PANGANDARAN", "TSY", "32" },
                    { "3271", "BOO", "BOGOR", "KOTA BOGOR", "BOO", "32" },
                    { "3272", "SMI", "SUKABUMI", "KOTA SUKABUMI", "SMI", "32" },
                    { "3273", "BDO", "BANDUNG", "KOTA BANDUNG", "BDO", "32" },
                    { "3274", "CBN", "CIREBON", "KOTA CIREBON", "CBN", "32" },
                    { "3275", "BKI", "BEKASI", "KOTA BEKASI", "BKI", "32" },
                    { "3276", "DPK", "DEPOK", "KOTA DEPOK", "DPK", "32" },
                    { "3277", "BDO", "CIMAHI", "KOTA CIMAHI", "BDO", "32" },
                    { "3278", "TSY", "TASIKMALAYA", "KOTA TASIKMALAYA", "TSY", "32" },
                    { "3279", "BJR", "BANJAR", "KOTA BANJAR", "TSY", "32" },
                    { "3301", "CXP", "CILACAP", "KAB CILACAP", "CXP", "33" },
                    { "3302", "PWO", "BANYUMAS", "KAB BANYUMAS", "PWO", "33" },
                    { "3303", "PWL", "PURBALINGGA", "KAB PURBALINGGA", "PWO", "33" },
                    { "3304", "BJG", "BANJARNEGARA", "KAB BANJARNEGARA", "BJG", "33" },
                    { "3305", "KBM", "KEBUMEN", "KAB KEBUMEN", "KBM", "33" },
                    { "3306", "MGL", "PURWOREJO", "KAB PURWOREJO", "MGL", "33" },
                    { "3307", "BJG", "WONOSOBO", "KAB WONOSOBO", "BJG", "33" },
                    { "3308", "MGL", "MAGELANG", "KAB MAGELANG", "MGL", "33" },
                    { "3309", "BYL", "BOYOLALI", "KAB BOYOLALI", "SOC", "33" },
                    { "3310", "KLN", "KLATEN", "KAB KLATEN", "KLN", "33" },
                    { "3311", "SKH", "SUKOHARJO", "KAB SUKOHARJO", "SOC", "33" },
                    { "3312", "SKH", "WONOGIRI", "KAB WONOGIRI", "SKH", "33" },
                    { "3313", "SOC", "KARANGANYAR", "KAB KARANGANYAR", "SOC", "33" },
                    { "3314", "SRN", "SRAGEN", "KAB SRAGEN", "SOC", "33" },
                    { "3315", "PWD", "GROBOGAN", "KAB GROBOGAN", "PWD", "33" },
                    { "3316", "BLA", "BLORA", "KAB BLORA", "PWD", "33" },
                    { "3317", "RBG", "REMBANG", "KAB REMBANG", "PTI", "33" },
                    { "3318", "PTI", "PATI", "KAB PATI", "PTI", "33" },
                    { "3319", "KDS", "KUDUS", "KAB KUDUS", "KDS", "33" },
                    { "3320", "KDS", "JEPARA", "KAB JEPARA", "KDS", "33" },
                    { "3321", "DMK", "DEMAK", "KAB DEMAK", "DMK", "33" },
                    { "3322", "SRG", "SEMARANG", "KAB SEMARANG", "SRG", "33" },
                    { "3323", "MGL", "TEMANGGUNG", "KAB TEMANGGUNG", "MGL", "33" },
                    { "3324", "SRG", "KENDAL", "KAB KENDAL", "SRG", "33" },
                    { "3325", "PKL", "BATANG", "KAB BATANG", "PKL", "33" },
                    { "3326", "PKL", "PEKALONGAN", "KAB PEKALONGAN", "PKL", "33" },
                    { "3327", "TGL", "PEMALANG", "KAB PEMALANG", "TGL", "33" },
                    { "3328", "TGL", "TEGAL", "KAB TEGAL", "TGL", "33" },
                    { "3329", "TGL", "BREBES", "KAB BREBES", "TGL", "33" },
                    { "3371", "MGL", "MAGELANG", "KOTA MAGELANG", "MGL", "33" },
                    { "3372", "SOC", "SURAKARTA", "KOTA SURAKARTA", "SOC", "33" },
                    { "3373", "SLT", "SALATIGA", "KOTA SALATIGA", "SLT", "33" },
                    { "3374", "SRG", "SEMARANG", "KOTA SEMARANG", "SRG", "33" },
                    { "3375", "PKL", "PEKALONGAN", "KOTA PEKALONGAN", "PKL", "33" },
                    { "3376", "TGL", "TEGAL", "KOTA TEGAL", "TGL", "33" },
                    { "3401", "YOG", "KULON PROGO", "KAB KULON PROGO", "YOG", "34" },
                    { "3402", "YOG", "BANTUL", "KAB BANTUL", "YOG", "34" },
                    { "3403", "YOG", "GUNUNGKIDUL", "KAB GUNUNGKIDUL", "YOG", "34" },
                    { "3404", "YOG", "SLEMAN", "KAB SLEMAN", "YOG", "34" },
                    { "3471", "YOG", "YOGYAKARTA", "KOTA YOGYAKARTA", "YOG", "34" },
                    { "3501", "PCT", "PACITAN", "KAB PACITAN", "MDN", "35" },
                    { "3502", "MDN", "PONOROGO", "KAB PONOROGO", "MDN", "35" },
                    { "3503", "KDR", "TRENGGALEK", "KAB TRENGGALEK", "KDR", "35" },
                    { "3504", "KDR", "TULUNGAGUNG", "KAB TULUNGAGUNG", "KDR", "35" },
                    { "3505", "KDR", "BLITAR", "KAB BLITAR", "KDR", "35" },
                    { "3506", "KDR", "KEDIRI", "KAB KEDIRI", "KDR", "35" },
                    { "3507", "MLG", "MALANG", "KAB MALANG", "MLG", "35" },
                    { "3508", "JBB", "LUMAJANG", "KAB LUMAJANG", "JBB", "35" },
                    { "3509", "JBB", "JEMBER", "KAB JEMBER", "JBB", "35" },
                    { "3510", "BYW", "BANYUWANGI", "KAB BANYUWANGI", "BYW", "35" },
                    { "3511", "SBD", "BONDOWOSO", "KAB BONDOWOSO", "SBD", "35" },
                    { "3512", "SBD", "SITUBONDO", "KAB SITUBONDO", "SBD", "35" },
                    { "3513", "PBL", "PROBOLINGGO", "KAB PROBOLINGGO", "PBL", "35" },
                    { "3514", "PSN", "PASURUAN", "KAB PASURUAN", "PSN", "35" },
                    { "3515", "SDA", "SIDOARJO", "KAB SIDOARJO", "SDA", "35" },
                    { "3516", "SDA", "MOJOKERTO", "KAB MOJOKERTO", "SDA", "35" },
                    { "3517", "KDR", "JOMBANG", "KAB JOMBANG", "KDR", "35" },
                    { "3518", "KDR", "NGANJUK", "KAB NGANJUK", "KDR", "35" },
                    { "3519", "MDN", "MADIUN", "KAB MADIUN", "MDN", "35" },
                    { "3520", "MGT", "MAGETAN", "KAB MAGETAN", "MDN", "35" },
                    { "3521", "NGW", "NGAWI", "KAB NGAWI", "MDN", "35" },
                    { "3522", "BJN", "BOJONEGORO", "KAB BOJONEGORO", "BJN", "35" },
                    { "3523", "SUB", "TUBAN", "KAB TUBAN", "SUB", "35" },
                    { "3524", "LMG", "LAMONGAN", "KAB LAMONGAN", "LMG", "35" },
                    { "3525", "SUB", "GRESIK", "KAB GRESIK", "SUB", "35" },
                    { "3526", "SUP", "BANGKALAN", "KAB BANGKALAN", "SUB", "35" },
                    { "3527", "SPG", "SAMPANG", "KAB SAMPANG", "SPG", "35" },
                    { "3528", "SUP", "PAMEKASAN", "KAB PAMEKASAN", "SUB", "35" },
                    { "3529", "SUP", "SUMENEP", "KAB SUMENEP", "SUB", "35" },
                    { "3571", "KDR", "KEDIRI", "KOTA KEDIRI", "KDR", "35" },
                    { "3572", "KDR", "BLITAR", "KOTA BLITAR", "KDR", "35" },
                    { "3573", "MLG", "MALANG", "KOTA MALANG", "MLG", "35" },
                    { "3574", "PBL", "PROBOLINGGO", "KOTA PROBOLINGGO", "SUB", "35" },
                    { "3575", "PSN", "PASURUAN", "KOTA PASURUAN", "PSN", "35" },
                    { "3576", "SDA", "MOJOKERTO", "KOTA MOJOKERTO", "SDA", "35" },
                    { "3577", "MDN", "MADIUN", "KOTA MADIUN", "MDN", "35" },
                    { "3578", "SUB", "SURABAYA", "KOTA SURABAYA", "SUB", "35" },
                    { "3579", "MLG", "BATU", "KOTA BATU", "MLG", "35" },
                    { "3591", "BXW", "BAWEAN", "PULAU BAWEAN", "BXW", "35" },
                    { "3601", "CLG", "PANDEGLANG", "KAB PANDEGLANG", "CLG", "36" },
                    { "3602", "CLG", "LEBAK", "KAB LEBAK", "CLG", "36" },
                    { "3603", "TNG", "TANGERANG", "KAB TANGERANG", "TNG", "36" },
                    { "3604", "CLG", "SERANG", "KAB SERANG", "CLG", "36" },
                    { "3671", "TNG", "TANGERANG", "KOTA TANGERANG", "TNG", "36" },
                    { "3672", "CLG", "CILEGON", "KOTA CILEGON", "CLG", "36" },
                    { "3673", "CLG", "SERANG", "KOTA SERANG", "CLG", "36" },
                    { "3674", "TNG", "TANGERANG", "KOTA TANGERANG SELATAN", "TNG", "36" },
                    { "5101", "DPS", "JEMBRANA", "KAB JEMBRANA", "DPS", "51" },
                    { "5102", "DPS", "TABANAN", "KAB TABANAN", "DPS", "51" },
                    { "5103", "DPS", "BADUNG", "KAB BADUNG", "DPS", "51" },
                    { "5104", "GIR", "GIANYAR", "KAB GIANYAR", "GIR", "51" },
                    { "5105", "DPS", "KLUNGKUNG", "KAB KLUNGKUNG", "DPS", "51" },
                    { "5106", "DPS", "BANGLI", "KAB BANGLI", "DPS", "51" },
                    { "5107", "DPS", "KARANGASEM", "KAB KARANGASEM", "DPS", "51" },
                    { "5108", "DPS", "BULELENG", "KAB BULELENG", "DPS", "51" },
                    { "5171", "DPS", "DENPASAR", "KOTA DENPASAR", "DPS", "51" },
                    { "5201", "AMI", "LOMBOK BARAT", "KAB LOMBOK BARAT", "AMI", "52" },
                    { "5202", "PYA", "LOMBOK TENGAH", "KAB LOMBOK TENGAH", "AMI", "52" },
                    { "5203", "PYA", "LOMBOK TIMUR", "KAB LOMBOK TIMUR", "AMI", "52" },
                    { "5204", "LYK", "SUMBAWA", "KAB SUMBAWA", "AMI", "52" },
                    { "5205", "DPU", "DOMPU", "KAB DOMPU", "AMI", "52" },
                    { "5206", "BMU", "BIMA", "KAB BIMA", "AMI", "52" },
                    { "5207", "SWQ", "SUMBAWA BARAT", "KAB SUMBAWA BARAT", "AMI", "52" },
                    { "5208", "PYA", "LOMBOK UTARA", "KAB LOMBOK UTARA", "AMI", "52" },
                    { "5271", "AMI", "MATARAM", "KOTA MATARAM", "AMI", "52" },
                    { "5272", "BMU", "BIMA", "KOTA BIMA", "AMI", "52" },
                    { "5301", "KOE", "KUPANG", "KAB KUPANG", "KOE", "53" },
                    { "5302", "SOE", "TIMOR TENGAH SELATAN", "KAB TIMOR TENGAH SELATAN", "KOE", "53" },
                    { "5303", "KEF", "TIMOR TENGAH UTARA", "KAB TIMOR TENGAH UTARA", "KOE", "53" },
                    { "5304", "ATB", "BELU", "KAB BELU", "KOE", "53" },
                    { "5305", "ARD", "ALOR", "KAB ALOR", "KOE", "53" },
                    { "5306", "LWE", "FLORES TIMUR", "KAB FLORES TIMUR", "KOE", "53" },
                    { "5307", "MME", "SIKKA", "KAB SIKKA", "KOE", "53" },
                    { "5308", "ENE", "ENDE", "KAB ENDE", "KOE", "53" },
                    { "5309", "BXD", "NGADA", "KAB NGADA", "KOE", "53" },
                    { "5310", "BJW", "MANGGARAI", "KAB MANGGARAI", "KOE", "53" },
                    { "5311", "WGP", "SUMBA TIMUR", "KAB SUMBA TIMUR", "KOE", "53" },
                    { "5312", "TMC", "SUMBA BARAT", "KAB SUMBA BARAT", "KOE", "53" },
                    { "5313", "LWA", "LEMBATA", "KAB LEMBATA", "KOE", "53" },
                    { "5314", "RTI", "ROTE NDAO", "KAB ROTE NDAO", "KOE", "53" },
                    { "5315", "LBJ", "MANGGARAI BARAT", "KAB MANGGARAI BARAT", "KOE", "53" },
                    { "5316", "BXD", "NAGEKEO", "KAB NAGEKEO", "KOE", "53" },
                    { "5317", "TMC", "SUMBA TENGAH", "KAB SUMBA TENGAH", "KOE", "53" },
                    { "5318", "TMC", "SUMBA BARAT DAYA", "KAB SUMBA BARAT DAYA", "KOE", "53" },
                    { "5319", "BJW", "MANGGARAI TIMUR", "KAB MANGGARAI TIMUR", "KOE", "53" },
                    { "5320", "SEB", "SABU RAIJUA", "KAB SABU RAIJUA", "KOE", "53" },
                    { "5321", "KEF", "MALAKA", "KAB MALAKA", "KOE", "53" },
                    { "5371", "KOE", "KUPANG", "KOTA KUPANG", "KOE", "53" },
                    { "6101", "SBS", "SAMBAS", "KAB SAMBAS", "PNK", "61" },
                    { "6102", "MPW", "MEMPAWAH", "KAB MEMPAWAH", "PNK", "61" },
                    { "6103", "SGO", "SANGGAU", "KAB SANGGAU", "PNK", "61" },
                    { "6104", "KTG", "KETAPANG", "KAB KETAPANG", "PNK", "61" },
                    { "6105", "SQG", "SINTANG", "KAB SINTANG", "PNK", "61" },
                    { "6106", "PTS", "KAPUAS HULU", "KAB KAPUAS HULU", "PNK", "61" },
                    { "6107", "BKY", "BENGKAYANG", "KAB BENGKAYANG", "PNK", "61" },
                    { "6108", "LDK", "LANDAK", "KAB LANDAK", "PNK", "61" },
                    { "6109", "SKD", "SEKADAU", "KAB SEKADAU", "PNK", "61" },
                    { "6110", "MLW", "MELAWI", "KAB MELAWI", "PNK", "61" },
                    { "6111", "KKU", "KAYONG UTARA", "KAB KAYONG UTARA", "PNK", "61" },
                    { "6112", "KKR", "KUBU RAYA", "KAB KUBU RAYA", "PNK", "61" },
                    { "6171", "PNK", "PONTIANAK", "KOTA PONTIANAK", "PNK", "61" },
                    { "6172", "SKW", "SINGKAWANG", "KOTA SINGKAWANG", "PNK", "61" },
                    { "6201", "PBU", "KOTAWARINGIN BARAT", "KAB KOTAWARINGIN BARAT", "PBU", "62" },
                    { "6202", "SMQ", "KOTAWARINGIN TIMUR", "KAB KOTAWARINGIN TIMUR", "PBU", "62" },
                    { "6203", "KPS", "KAPUAS", "KAB KAPUAS", "BDJ", "62" },
                    { "6204", "BTS", "BARITO SELATAN", "KAB BARITO SELATAN", "PKY", "62" },
                    { "6205", "MTW", "BARITO UTARA", "KAB BARITO UTARA", "PKY", "62" },
                    { "6206", "KTN", "KATINGAN", "KAB KATINGAN", "PKY", "62" },
                    { "6207", "SRY", "SERUYAN", "KAB SERUYAN", "PKY", "62" },
                    { "6208", "SRA", "SUKAMARA", "KAB SUKAMARA", "PBU", "62" },
                    { "6209", "LMD", "LAMANDAU", "KAB LAMANDAU", "PBU", "62" },
                    { "6210", "KRN", "GUNUNG MAS", "KAB GUNUNG MAS", "PKY", "62" },
                    { "6211", "PPS", "PULANG PISAU", "KAB PULANG PISAU", "PKY", "62" },
                    { "6212", "PCH", "MURUNG RAYA", "KAB MURUNG RAYA", "PKY", "62" },
                    { "6213", "TMY", "BARITO TIMUR", "KAB BARITO TIMUR", "PKY", "62" },
                    { "6271", "PKY", "PALANGKARAYA", "KOTA PALANGKARAYA", "PKY", "62" },
                    { "6301", "PLE", "TANAH LAUT", "KAB TANAH LAUT", "BDJ", "63" },
                    { "6302", "KTB", "KOTABARU", "KAB KOTABARU", "BDJ", "63" },
                    { "6303", "BJB", "BANJAR", "KAB BANJAR", "BDJ", "63" },
                    { "6304", "MRB", "BARITO KUALA", "KAB BARITO KUALA", "BDJ", "63" },
                    { "6305", "KDG", "TAPIN", "KAB TAPIN", "BDJ", "63" },
                    { "6306", "KDG", "HULU SUNGAI SELATAN", "KAB HULU SUNGAI SELATAN", "BDJ", "63" },
                    { "6307", "KDG", "HULU SUNGAI TENGAH", "KAB HULU SUNGAI TENGAH", "BDJ", "63" },
                    { "6308", "AMT", "HULU SUNGAI UTARA", "KAB HULU SUNGAI UTARA", "BDJ", "63" },
                    { "6309", "TNJ", "TABALONG", "KAB TABALONG", "BDJ", "63" },
                    { "6310", "BTL", "TANAH BUMBU", "KAB TANAH BUMBU", "BDJ", "63" },
                    { "6311", "TNJ", "BALANGAN", "KAB BALANGAN", "BDJ", "63" },
                    { "6371", "BDJ", "BANJARMASIN", "KOTA BANJARMASIN", "BDJ", "63" },
                    { "6372", "BJB", "BANJARBARU", "KOTA BANJARBARU", "BDJ", "63" },
                    { "6401", "TMB", "PASER", "KAB PASER", "BPN", "64" },
                    { "6402", "KOD", "KUTAI KARTANEGARA", "KAB KUTAI KARTANEGARA", "SRI", "64" },
                    { "6403", "BEJ", "BERAU", "KAB BERAU", "BPN", "64" },
                    { "6407", "DTD", "KUTAI BARAT", "KAB KUTAI BARAT", "SRI", "64" },
                    { "6408", "SGT", "KUTAI TIMUR", "KAB KUTAI TIMUR", "SRI", "64" },
                    { "6409", "PPU", "PENAJAM PASER UTARA", "KAB PENAJAM PASER UTARA", "BPN", "64" },
                    { "6411", "SRI", "MAHAKAM ULU", "KAB MAHAKAM ULU", "SRI", "64" },
                    { "6471", "BPN", "BALIKPAPAN", "KOTA BALIKPAPAN", "BPN", "64" },
                    { "6472", "SRI", "SAMARINDA", "KOTA SAMARINDA", "SRI", "64" },
                    { "6474", "BXT", "BONTANG", "KOTA BONTANG", "SRI", "64" },
                    { "6501", "TRK", "BULUNGAN", "KAB BULUNGAN", "TRK", "65" },
                    { "6502", "TRK", "MALINAU", "KAB MALINAU", "TRK", "65" },
                    { "6503", "TRK", "NUNUKAN", "KAB NUNUKAN", "TRK", "65" },
                    { "6504", "TRK", "TANA TIDUNG", "KAB TANA TIDUNG", "TRK", "65" },
                    { "6571", "TRK", "TARAKAN", "KOTA TARAKAN", "TRK", "65" },
                    { "7101", "KTO", "BOLAANG MONGONDOW", "KAB BOLAANG MONGONDOW", "MDC", "71" },
                    { "7102", "TDO", "MINAHASA", "KAB MINAHASA", "MDC", "71" },
                    { "7103", "THU", "KEPULAUAN SANGIHE", "KAB KEPULAUAN SANGIHE", "MDC", "71" },
                    { "7104", "TLD", "KEPULAUAN TALAUD", "KAB KEPULAUAN TALAUD", "MDC", "71" },
                    { "7105", "AMR", "MINAHASA SELATAN", "KAB MINAHASA SELATAN", "MDC", "71" },
                    { "7106", "ARM", "MINAHASA UTARA", "KAB MINAHASA UTARA", "MDC", "71" },
                    { "7107", "RTH", "MINAHASA TENGGARA", "KAB MINAHASA TENGGARA", "MDC", "71" },
                    { "7108", "BMU", "BOLAANG MONGONDOW UTARA", "KAB BOLAANG MONGONDOW UTARA", "MDC", "71" },
                    { "7109", "STR", "KEP SIAU", "KAB KEP SIAU", "MDC", "71" },
                    { "7110", "BMT", "BOLAANG MONGONDOW TIMUR", "KAB BOLAANG MONGONDOW TIMUR", "MDC", "71" },
                    { "7111", "BMS", "BOLAANG MONGONDOW SELATAN", "KAB BOLAANG MONGONDOW SELATAN", "MDC", "71" },
                    { "7171", "MDC", "MANADO", "KOTA MANADO", "MDC", "71" },
                    { "7172", "BTU", "BITUNG", "KOTA BITUNG", "MDC", "71" },
                    { "7173", "TMH", "TOMOHON", "KOTA TOMOHON", "MDC", "71" },
                    { "7174", "KTO", "KOTAMOBAGU", "KOTA KOTAMOBAGU", "MDC", "71" },
                    { "7201", "BGI", "BANGGAI", "KAB BANGGAI", "PLW", "72" },
                    { "7202", "PSJ", "POSO", "KAB POSO", "PLW", "72" },
                    { "7203", "DGL", "DONGGALA", "KAB DONGGALA", "PLW", "72" },
                    { "7204", "TOL", "TOLI TOLI", "KAB TOLI TOLI", "PLW", "72" },
                    { "7205", "BUO", "BUOL", "KAB BUOL", "PLW", "72" },
                    { "7206", "MOR", "MOROWALI", "KAB MOROWALI", "PLW", "72" },
                    { "7207", "BGK", "BANGGAI KEPULAUAN", "KAB BANGGAI KEPULAUAN", "PLW", "72" },
                    { "7208", "PGM", "PARIGI MOUTONG", "KAB PARIGI MOUTONG", "PLW", "72" },
                    { "7209", "TJU", "TOJO UNA UNA", "KAB TOJO UNA UNA", "PLW", "72" },
                    { "7210", "SIM", "SIGI", "KAB SIGI", "PLW", "72" },
                    { "7211", "BGL", "BANGGAI LAUT", "KAB BANGGAI LAUT", "PLW", "72" },
                    { "7212", "MRU", "MOROWALI UTARA", "KAB MOROWALI UTARA", "PLW", "72" },
                    { "7271", "PLW", "PALU", "KOTA PALU", "PLW", "72" },
                    { "7301", "SLY", "KEPULAUAN SELAYAR", "KAB KEPULAUAN SELAYAR", "UPG", "73" },
                    { "7302", "BUL", "BULUKUMBA", "KAB BULUKUMBA", "UPG", "73" },
                    { "7303", "UPG", "BANTAENG", "KAB BANTAENG", "UPG", "73" },
                    { "7304", "UPG", "JENEPONTO", "KAB JENEPONTO", "UPG", "73" },
                    { "7305", "UPG", "TAKALAR", "KAB TAKALAR", "UPG", "73" },
                    { "7306", "UPG", "GOWA", "KAB GOWA", "UPG", "73" },
                    { "7307", "BUL", "SINJAI", "KAB SINJAI", "UPG", "73" },
                    { "7308", "BNE", "BONE", "KAB BONE", "UPG", "73" },
                    { "7309", "MRS", "MAROS", "KAB MAROS", "UPG", "73" },
                    { "7310", "PKP", "PANGKAJENE", "KAB PANGKAJENE", "UPG", "73" },
                    { "7311", "BRU", "BARRU", "KAB BARRU", "UPG", "73" },
                    { "7312", "SOP", "SOPPENG", "KAB SOPPENG", "UPG", "73" },
                    { "7313", "SKG", "WAJO", "KAB WAJO", "UPG", "73" },
                    { "7314", "SDR", "SIDENRENG RAPPANG", "KAB SIDENRENG RAPPANG", "UPG", "73" },
                    { "7315", "PIN", "PINRANG", "KAB PINRANG", "UPG", "73" },
                    { "7316", "EKG", "ENREKANG", "KAB ENREKANG", "UPG", "73" },
                    { "7317", "LUW", "LUWU", "KAB LUWU", "UPG", "73" },
                    { "7318", "MKL", "TANA TORAJA", "KAB TANA TORAJA", "UPG", "73" },
                    { "7322", "LUT", "LUWU UTARA", "KAB LUWU UTARA", "UPG", "73" },
                    { "7324", "LUM", "LUWU TIMUR", "KAB LUWU TIMUR", "UPG", "73" },
                    { "7326", "RTP", "TORAJA UTARA", "KAB TORAJA UTARA", "UPG", "73" },
                    { "7371", "UPG", "MAKASSAR", "KOTA MAKASSAR", "UPG", "73" },
                    { "7372", "PRE", "PARE PARE", "KOTA PARE PARE", "UPG", "73" },
                    { "7373", "PLP", "PALOPO", "KOTA PALOPO", "UPG", "73" },
                    { "7401", "KKA", "KOLAKA", "KAB KOLAKA", "KDI", "74" },
                    { "7402", "UNH", "KONAWE", "KAB KONAWE", "KDI", "74" },
                    { "7403", "RAH", "MUNA", "KAB MUNA", "KDI", "74" },
                    { "7404", "BUW", "BUTON", "KAB BUTON", "KDI", "74" },
                    { "7405", "UNH", "KONAWE SELATAN", "KAB KONAWE SELATAN", "KDI", "74" },
                    { "7406", "RMB", "BOMBANA", "KAB BOMBANA", "KDI", "74" },
                    { "7407", "WKB", "WAKATOBI", "KAB WAKATOBI", "KDI", "74" },
                    { "7408", "KKA", "KOLAKA UTARA", "KAB KOLAKA UTARA", "KDI", "74" },
                    { "7409", "UNH", "KONAWE UTARA", "KAB KONAWE UTARA", "KDI", "74" },
                    { "7410", "BUW", "BUTON UTARA", "KAB BUTON UTARA", "KDI", "74" },
                    { "7411", "KKA", "KOLAKA TIMUR", "KAB KOLAKA TIMUR", "KDI", "74" },
                    { "7412", "UNH", "KONAWE KEPULAUAN", "KAB KONAWE KEPULAUAN", "KDI", "74" },
                    { "7413", "RAH", "MUNA BARAT", "KAB MUNA BARAT", "KDI", "74" },
                    { "7414", "BUW", "BUTON TENGAH", "KAB BUTON TENGAH", "KDI", "74" },
                    { "7415", "BUW", "BUTON SELATAN", "KAB BUTON SELATAN", "KDI", "74" },
                    { "7471", "KDI", "KENDARI", "KOTA KENDARI", "KDI", "74" },
                    { "7472", "BUW", "BAU BAU", "KOTA BAU BAU", "KDI", "74" },
                    { "7501", "GTL", "GORONTALO", "KAB GORONTALO", "GTO", "75" },
                    { "7502", "BLM", "BOALEMO", "KAB BOALEMO", "GTO", "75" },
                    { "7503", "BLO", "BONE BOLANGO", "KAB BONE BOLANGO", "GTO", "75" },
                    { "7504", "PWH", "PAHUWATO", "KAB PAHUWATO", "GTO", "75" },
                    { "7505", "LBT", "GORONTALO UTARA", "KAB GORONTALO UTARA", "GTO", "75" },
                    { "7571", "GTO", "GORONTALO", "KOTA GORONTALO", "GTO", "75" },
                    { "7601", "MJU", "MAMUJU UTARA", "KAB MAMUJU UTARA", "PLW", "76" },
                    { "7602", "MMJ", "MAMUJU", "KAB MAMUJU", "UPG", "76" },
                    { "7603", "MMS", "MAMASA", "KAB MAMASA", "UPG", "76" },
                    { "7604", "POL", "POLEWALI MANDAR", "KAB POLEWALI MANDAR", "UPG", "76" },
                    { "7605", "MJN", "MAJENE", "KAB MAJENE", "UPG", "76" },
                    { "7606", "MJT", "MAMUJU TENGAH", "KAB MAMUJU TENGAH", "UPG", "76" },
                    { "8101", "AHI", "MALUKU TENGAH", "KAB MALUKU TENGAH", "AMQ", "81" },
                    { "8102", "LUV", "MALUKU TENGGARA", "KAB MALUKU TENGGARA", "AMQ", "81" },
                    { "8103", "SXK", "MALUKU TENGGARA BARAT", "KAB MALUKU TENGGARA BARAT", "AMQ", "81" },
                    { "8104", "NAM", "BURU", "KAB BURU", "AMQ", "81" },
                    { "8105", "BUL", "SERAM BAGIAN TIMUR", "KAB SERAM BAGIAN TIMUR", "AMQ", "81" },
                    { "8106", "WHI", "SERAM BAGIAN BARAT", "KAB SERAM BAGIAN BARAT", "AMQ", "81" },
                    { "8107", "DOB", "KEPULAUAN ARU", "KAB KEPULAUAN ARU", "AMQ", "81" },
                    { "8108", "AMQ", "MALUKU BARAT DAYA", "KAB MALUKU BARAT DAYA", "AMQ", "81" },
                    { "8109", "NRE", "BURU SELATAN", "KAB BURU SELATAN", "AMQ", "81" },
                    { "8171", "AMQ", "AMBON", "KOTA AMBON", "AMQ", "81" },
                    { "8172", "LUV", "TUAL", "KOTA TUAL", "AMQ", "81" },
                    { "8201", "BCN", "HALMAHERA BARAT", "KAB HALMAHERA BARAT", "TTE", "82" },
                    { "8202", "SSP", "HALMAHERA TENGAH", "KAB HALMAHERA TENGAH", "TTE", "82" },
                    { "8203", "TBL", "HALMAHERA UTARA", "KAB HALMAHERA UTARA", "TTE", "82" },
                    { "8204", "WDA", "HALMAHERA SELATAN", "KAB HALMAHERA SELATAN", "TTE", "82" },
                    { "8205", "SLA", "KEPULAUAN SULA", "KAB KEPULAUAN SULA", "TTE", "82" },
                    { "8206", "BLI", "HALMAHERA TIMUR", "KAB HALMAHERA TIMUR", "TTE", "82" },
                    { "8207", "MRT", "PULAU MOROTAI", "KAB PULAU MOROTAI", "TTE", "82" },
                    { "8208", "TLB", "PULAU TALIABU", "KAB PULAU TALIABU", "TTE", "82" },
                    { "8271", "TTE", "TERNATE", "KOTA TERNATE", "TTE", "82" },
                    { "8272", "TDR", "TIDORE KEPULAUAN", "KOTA TIDORE KEPULAUAN", "MDC", "82" },
                    { "9101", "MKQ", "MERAUKE", "KAB MERAUKE", "MKQ", "91" },
                    { "9102", "WMX", "JAYAWIJAYA", "KAB JAYAWIJAYA", "DJJ", "91" },
                    { "9103", "DJJ", "JAYAPURA", "KAB JAYAPURA", "DJJ", "91" },
                    { "9104", "NBX", "NABIRE", "KAB NABIRE", "BIK", "91" },
                    { "9105", "ZRI", "KEPULAUAN YAPEN", "KAB KEPULAUAN YAPEN", "BIK", "91" },
                    { "9106", "BIK", "BIAK NUMFOR", "KAB BIAK NUMFOR", "BIK", "91" },
                    { "9107", "ELR", "PUNCAK JAYA", "KAB PUNCAK JAYA", "DJJ", "91" },
                    { "9108", "ILA", "PANIAI", "KAB PANIAI", "BIK", "91" },
                    { "9109", "TIM", "MIMIKA", "KAB MIMIKA", "TIM", "91" },
                    { "9110", "ZRM", "SARMI", "KAB SARMI", "DJJ", "91" },
                    { "9111", "WAR", "KEEROM", "KAB KEEROM", "DJJ", "91" },
                    { "9112", "OKL", "PEGUNUNGAN BINTANG", "KAB PEGUNUNGAN BINTANG", "DJJ", "91" },
                    { "9113", "DEK", "YAHUKIMO", "KAB YAHUKIMO", "DJJ", "91" },
                    { "9114", "KBF", "TOLIKARA", "KAB TOLIKARA", "DJJ", "91" },
                    { "9115", "BTW", "WAROPEN", "KAB WAROPEN", "BIK", "91" },
                    { "9116", "MDP", "BOVEN DIGOEL", "KAB BOVEN DIGOEL", "MKQ", "91" },
                    { "9117", "KEI", "MAPPI", "KAB MAPPI", "MKQ", "91" },
                    { "9118", "AGT", "ASMAT", "KAB ASMAT", "MKQ", "91" },
                    { "9119", "SRW", "SUPIORI", "KAB SUPIORI", "BIK", "91" },
                    { "9120", "OKL", "MAMBERAMO RAYA", "KAB MAMBERAMO RAYA", "DJJ", "91" },
                    { "9121", "OKL", "MAMBERAMO TENGAH", "KAB MAMBERAMO TENGAH", "DJJ", "91" },
                    { "9122", "ELM", "YALIMO", "KAB YALIMO", "DJJ", "91" },
                    { "9123", "TOM", "LANNY JAYA", "KAB LANNY JAYA", "DJJ", "91" },
                    { "9124", "KYM", "NDUGA", "KAB NDUGA", "DJJ", "91" },
                    { "9125", "ILA", "PUNCAK", "KAB PUNCAK", "DJJ", "91" },
                    { "9126", "NBX", "DOGIYAI", "KAB DOGIYAI", "DJJ", "91" },
                    { "9127", "ZGP", "INTAN JAYA", "KAB INTAN JAYA", "DJJ", "91" },
                    { "9128", "TIG", "DEIYAI", "KAB DEIYAI", "BIK", "91" },
                    { "9171", "DJJ", "JAYAPURA", "KOTA JAYAPURA", "DJJ", "91" },
                    { "9201", "SOQ", "SORONG", "KAB SORONG", "SOQ", "92" },
                    { "9202", "MKW", "MANOKWARI", "KAB MANOKWARI", "MKW", "92" },
                    { "9203", "FFK", "FAK FAK", "KAB FAK FAK", "SOQ", "92" },
                    { "9204", "SOQ", "SORONG SELATAN", "KAB SORONG SELATAN", "SOQ", "92" },
                    { "9205", "GAV", "RAJA AMPAT", "KAB RAJA AMPAT", "SOQ", "92" },
                    { "9206", "NTI", "TELUK BINTUNI", "KAB TELUK BINTUNI", "SOQ", "92" },
                    { "9207", "RAS", "TELUK WONDAMA", "KAB TELUK WONDAMA", "MKW", "92" },
                    { "9208", "KNG", "KAIMANA", "KAB KAIMANA", "SOQ", "92" },
                    { "9209", "FEF", "TAMBRAUW", "KAB TAMBRAUW", "SOQ", "92" },
                    { "9210", "AFT", "MAYBRAT", "KAB MAYBRAT", "SOQ", "92" },
                    { "9211", "MKW", "MANOKWARI SELATAN", "KAB MANOKWARI SELATAN", "MKW", "92" },
                    { "9212", "MKW", "PEGUNUNGAN ARFAK", "KAB PEGUNUNGAN ARFAK", "DJJ", "92" },
                    { "9271", "SOQ", "SORONG", "KOTA SORONG", "SOQ", "92" }
                });

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[,]
                {
                    { "1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-fingerprint", "Identity", 1, null, null, "101", "", null, null },
                    { "1.1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-user", "User Data", 1, null, null, "101", "1.1", "/admin/user", null },
                    { "1.1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-user-shield", "Role Data", 1, null, null, "101", "1.1", "/admin/role", null },
                    { "1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-wrench", "Configuration", 2, null, null, "101", "", null, null },
                    { "1.2.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-shoe-prints", "Audittrail", 1, null, null, "101", "1.2", "/admin/audittrail", null },
                    { "1.2.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-bell", "Preparing Sign-out", 1, null, null, "101", "1.2", "/admin/preparingsignout", null },
                    { "2.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-building", "Branch & Agent", 1, null, null, "102", "", null, null },
                    { "2.1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-building-flag", "NCS Branch Office", 1, null, null, "102", "2.1", "/master/branch", null },
                    { "2.1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-shop", "NCS Counter", 2, null, null, "102", "2.1", "/master/counter", null },
                    { "2.1.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-store", "NCS Agent", 3, null, null, "102", "2.1", "/master/agent", null },
                    { "2.1.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid  fa-house-laptop", "NCS Agent Otonom", 4, null, null, "102", "2.1", "/master/agentotonom", null },
                    { "2.1.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-person-booth", "Wholesaler", 5, null, null, "102", "2.1", "/master/wholesaler", null },
                    { "2.1.6", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-envelopes-bulk", "Branch Corporate", 6, null, null, "102", "2.1", "/master/branchcorporate", null },
                    { "2.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-warehouse", "Operational", 2, null, null, "102", "", null, null },
                    { "2.2.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-people-line", "Courier Group", 1, null, null, "102", "2.2", "/master/couriergroup", null },
                    { "2.2.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-motorcycle", "Courier Code", 2, null, null, "102", "2.2", "/master/courier", null },
                    { "2.2.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-road", "Courier Route", 3, null, null, "102", "2.2", "/master/courierroute", null },
                    { "2.2.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-location-dot", "Checkpoint Code", 4, null, null, "102", "2.2", "/master/checkpointcode", null },
                    { "2.2.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-building-circle-arrow-right", "HUB Code", 5, null, null, "102", "2.2", "/master/hubcode", null },
                    { "2.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-user", "Client", 3, null, null, "102", "", null, null },
                    { "2.3.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-users-between-lines", "CIF Data Client", 1, null, null, "102", "2.3", "/master/cif", null },
                    { "2.3.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-user-tag", "Account Data Client", 2, null, null, "102", "2.3", "/master/account", null },
                    { "2.3.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-industry", "Industry Code", 3, null, null, "102", "2.3", "/master/industry", null },
                    { "2.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-handshake", "Sales", 4, null, null, "102", "", null, null },
                    { "2.4.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-person-arrow-up-from-line", "CRO", 1, null, null, "102", "2.4", "/master/cro", null }
                });

            migrationBuilder.InsertData(
                table: "mdt_district",
                columns: new[] { "distid", "cityid", "distname" },
                values: new object[] { "317307", "3173", "Pal Merah" });

            migrationBuilder.InsertData(
                table: "mdt_village",
                columns: new[] { "villid", "distid", "villname" },
                values: new object[] { "3173071006", "317307", "Kota Bambu Selatan" });

            migrationBuilder.InsertData(
                table: "mdt_branch",
                columns: new[] { "branchid", "addr1", "addr2", "addr3", "branchcode", "branchname", "branchtype", "citycode", "cityname", "createdby", "createddate", "distname", "email", "flag", "honame", "latitude", "longitude", "modifieddate", "modifier", "phone", "phonealt", "picname", "picno", "postcode", "provname", "villid" },
                values: new object[,]
                {
                    { 1, "Jl Brigjen Katamso No.7, Kota Bambu Selatan, Palmerah, Jakarta Barat", null, null, "C1", "Katamso Head Office", "Central", null, null, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, null, "-6.189083", "106.800992", null, null, null, null, null, null, null, null, "3173071006" },
                    { 2, "Jl.Kemanggisan Raya No.19, Kota Bambu Selatan, Palmerah, Jakarta Barat", null, null, "C2", "Kemanggisan Head Office", "Central", null, null, "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, null, "-6.189993", "106.792306", null, null, null, null, null, null, null, null, "3173071006" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_app_menu_moduleid",
                table: "app_menu",
                column: "moduleid");

            migrationBuilder.CreateIndex(
                name: "IX_app_module_modulectgid",
                table: "app_module",
                column: "modulectgid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_account_branchid",
                table: "mdt_account",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_account_cif",
                table: "mdt_account",
                column: "cif");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_accountaddr_acctno",
                table: "mdt_accountaddr",
                column: "acctno");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_accountaddr_distid",
                table: "mdt_accountaddr",
                column: "distid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_accountcro_crocode",
                table: "mdt_accountcro",
                column: "crocode");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_agent_branchid",
                table: "mdt_agent",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_agent_villid",
                table: "mdt_agent",
                column: "villid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_branch_villid",
                table: "mdt_branch",
                column: "villid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_branchaccount_acctno",
                table: "mdt_branchaccount",
                column: "acctno");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_branchaccount_branchid",
                table: "mdt_branchaccount",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_cif_branchid",
                table: "mdt_cif",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_cif_industryid",
                table: "mdt_cif",
                column: "industryid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_city_provid",
                table: "mdt_city",
                column: "provid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_counter_branchid",
                table: "mdt_counter",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_counter_villid",
                table: "mdt_counter",
                column: "villid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_courier_branchid",
                table: "mdt_courier",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_courier_distid",
                table: "mdt_courier",
                column: "distid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_cro_branchid",
                table: "mdt_cro",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_district_cityid",
                table: "mdt_district",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_village_distid",
                table: "mdt_village",
                column: "distid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_menu");

            migrationBuilder.DropTable(
                name: "mdt_accountaddr");

            migrationBuilder.DropTable(
                name: "mdt_accountcro");

            migrationBuilder.DropTable(
                name: "mdt_agent");

            migrationBuilder.DropTable(
                name: "mdt_branchaccount");

            migrationBuilder.DropTable(
                name: "mdt_checkpoint");

            migrationBuilder.DropTable(
                name: "mdt_counter");

            migrationBuilder.DropTable(
                name: "mdt_courier");

            migrationBuilder.DropTable(
                name: "app_module");

            migrationBuilder.DropTable(
                name: "mdt_cro");

            migrationBuilder.DropTable(
                name: "mdt_account");

            migrationBuilder.DropTable(
                name: "app_modulectg");

            migrationBuilder.DropTable(
                name: "mdt_cif");

            migrationBuilder.DropTable(
                name: "mdt_branch");

            migrationBuilder.DropTable(
                name: "mdt_industry");

            migrationBuilder.DropTable(
                name: "mdt_village");

            migrationBuilder.DropTable(
                name: "mdt_district");

            migrationBuilder.DropTable(
                name: "mdt_city");

            migrationBuilder.DropTable(
                name: "mdt_province");
        }
    }
}
