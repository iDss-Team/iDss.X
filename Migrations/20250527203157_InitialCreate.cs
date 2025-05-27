using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "mdt_costcomponent",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    componentname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    type = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_costcomponent", x => x.id);
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
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_province", x => x.provid);
                });

            migrationBuilder.CreateTable(
                name: "mdt_reasonun",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reasonname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    reasoncode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_reasonun", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mdt_relation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    relationname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    relationcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_relation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trx_attachment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    cpcode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    url1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    url2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    url3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    url4 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    url5 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    urlsignature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isadjust = table.Column<int>(type: "int", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_attachment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trx_costitem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    componetname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    debit = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    credit = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_costitem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trx_unititem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    itemcode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    itemname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    actweight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    length = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    width = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    height = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    volweight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_unititem", x => x.id);
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
                    provid = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    menuname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    cityid = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                name: "trx_cneedirectory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    attname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    addr3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    statecode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    cnelat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cnelong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    descode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    costcenter = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_cneedirectory", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_cneedirectory_mdt_district_distid",
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
                    couriercode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    couriername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.UniqueConstraint("AK_mdt_courier_couriercode", x => x.couriercode);
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
                    creditlimit = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    creditperiod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    iscod = table.Column<int>(type: "int", nullable: true),
                    feecod = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
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
                name: "trx_checkpointpool",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    cpcode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    cpname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cpdatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    branchname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    couriercode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    recipient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    relationid = table.Column<int>(type: "int", nullable: true),
                    reasonid = table.Column<int>(type: "int", nullable: true),
                    attempt = table.Column<int>(type: "int", nullable: false),
                    islastpoint = table.Column<int>(type: "int", nullable: false),
                    isoversla = table.Column<int>(type: "int", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_checkpointpool", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_checkpointpool_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_checkpointpool_mdt_courier_couriercode",
                        column: x => x.couriercode,
                        principalTable: "mdt_courier",
                        principalColumn: "couriercode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_checkpointpool_mdt_reasonun_reasonid",
                        column: x => x.reasonid,
                        principalTable: "mdt_reasonun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_checkpointpool_mdt_relation_relationid",
                        column: x => x.relationid,
                        principalTable: "mdt_relation",
                        principalColumn: "id",
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

            migrationBuilder.CreateTable(
                name: "pum_pickupregular",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    picphone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    picemail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    branchid = table.Column<int>(type: "int", nullable: true),
                    couriercode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    couriername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    transporttype = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_pickupregular", x => x.id);
                    table.ForeignKey(
                        name: "FK_pum_pickupregular_mdt_account_acctno",
                        column: x => x.acctno,
                        principalTable: "mdt_account",
                        principalColumn: "acctno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pum_pickupregular_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pum_pickupregular_mdt_courier_couriercode",
                        column: x => x.couriercode,
                        principalTable: "mdt_courier",
                        principalColumn: "couriercode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pum_pickupregular_mdt_district_distid",
                        column: x => x.distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
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
                name: "pum_pickupschedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    puregid = table.Column<int>(type: "int", nullable: false),
                    pickupday = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    shift = table.Column<int>(type: "int", nullable: false),
                    timefrom = table.Column<TimeOnly>(type: "time", nullable: false),
                    timeto = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_pickupschedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_pum_pickupschedule_pum_pickupregular_puregid",
                        column: x => x.puregid,
                        principalTable: "pum_pickupregular",
                        principalColumn: "id",
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

            migrationBuilder.CreateTable(
                name: "trx_shipmentdetail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
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
                    table.UniqueConstraint("AK_trx_shipmentdetail_awb", x => x.awb);
                    table.ForeignKey(
                        name: "FK_trx_shipmentdetail_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trx_consignee",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    branchcne = table.Column<int>(type: "int", nullable: true),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    acctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    cnename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    attname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    addr3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    statecode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    cnelat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cnelong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    descode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    costcenter = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_consignee", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_consignee_mdt_account_acctno",
                        column: x => x.acctno,
                        principalTable: "mdt_account",
                        principalColumn: "acctno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_consignee_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_consignee_mdt_district_distid",
                        column: x => x.distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_consignee_trx_shipmentdetail_awb",
                        column: x => x.awb,
                        principalTable: "trx_shipmentdetail",
                        principalColumn: "awb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trx_payment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    paymenttype = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    paymentgateway = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    paymentstatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_payment_trx_shipmentdetail_awb",
                        column: x => x.awb,
                        principalTable: "trx_shipmentdetail",
                        principalColumn: "awb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trx_shipper",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    branchori = table.Column<int>(type: "int", nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    acctno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    shippername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    attname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    addr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    addr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    addr3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    statecode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    distid = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    provname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    shplat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    shplong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    oricode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    costcenter = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_shipper", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_shipper_mdt_account_acctno",
                        column: x => x.acctno,
                        principalTable: "mdt_account",
                        principalColumn: "acctno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_shipper_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_shipper_mdt_district_distid",
                        column: x => x.distid,
                        principalTable: "mdt_district",
                        principalColumn: "distid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_shipper_trx_shipmentdetail_awb",
                        column: x => x.awb,
                        principalTable: "trx_shipmentdetail",
                        principalColumn: "awb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trx_void",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    awb = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    branchori = table.Column<int>(type: "int", nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    reqisuestpoint = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    reasonvoid = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    approval = table.Column<int>(type: "int", nullable: false),
                    approver = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_void", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_void_mdt_branch_branchid",
                        column: x => x.branchid,
                        principalTable: "mdt_branch",
                        principalColumn: "branchid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trx_void_trx_shipmentdetail_awb",
                        column: x => x.awb,
                        principalTable: "trx_shipmentdetail",
                        principalColumn: "awb",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "provid", "createdby", "createddate", "flag", "modifieddate", "modifier", "provname" },
                values: new object[,]
                {
                    { "11", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "ACEH" },
                    { "12", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "SUMATERA UTARA" },
                    { "13", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "SUMATERA BARAT" },
                    { "14", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "RIAU" },
                    { "15", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "JAMBI" },
                    { "16", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "SUMATERA SELATAN" },
                    { "17", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "BENGKULU" },
                    { "18", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "LAMPUNG" },
                    { "19", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "BANGKA BELITUNG" },
                    { "21", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "KEPULAUAN RIAU" },
                    { "31", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "DKI JAKARTA" },
                    { "32", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "JAWA BARAT" },
                    { "33", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "JAWA TENGAH" },
                    { "34", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "YOGYAKARTA" },
                    { "35", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "JAWA TIMUR" },
                    { "36", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "BANTEN" },
                    { "51", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "BALI" },
                    { "52", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "NUSA TENGGARA BARAT" },
                    { "53", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "NUSA TENGGARA TIMUR" },
                    { "61", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "KALIMANTAN BARAT" },
                    { "62", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "KALIMANTAN TENGAH" },
                    { "63", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "KALIMANTAN SELATAN" },
                    { "64", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "KALIMANTAN TIMUR" },
                    { "65", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "KALIMANTAN UTARA" },
                    { "71", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "SULAWESI UTARA" },
                    { "72", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "SULAWESI TENGAH" },
                    { "73", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "SULAWESI SELATAN" },
                    { "74", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "SULAWESI TENGGARA" },
                    { "75", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "GORONTALO" },
                    { "76", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "SULAWESI BARAT" },
                    { "81", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "MALUKU" },
                    { "82", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "MALUKU UTARA" },
                    { "91", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "PAPUA" },
                    { "92", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "PAPUA BARAT" }
                });

            migrationBuilder.InsertData(
                table: "app_module",
                columns: new[] { "moduleid", "createdby", "createddate", "description", "flag", "icon", "modifieddate", "modifier", "modulectgid", "modulename", "modulesort" },
                values: new object[,]
                {
                    { "101", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages system settings, permissions and general platform configurations", 1, "fa-solid fa-user-tie", null, null, 1, "Administrasion", 1 },
                    { "102", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stores and manages core data", 1, "fa-solid fa-database", null, null, 2, "Master Data", 2 },
                    { "103", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handles potential customer prospects, including registration, analysis, and follow-ups to be regular customers", 1, "fa-solid fa-handshake-simple", null, null, 3, "Prospect Customer Relationship", 3 },
                    { "104", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages relationships with potential agents, registration, evaluation, and communication to expand the operational network.", 1, "fa-solid fa-people-group", null, null, 3, "Prospect Agent Relationship", 4 },
                    { "105", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Records and manages the sales process, pricing and monitoring team performance and targets.", 1, "fa-solid fa-magnifying-glass-chart", null, null, 3, "Sales Management", 5 },
                    { "106", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schedules and manages pickup from customers, including route optimization and field team coordination.", 1, "fa-solid fa-truck-moving", null, null, 3, "Pickup Management", 6 },
                    { "107", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Controls and manages the outbound shipment of goods from origin distribution centers to final destinations.", 1, "fa-solid fa-plane-departure", null, null, 4, "Outbound Control Library", 7 },
                    { "108", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitors and manages the movement of goods during intercity or inter-hub transportation.", 1, "fa-solid fa-truck-plane", null, null, 4, "Linehaul Control Library", 8 },
                    { "109", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handles the receiving of incoming shipments from distribution centers until delivery to recipient.", 1, "fa-solid fa-plane-arrival", null, null, 4, "Inbound Control Library", 9 },
                    { "110", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages the return process due to incorrect shipments, damaged goods, or other return policies.", 1, "fa-solid fa-reply", null, null, 4, "Return Management", 10 },
                    { "111", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inbound Processing Center", 0, "fa-solid fa-file-invoice", null, null, 4, "Billing Delivery System", 11 },
                    { "112", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inbound Processing Center", 0, "fa-solid fa-credit-card", null, null, 4, "Credit Card System", 12 },
                    { "113", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handles cash payments upon delivery, including transaction recording and coordination with couriers.", 1, "fa-solid fa-money-bill-wave", null, null, 5, "COD Collection", 13 },
                    { "114", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides real-time tracking for customers and internal teams to monitor shipment status and locations.", 1, "fa-solid fa-shoe-prints", null, null, 4, "Shipment Tracking Visibility", 14 },
                    { "115", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addresses operational issues such as delivery delays, lost shipments, or customer complaints, and records provided solutions.", 1, "fa-solid fa-glasses", null, null, 4, "Problem Handling & Solution", 15 },
                    { "116", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generates reports and data analysis related to operational performance, sales, and financial aspects to support strategic decision-making.", 1, "fa-solid fa-chart-line", null, null, 5, "Analytics & Reporting", 16 },
                    { "117", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages company financials, including transaction records, operational expenses, payment reconciliation, and invoicing.", 1, "fa-solid fa-sack-dollar", null, null, 5, "Finance Management", 17 },
                    { "118", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides customer support to answer inquiries, handle complaints, and offer shipment and service-related information.", 1, "fa-solid fa-headset", null, null, 5, "Customer Care Services", 18 },
                    { "119", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensures compliance with industry regulations and legal requirements, including document management and audit processes.", 1, "fa-solid fa-scale-balanced", null, null, 6, "Legal & Compliance", 19 },
                    { "120", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manages connections with external systems, APIs, and third-party services to ensure seamless data exchange and interoperability.", 1, "fa-solid fa-code-compare", null, null, 1, "Integration Management", 20 },
                    { "121", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensures consistency across multiple systems by managing automated data imports, exports, and synchronization processes.", 1, "fa-solid fa-rotate", null, null, 2, "Data Synchronization", 21 },
                    { "122", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maintains data accuracy and reliability by implementing validation rules, detecting duplicates, and managing data correction processes.", 1, "fa-solid fa-list-check", null, null, 2, "Data Quality & Validation", 22 }
                });

            migrationBuilder.InsertData(
                table: "mdt_city",
                columns: new[] { "cityid", "citycode", "citymerger", "cityname", "createdby", "createddate", "flag", "hubcode", "modifieddate", "modifier", "provid" },
                values: new object[,]
                {
                    { "1101", "TTN", "ACEH SELATAN", "KAB ACEH SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1102", "KTN", "ACEH TENGGARA", "KAB ACEH TENGGARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1103", "LGS", "ACEH TIMUR", "KAB ACEH TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "11" },
                    { "1104", "TKN", "ACEH TENGAH", "KAB ACEH TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1105", "MBO", "ACEH BARAT", "KAB ACEH BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1106", "JTH", "ACEH BESAR", "KAB ACEH BESAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1107", "SGI", "PIDIE", "KAB PIDIE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1108", "LSK", "ACEH UTARA", "KAB ACEH UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "11" },
                    { "1109", "SNB", "SIMEULUE", "KAB SIMEULUE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1110", "SKL", "ACEH SINGKIL", "KAB ACEH SINGKIL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1111", "BIR", "BIREUEN", "KAB BIREUEN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "11" },
                    { "1112", "BPD", "ACEH BARAT DAYA", "KAB ACEH BARAT DAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1113", "BKJ", "GAYO LUES", "KAB GAYO LUES", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1114", "CAG", "ACEH JAYA", "KAB ACEH JAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1115", "SKM", "NAGAN RAYA", "KAB NAGAN RAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1116", "KRB", "ACEH TAMIANG", "KAB ACEH TAMIANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "11" },
                    { "1117", "STR", "BENER MERIAH", "KAB BENER MERIAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1118", "MRN", "PIDIE JAYA", "KAB PIDIE JAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1171", "BTJ", "BANDA ACEH", "KOTA BANDA ACEH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1172", "SBG", "SABANG", "KOTA SABANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1173", "LSW", "LHOKSEUMAWE", "KOTA LHOKSEUMAWE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "11" },
                    { "1174", "LGS", "LANGSA", "KOTA LANGSA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "11" },
                    { "1175", "SUS", "SUBULUSSALAM", "KOTA SUBULUSSALAM", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTJ", null, null, "11" },
                    { "1201", "SBG", "TAPANULI", "KAB TAPANULI TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1202", "TRT", "TAPANULI", "KAB TAPANULI UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1203", "PSP", "TAPANULI", "KAB TAPANULI SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1204", "GST", "NIAS", "KAB NIAS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1205", "STB", "LANGKAT", "KAB LANGKAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1206", "KBJ", "KARO", "KAB KARO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1207", "LBP", "DELI SERDANG", "KAB DELI SERDANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1208", "SIM", "SIMALUNGUN", "KAB SIMALUNGUN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1209", "KIS", "ASAHAN", "KAB ASAHAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1210", "RTP", "LABUHANBATU", "KAB LABUHANBATU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1211", "SKD", "DAIRI", "KAB DAIRI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1212", "BLG", "TOBA SAMOSIR", "KAB TOBA SAMOSIR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1213", "PYB", "MANDAILING NATAL", "KAB MANDAILING NATAL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1214", "TLD", "NIAS", "KAB NIAS SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1215", "SAL", "PAKPAK BHARAT", "KAB PAKPAK BHARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1216", "DLS", "HUMBANG HASUNDUTAN", "KAB HUMBANG HASUNDUTAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1217", "PRR", "SAMOSIR", "KAB SAMOSIR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1218", "SRH", "SERDANG BEDAGAI", "KAB SERDANG BEDAGAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1219", "LPM", "BATU BARA", "KAB BATU BARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1220", "GNT", "PADANG LAWAS", "KAB PADANG LAWAS UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1221", "SBH", "PADANG LAWAS", "KAB PADANG LAWAS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1222", "KPI", "LABUHANBATU", "KAB LABUHANBATU SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1223", "AKK", "LABUHANBATU", "KAB LABUHANBATU UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1224", "LTU", "NIAS", "KAB NIAS UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1225", "LHM", "NIAS", "KAB NIAS BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1271", "MES", "MEDAN", "KOTA MEDAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1272", "PMS", "PEMATANG SIANTAR", "KOTA PEMATANG SIANTAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1273", "SBG", "SIBOLGA", "KOTA SIBOLGA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1274", "TJB", "TANJUNG BALAI", "KOTA TANJUNG BALAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1275", "BNJ", "BINJAI", "KOTA BINJAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1276", "TBT", "TEBING TINGGI", "KOTA TEBING TINGGI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1277", "PSP", "PADANGSIDIMPUAN", "KOTA PADANGSIDIMPUAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1278", "GNS", "GUNUNGSITOLI", "KOTA GUNUNGSITOLI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MES", null, null, "12" },
                    { "1301", "PSR", "PESISIR SELATAN", "KAB PESISIR SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1302", "SOL", "SOLOK", "KAB SOLOK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1303", "SJJ", "SIJUNJUNG", "KAB SIJUNJUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1304", "TDR", "TANAH DATAR", "KAB TANAH DATAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1305", "PPR", "PADANG PARIAMAN", "KAB PADANG PARIAMAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1306", "AGM", "AGAM", "KAB AGAM", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1307", "LPH", "LIMA PULUH KOTA", "KAB LIMA PULUH KOTA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1308", "PSM", "PASAMAN", "KAB PASAMAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1309", "MTW", "KEPULAUAN MENTAWAI", "KAB KEPULAUAN MENTAWAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1310", "DMR", "DHARMASRAYA", "KAB DHARMASRAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1311", "SSL", "SOLOK", "KAB SOLOK SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1312", "PSB", "PASAMAN", "KAB PASAMAN BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1371", "PDG", "PADANG", "KOTA PADANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1372", "SLK", "SOLOK", "KOTA SOLOK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1373", "SWL", "SAWAHLUNTO", "KOTA SAWAHLUNTO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1374", "PPJ", "PADANG PANJANG", "KOTA PADANG PANJANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1375", "BKT", "BUKITTINGGI", "KOTA BUKITTINGGI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1376", "PKY", "PAYAKUMBUH", "KOTA PAYAKUMBUH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1377", "PRM", "PARIAMAN", "KOTA PARIAMAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PDG", null, null, "13" },
                    { "1401", "BKN", "KAMPAR", "KAB KAMPAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1402", "RGT", "INDRAGIRI HULU", "KAB INDRAGIRI HULU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1403", "BLS", "BENGKALIS", "KAB BENGKALIS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1404", "TBH", "INDRAGIRI HILIR", "KAB INDRAGIRI HILIR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1405", "PKK", "PELALAWAN", "KAB PELALAWAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1406", "PRP", "ROKAN HULU", "KAB ROKAN HULU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1407", "UJT", "ROKAN HILIR", "KAB ROKAN HILIR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1408", "SAK", "SIAK", "KAB SIAK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1409", "TLK", "KUANTAN SINGINGI", "KAB KUANTAN SINGINGI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1410", "TTG", "KEPULAUAN MERANTI", "KAB KEPULAUAN MERANTI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1471", "PKU", "PEKANBARU", "KOTA PEKANBARU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1472", "DUM", "DUMAI", "KOTA DUMAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKU", null, null, "14" },
                    { "1501", "KRC", "KERINCI", "KAB KERINCI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1502", "MRG", "MERANGIN", "KAB MERANGIN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1503", "SAR", "SAROLANGUN", "KAB SAROLANGUN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1504", "MBO", "BATANGHARI", "KAB BATANGHARI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1505", "MJA", "MUARO JAMBI", "KAB MUARO JAMBI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1506", "KTU", "TANJUNG JABUNG", "KAB TANJUNG JABUNG BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1507", "MSA", "TANJUNG JABUNG", "KAB TANJUNG JABUNG TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1508", "MRB", "BUNGO", "KAB BUNGO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MRB", null, null, "15" },
                    { "1509", "MTE", "TEBO", "KAB TEBO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1571", "DJB", "JAMBI", "KOTA JAMBI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1572", "SPE", "SUNGAI PENUH", "KOTA SUNGAI PENUH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJB", null, null, "15" },
                    { "1601", "BTA", "OGAN KOMERING ULU", "KAB OGAN KOMERING ULU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1602", "OKI", "OGAN KOMERING ILIR", "KAB OGAN KOMERING ILIR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1603", "MRE", "MUARA ENIM", "KAB MUARA ENIM", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1604", "LHT", "LAHAT", "KAB LAHAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1605", "MRA", "MUSI RAWAS", "KAB MUSI RAWAS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1606", "MBA", "MUSI BANYUASIN", "KAB MUSI BANYUASIN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1607", "BYA", "BANYUASIN", "KAB BANYUASIN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1608", "OKU", "OGAN KOMERING ULU TIMUR", "KAB OGAN KOMERING ULU TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1609", "OKU", "OGAN KOMERING ULU SELATAN", "KAB OGAN KOMERING ULU SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1610", "OGI", "OGAN ILIR", "KAB OGAN ILIR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1611", "PDO", "EMPAT LAWANG", "KAB EMPAT LAWANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1612", "PNA", "PENUKAL ABAB", "KAB PENUKAL ABAB", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1613", "MRU", "MUSI RAWAS UTARA", "KAB MUSI RAWAS UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1671", "PLM", "PALEMBANG", "KOTA PALEMBANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1672", "PGA", "PAGAR ALAM", "KOTA PAGAR ALAM", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1673", "LLG", "LUBUK LINGGAU", "KOTA LUBUK LINGGAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1674", "PRB", "PRABUMULIH", "KOTA PRABUMULIH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLM", null, null, "16" },
                    { "1701", "MNN", "BENGKULU SELATAN", "KAB BENGKULU SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1702", "CRP", "REJANG LEBONG", "KAB REJANG LEBONG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1703", "ARM", "BENGKULU UTARA", "KAB BENGKULU UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1704", "BTN", "KAUR", "KAB KAUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1705", "SLM", "SELUMA", "KAB SELUMA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1706", "MPC", "MUKO MUKO", "KAB MUKO MUKO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1707", "LBG", "LEBONG", "KAB LEBONG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1708", "KPH", "KEPAHIANG", "KAB KEPAHIANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1709", "KRT", "BENGKULU TENGAH", "KAB BENGKULU TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1771", "BKS", "BENGKULU", "KOTA BENGKULU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKS", null, null, "17" },
                    { "1801", "LPS", "LAMPUNG SELATAN", "KAB LAMPUNG SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1802", "LPT", "LAMPUNG TENGAH", "KAB LAMPUNG TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1803", "LPU", "LAMPUNG UTARA", "KAB LAMPUNG UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1804", "LPB", "LAMPUNG BARAT", "KAB LAMPUNG BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1805", "TBA", "TULANG BAWANG", "KAB TULANG BAWANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1806", "TGS", "TANGGAMUS", "KAB TANGGAMUS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1807", "LTM", "LAMPUNG TIMUR", "KAB LAMPUNG TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1808", "WKN", "WAY KANAN", "KAB WAY KANAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1809", "PSR", "PESAWARAN", "KAB PESAWARAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1810", "PSW", "PRINGSEWU", "KAB PRINGSEWU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1811", "TBM", "MESUJI", "KAB MESUJI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1812", "TBB", "TULANG BAWANG", "KAB TULANG BAWANG BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1813", "LPB", "PESISIR BARAT", "KAB PESISIR BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1871", "TKG", "BANDAR LAMPUNG", "KOTA BANDAR LAMPUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1872", "TKG", "METRO", "KOTA METRO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TKG", null, null, "18" },
                    { "1901", "SGL", "BANGKA", "KAB BANGKA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PGK", null, null, "19" },
                    { "1902", "TJQ", "BELITUNG", "KAB BELITUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TJQ", null, null, "19" },
                    { "1903", "TBL", "BANGKA SELATAN", "KAB BANGKA SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PGK", null, null, "19" },
                    { "1904", "KBA", "BANGKA TENGAH", "KAB BANGKA TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PGK", null, null, "19" },
                    { "1905", "MTK", "BANGKA BARAT", "KAB BANGKA BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PGK", null, null, "19" },
                    { "1906", "MGR", "BELITUNG TIMUR", "KAB BELITUNG TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TJQ", null, null, "19" },
                    { "1971", "PGK", "PANGKAL PINANG", "KOTA PANGKAL PINANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PGK", null, null, "19" },
                    { "2101", "TNJ", "BINTAN", "KAB BINTAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TNJ", null, null, "21" },
                    { "2102", "TBK", "KARIMUN", "KAB KARIMUN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTH", null, null, "21" },
                    { "2103", "NTX", "NATUNA", "KAB NATUNA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "NTX", null, null, "21" },
                    { "2104", "DKL", "LINGGA", "KAB LINGGA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TNJ", null, null, "21" },
                    { "2105", "NWK", "KEPULAUAN ANAMBAS", "KAB KEPULAUAN ANAMBAS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTH", null, null, "21" },
                    { "2171", "BTH", "BATAM", "KOTA BATAM", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BTH", null, null, "21" },
                    { "2172", "TNJ", "TANJUNG PINANG", "KOTA TANJUNG PINANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TNJ", null, null, "21" },
                    { "3101", "PPJ", "KEPULAUAN SERIBU", "KAB ADM KEP SERIBU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CGK", null, null, "31" },
                    { "3171", "CGK", "JAKARTA PUSAT", "KOTA ADM JAKARTA PUSAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CGK", null, null, "31" },
                    { "3172", "CGK", "JAKARTA UTARA", "KOTA ADM JAKARTA UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CGK", null, null, "31" },
                    { "3173", "CGK", "JAKARTA BARAT", "KOTA ADM JAKARTA BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CGK", null, null, "31" },
                    { "3174", "CGK", "JAKARTA SELATAN", "KOTA ADM JAKARTA SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CGK", null, null, "31" },
                    { "3175", "CGK", "JAKARTA TIMUR", "KOTA ADM JAKARTA TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CGK", null, null, "31" },
                    { "3201", "BOO", "BOGOR", "KAB BOGOR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BOO", null, null, "32" },
                    { "3202", "SMI", "SUKABUMI", "KAB SUKABUMI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SMI", null, null, "32" },
                    { "3203", "CIJ", "CIANJUR", "KAB CIANJUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CIJ", null, null, "32" },
                    { "3204", "BDO", "BANDUNG", "KAB BANDUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDO", null, null, "32" },
                    { "3205", "GRT", "GARUT", "KAB GARUT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GRT", null, null, "32" },
                    { "3206", "TSY", "TASIKMALAYA", "KAB TASIKMALAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TSY", null, null, "32" },
                    { "3207", "CMI", "CIAMIS", "KAB CIAMIS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TSY", null, null, "32" },
                    { "3208", "KGN", "KUNINGAN", "KAB KUNINGAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KGN", null, null, "32" },
                    { "3209", "CBN", "CIREBON", "KAB CIREBON", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CBN", null, null, "32" },
                    { "3210", "KJT", "MAJALENGKA", "KAB MAJALENGKA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KJT", null, null, "32" },
                    { "3211", "BDO", "SUMEDANG", "KAB SUMEDANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDO", null, null, "32" },
                    { "3212", "CBN", "INDRAMAYU", "KAB INDRAMAYU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CBN", null, null, "32" },
                    { "3213", "CKP", "SUBANG", "KAB SUBANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CKP", null, null, "32" },
                    { "3214", "CKP", "PURWAKARTA", "KAB PURWAKARTA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CKP", null, null, "32" },
                    { "3215", "CKP", "KARAWANG", "KAB KARAWANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CKP", null, null, "32" },
                    { "3216", "BKI", "BEKASI", "KAB BEKASI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKI", null, null, "32" },
                    { "3217", "BDO", "BANDUNG", "KAB BANDUNG BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDO", null, null, "32" },
                    { "3218", "BJR", "PANGANDARAN", "KAB PANGANDARAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TSY", null, null, "32" },
                    { "3271", "BOO", "BOGOR", "KOTA BOGOR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BOO", null, null, "32" },
                    { "3272", "SMI", "SUKABUMI", "KOTA SUKABUMI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SMI", null, null, "32" },
                    { "3273", "BDO", "BANDUNG", "KOTA BANDUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDO", null, null, "32" },
                    { "3274", "CBN", "CIREBON", "KOTA CIREBON", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CBN", null, null, "32" },
                    { "3275", "BKI", "BEKASI", "KOTA BEKASI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BKI", null, null, "32" },
                    { "3276", "DPK", "DEPOK", "KOTA DEPOK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPK", null, null, "32" },
                    { "3277", "BDO", "CIMAHI", "KOTA CIMAHI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDO", null, null, "32" },
                    { "3278", "TSY", "TASIKMALAYA", "KOTA TASIKMALAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TSY", null, null, "32" },
                    { "3279", "BJR", "BANJAR", "KOTA BANJAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TSY", null, null, "32" },
                    { "3301", "CXP", "CILACAP", "KAB CILACAP", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CXP", null, null, "33" },
                    { "3302", "PWO", "BANYUMAS", "KAB BANYUMAS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PWO", null, null, "33" },
                    { "3303", "PWL", "PURBALINGGA", "KAB PURBALINGGA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PWO", null, null, "33" },
                    { "3304", "BJG", "BANJARNEGARA", "KAB BANJARNEGARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BJG", null, null, "33" },
                    { "3305", "KBM", "KEBUMEN", "KAB KEBUMEN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KBM", null, null, "33" },
                    { "3306", "MGL", "PURWOREJO", "KAB PURWOREJO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MGL", null, null, "33" },
                    { "3307", "BJG", "WONOSOBO", "KAB WONOSOBO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BJG", null, null, "33" },
                    { "3308", "MGL", "MAGELANG", "KAB MAGELANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MGL", null, null, "33" },
                    { "3309", "BYL", "BOYOLALI", "KAB BOYOLALI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOC", null, null, "33" },
                    { "3310", "KLN", "KLATEN", "KAB KLATEN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KLN", null, null, "33" },
                    { "3311", "SKH", "SUKOHARJO", "KAB SUKOHARJO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOC", null, null, "33" },
                    { "3312", "SKH", "WONOGIRI", "KAB WONOGIRI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SKH", null, null, "33" },
                    { "3313", "SOC", "KARANGANYAR", "KAB KARANGANYAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOC", null, null, "33" },
                    { "3314", "SRN", "SRAGEN", "KAB SRAGEN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOC", null, null, "33" },
                    { "3315", "PWD", "GROBOGAN", "KAB GROBOGAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PWD", null, null, "33" },
                    { "3316", "BLA", "BLORA", "KAB BLORA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PWD", null, null, "33" },
                    { "3317", "RBG", "REMBANG", "KAB REMBANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PTI", null, null, "33" },
                    { "3318", "PTI", "PATI", "KAB PATI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PTI", null, null, "33" },
                    { "3319", "KDS", "KUDUS", "KAB KUDUS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDS", null, null, "33" },
                    { "3320", "KDS", "JEPARA", "KAB JEPARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDS", null, null, "33" },
                    { "3321", "DMK", "DEMAK", "KAB DEMAK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DMK", null, null, "33" },
                    { "3322", "SRG", "SEMARANG", "KAB SEMARANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRG", null, null, "33" },
                    { "3323", "MGL", "TEMANGGUNG", "KAB TEMANGGUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MGL", null, null, "33" },
                    { "3324", "SRG", "KENDAL", "KAB KENDAL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRG", null, null, "33" },
                    { "3325", "PKL", "BATANG", "KAB BATANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKL", null, null, "33" },
                    { "3326", "PKL", "PEKALONGAN", "KAB PEKALONGAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKL", null, null, "33" },
                    { "3327", "TGL", "PEMALANG", "KAB PEMALANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TGL", null, null, "33" },
                    { "3328", "TGL", "TEGAL", "KAB TEGAL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TGL", null, null, "33" },
                    { "3329", "TGL", "BREBES", "KAB BREBES", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TGL", null, null, "33" },
                    { "3371", "MGL", "MAGELANG", "KOTA MAGELANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MGL", null, null, "33" },
                    { "3372", "SOC", "SURAKARTA", "KOTA SURAKARTA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOC", null, null, "33" },
                    { "3373", "SLT", "SALATIGA", "KOTA SALATIGA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SLT", null, null, "33" },
                    { "3374", "SRG", "SEMARANG", "KOTA SEMARANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRG", null, null, "33" },
                    { "3375", "PKL", "PEKALONGAN", "KOTA PEKALONGAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKL", null, null, "33" },
                    { "3376", "TGL", "TEGAL", "KOTA TEGAL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TGL", null, null, "33" },
                    { "3401", "YOG", "KULON PROGO", "KAB KULON PROGO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "YOG", null, null, "34" },
                    { "3402", "YOG", "BANTUL", "KAB BANTUL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "YOG", null, null, "34" },
                    { "3403", "YOG", "GUNUNGKIDUL", "KAB GUNUNGKIDUL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "YOG", null, null, "34" },
                    { "3404", "YOG", "SLEMAN", "KAB SLEMAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "YOG", null, null, "34" },
                    { "3471", "YOG", "YOGYAKARTA", "KOTA YOGYAKARTA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "YOG", null, null, "34" },
                    { "3501", "PCT", "PACITAN", "KAB PACITAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDN", null, null, "35" },
                    { "3502", "MDN", "PONOROGO", "KAB PONOROGO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDN", null, null, "35" },
                    { "3503", "KDR", "TRENGGALEK", "KAB TRENGGALEK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDR", null, null, "35" },
                    { "3504", "KDR", "TULUNGAGUNG", "KAB TULUNGAGUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDR", null, null, "35" },
                    { "3505", "KDR", "BLITAR", "KAB BLITAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDR", null, null, "35" },
                    { "3506", "KDR", "KEDIRI", "KAB KEDIRI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDR", null, null, "35" },
                    { "3507", "MLG", "MALANG", "KAB MALANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MLG", null, null, "35" },
                    { "3508", "JBB", "LUMAJANG", "KAB LUMAJANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "JBB", null, null, "35" },
                    { "3509", "JBB", "JEMBER", "KAB JEMBER", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "JBB", null, null, "35" },
                    { "3510", "BYW", "BANYUWANGI", "KAB BANYUWANGI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BYW", null, null, "35" },
                    { "3511", "SBD", "BONDOWOSO", "KAB BONDOWOSO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SBD", null, null, "35" },
                    { "3512", "SBD", "SITUBONDO", "KAB SITUBONDO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SBD", null, null, "35" },
                    { "3513", "PBL", "PROBOLINGGO", "KAB PROBOLINGGO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PBL", null, null, "35" },
                    { "3514", "PSN", "PASURUAN", "KAB PASURUAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PSN", null, null, "35" },
                    { "3515", "SDA", "SIDOARJO", "KAB SIDOARJO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SDA", null, null, "35" },
                    { "3516", "SDA", "MOJOKERTO", "KAB MOJOKERTO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SDA", null, null, "35" },
                    { "3517", "KDR", "JOMBANG", "KAB JOMBANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDR", null, null, "35" },
                    { "3518", "KDR", "NGANJUK", "KAB NGANJUK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDR", null, null, "35" },
                    { "3519", "MDN", "MADIUN", "KAB MADIUN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDN", null, null, "35" },
                    { "3520", "MGT", "MAGETAN", "KAB MAGETAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDN", null, null, "35" },
                    { "3521", "NGW", "NGAWI", "KAB NGAWI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDN", null, null, "35" },
                    { "3522", "BJN", "BOJONEGORO", "KAB BOJONEGORO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BJN", null, null, "35" },
                    { "3523", "SUB", "TUBAN", "KAB TUBAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SUB", null, null, "35" },
                    { "3524", "LMG", "LAMONGAN", "KAB LAMONGAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "LMG", null, null, "35" },
                    { "3525", "SUB", "GRESIK", "KAB GRESIK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SUB", null, null, "35" },
                    { "3526", "SUP", "BANGKALAN", "KAB BANGKALAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SUB", null, null, "35" },
                    { "3527", "SPG", "SAMPANG", "KAB SAMPANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SPG", null, null, "35" },
                    { "3528", "SUP", "PAMEKASAN", "KAB PAMEKASAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SUB", null, null, "35" },
                    { "3529", "SUP", "SUMENEP", "KAB SUMENEP", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SUB", null, null, "35" },
                    { "3571", "KDR", "KEDIRI", "KOTA KEDIRI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDR", null, null, "35" },
                    { "3572", "KDR", "BLITAR", "KOTA BLITAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDR", null, null, "35" },
                    { "3573", "MLG", "MALANG", "KOTA MALANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MLG", null, null, "35" },
                    { "3574", "PBL", "PROBOLINGGO", "KOTA PROBOLINGGO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SUB", null, null, "35" },
                    { "3575", "PSN", "PASURUAN", "KOTA PASURUAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PSN", null, null, "35" },
                    { "3576", "SDA", "MOJOKERTO", "KOTA MOJOKERTO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SDA", null, null, "35" },
                    { "3577", "MDN", "MADIUN", "KOTA MADIUN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDN", null, null, "35" },
                    { "3578", "SUB", "SURABAYA", "KOTA SURABAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SUB", null, null, "35" },
                    { "3579", "MLG", "BATU", "KOTA BATU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MLG", null, null, "35" },
                    { "3591", "BXW", "BAWEAN", "PULAU BAWEAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BXW", null, null, "35" },
                    { "3601", "CLG", "PANDEGLANG", "KAB PANDEGLANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CLG", null, null, "36" },
                    { "3602", "CLG", "LEBAK", "KAB LEBAK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CLG", null, null, "36" },
                    { "3603", "TNG", "TANGERANG", "KAB TANGERANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TNG", null, null, "36" },
                    { "3604", "CLG", "SERANG", "KAB SERANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CLG", null, null, "36" },
                    { "3671", "TNG", "TANGERANG", "KOTA TANGERANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TNG", null, null, "36" },
                    { "3672", "CLG", "CILEGON", "KOTA CILEGON", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CLG", null, null, "36" },
                    { "3673", "CLG", "SERANG", "KOTA SERANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "CLG", null, null, "36" },
                    { "3674", "TNG", "TANGERANG", "KOTA TANGERANG SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TNG", null, null, "36" },
                    { "5101", "DPS", "JEMBRANA", "KAB JEMBRANA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPS", null, null, "51" },
                    { "5102", "DPS", "TABANAN", "KAB TABANAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPS", null, null, "51" },
                    { "5103", "DPS", "BADUNG", "KAB BADUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPS", null, null, "51" },
                    { "5104", "GIR", "GIANYAR", "KAB GIANYAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GIR", null, null, "51" },
                    { "5105", "DPS", "KLUNGKUNG", "KAB KLUNGKUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPS", null, null, "51" },
                    { "5106", "DPS", "BANGLI", "KAB BANGLI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPS", null, null, "51" },
                    { "5107", "DPS", "KARANGASEM", "KAB KARANGASEM", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPS", null, null, "51" },
                    { "5108", "DPS", "BULELENG", "KAB BULELENG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPS", null, null, "51" },
                    { "5171", "DPS", "DENPASAR", "KOTA DENPASAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DPS", null, null, "51" },
                    { "5201", "AMI", "LOMBOK BARAT", "KAB LOMBOK BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5202", "PYA", "LOMBOK TENGAH", "KAB LOMBOK TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5203", "PYA", "LOMBOK TIMUR", "KAB LOMBOK TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5204", "LYK", "SUMBAWA", "KAB SUMBAWA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5205", "DPU", "DOMPU", "KAB DOMPU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5206", "BMU", "BIMA", "KAB BIMA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5207", "SWQ", "SUMBAWA BARAT", "KAB SUMBAWA BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5208", "PYA", "LOMBOK UTARA", "KAB LOMBOK UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5271", "AMI", "MATARAM", "KOTA MATARAM", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5272", "BMU", "BIMA", "KOTA BIMA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMI", null, null, "52" },
                    { "5301", "KOE", "KUPANG", "KAB KUPANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5302", "SOE", "TIMOR TENGAH SELATAN", "KAB TIMOR TENGAH SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5303", "KEF", "TIMOR TENGAH UTARA", "KAB TIMOR TENGAH UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5304", "ATB", "BELU", "KAB BELU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5305", "ARD", "ALOR", "KAB ALOR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5306", "LWE", "FLORES TIMUR", "KAB FLORES TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5307", "MME", "SIKKA", "KAB SIKKA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5308", "ENE", "ENDE", "KAB ENDE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5309", "BXD", "NGADA", "KAB NGADA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5310", "BJW", "MANGGARAI", "KAB MANGGARAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5311", "WGP", "SUMBA TIMUR", "KAB SUMBA TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5312", "TMC", "SUMBA BARAT", "KAB SUMBA BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5313", "LWA", "LEMBATA", "KAB LEMBATA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5314", "RTI", "ROTE NDAO", "KAB ROTE NDAO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5315", "LBJ", "MANGGARAI BARAT", "KAB MANGGARAI BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5316", "BXD", "NAGEKEO", "KAB NAGEKEO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5317", "TMC", "SUMBA TENGAH", "KAB SUMBA TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5318", "TMC", "SUMBA BARAT DAYA", "KAB SUMBA BARAT DAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5319", "BJW", "MANGGARAI TIMUR", "KAB MANGGARAI TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5320", "SEB", "SABU RAIJUA", "KAB SABU RAIJUA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5321", "KEF", "MALAKA", "KAB MALAKA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "5371", "KOE", "KUPANG", "KOTA KUPANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KOE", null, null, "53" },
                    { "6101", "SBS", "SAMBAS", "KAB SAMBAS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6102", "MPW", "MEMPAWAH", "KAB MEMPAWAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6103", "SGO", "SANGGAU", "KAB SANGGAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6104", "KTG", "KETAPANG", "KAB KETAPANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6105", "SQG", "SINTANG", "KAB SINTANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6106", "PTS", "KAPUAS HULU", "KAB KAPUAS HULU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6107", "BKY", "BENGKAYANG", "KAB BENGKAYANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6108", "LDK", "LANDAK", "KAB LANDAK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6109", "SKD", "SEKADAU", "KAB SEKADAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6110", "MLW", "MELAWI", "KAB MELAWI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6111", "KKU", "KAYONG UTARA", "KAB KAYONG UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6112", "KKR", "KUBU RAYA", "KAB KUBU RAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6171", "PNK", "PONTIANAK", "KOTA PONTIANAK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6172", "SKW", "SINGKAWANG", "KOTA SINGKAWANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PNK", null, null, "61" },
                    { "6201", "PBU", "KOTAWARINGIN BARAT", "KAB KOTAWARINGIN BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PBU", null, null, "62" },
                    { "6202", "SMQ", "KOTAWARINGIN TIMUR", "KAB KOTAWARINGIN TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PBU", null, null, "62" },
                    { "6203", "KPS", "KAPUAS", "KAB KAPUAS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "62" },
                    { "6204", "BTS", "BARITO SELATAN", "KAB BARITO SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6205", "MTW", "BARITO UTARA", "KAB BARITO UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6206", "KTN", "KATINGAN", "KAB KATINGAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6207", "SRY", "SERUYAN", "KAB SERUYAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6208", "SRA", "SUKAMARA", "KAB SUKAMARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PBU", null, null, "62" },
                    { "6209", "LMD", "LAMANDAU", "KAB LAMANDAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PBU", null, null, "62" },
                    { "6210", "KRN", "GUNUNG MAS", "KAB GUNUNG MAS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6211", "PPS", "PULANG PISAU", "KAB PULANG PISAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6212", "PCH", "MURUNG RAYA", "KAB MURUNG RAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6213", "TMY", "BARITO TIMUR", "KAB BARITO TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6271", "PKY", "PALANGKARAYA", "KOTA PALANGKARAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PKY", null, null, "62" },
                    { "6301", "PLE", "TANAH LAUT", "KAB TANAH LAUT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6302", "KTB", "KOTABARU", "KAB KOTABARU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6303", "BJB", "BANJAR", "KAB BANJAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6304", "MRB", "BARITO KUALA", "KAB BARITO KUALA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6305", "KDG", "TAPIN", "KAB TAPIN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6306", "KDG", "HULU SUNGAI SELATAN", "KAB HULU SUNGAI SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6307", "KDG", "HULU SUNGAI TENGAH", "KAB HULU SUNGAI TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6308", "AMT", "HULU SUNGAI UTARA", "KAB HULU SUNGAI UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6309", "TNJ", "TABALONG", "KAB TABALONG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6310", "BTL", "TANAH BUMBU", "KAB TANAH BUMBU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6311", "TNJ", "BALANGAN", "KAB BALANGAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6371", "BDJ", "BANJARMASIN", "KOTA BANJARMASIN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6372", "BJB", "BANJARBARU", "KOTA BANJARBARU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BDJ", null, null, "63" },
                    { "6401", "TMB", "PASER", "KAB PASER", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BPN", null, null, "64" },
                    { "6402", "KOD", "KUTAI KARTANEGARA", "KAB KUTAI KARTANEGARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRI", null, null, "64" },
                    { "6403", "BEJ", "BERAU", "KAB BERAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BPN", null, null, "64" },
                    { "6407", "DTD", "KUTAI BARAT", "KAB KUTAI BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRI", null, null, "64" },
                    { "6408", "SGT", "KUTAI TIMUR", "KAB KUTAI TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRI", null, null, "64" },
                    { "6409", "PPU", "PENAJAM PASER UTARA", "KAB PENAJAM PASER UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BPN", null, null, "64" },
                    { "6411", "SRI", "MAHAKAM ULU", "KAB MAHAKAM ULU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRI", null, null, "64" },
                    { "6471", "BPN", "BALIKPAPAN", "KOTA BALIKPAPAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BPN", null, null, "64" },
                    { "6472", "SRI", "SAMARINDA", "KOTA SAMARINDA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRI", null, null, "64" },
                    { "6474", "BXT", "BONTANG", "KOTA BONTANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SRI", null, null, "64" },
                    { "6501", "TRK", "BULUNGAN", "KAB BULUNGAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TRK", null, null, "65" },
                    { "6502", "TRK", "MALINAU", "KAB MALINAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TRK", null, null, "65" },
                    { "6503", "TRK", "NUNUKAN", "KAB NUNUKAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TRK", null, null, "65" },
                    { "6504", "TRK", "TANA TIDUNG", "KAB TANA TIDUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TRK", null, null, "65" },
                    { "6571", "TRK", "TARAKAN", "KOTA TARAKAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TRK", null, null, "65" },
                    { "7101", "KTO", "BOLAANG MONGONDOW", "KAB BOLAANG MONGONDOW", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7102", "TDO", "MINAHASA", "KAB MINAHASA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7103", "THU", "KEPULAUAN SANGIHE", "KAB KEPULAUAN SANGIHE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7104", "TLD", "KEPULAUAN TALAUD", "KAB KEPULAUAN TALAUD", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7105", "AMR", "MINAHASA SELATAN", "KAB MINAHASA SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7106", "ARM", "MINAHASA UTARA", "KAB MINAHASA UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7107", "RTH", "MINAHASA TENGGARA", "KAB MINAHASA TENGGARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7108", "BMU", "BOLAANG MONGONDOW UTARA", "KAB BOLAANG MONGONDOW UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7109", "STR", "KEP SIAU", "KAB KEP SIAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7110", "BMT", "BOLAANG MONGONDOW TIMUR", "KAB BOLAANG MONGONDOW TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7111", "BMS", "BOLAANG MONGONDOW SELATAN", "KAB BOLAANG MONGONDOW SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7171", "MDC", "MANADO", "KOTA MANADO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7172", "BTU", "BITUNG", "KOTA BITUNG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7173", "TMH", "TOMOHON", "KOTA TOMOHON", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7174", "KTO", "KOTAMOBAGU", "KOTA KOTAMOBAGU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "71" },
                    { "7201", "BGI", "BANGGAI", "KAB BANGGAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7202", "PSJ", "POSO", "KAB POSO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7203", "DGL", "DONGGALA", "KAB DONGGALA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7204", "TOL", "TOLI TOLI", "KAB TOLI TOLI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7205", "BUO", "BUOL", "KAB BUOL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7206", "MOR", "MOROWALI", "KAB MOROWALI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7207", "BGK", "BANGGAI KEPULAUAN", "KAB BANGGAI KEPULAUAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7208", "PGM", "PARIGI MOUTONG", "KAB PARIGI MOUTONG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7209", "TJU", "TOJO UNA UNA", "KAB TOJO UNA UNA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7210", "SIM", "SIGI", "KAB SIGI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7211", "BGL", "BANGGAI LAUT", "KAB BANGGAI LAUT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7212", "MRU", "MOROWALI UTARA", "KAB MOROWALI UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7271", "PLW", "PALU", "KOTA PALU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "72" },
                    { "7301", "SLY", "KEPULAUAN SELAYAR", "KAB KEPULAUAN SELAYAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7302", "BUL", "BULUKUMBA", "KAB BULUKUMBA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7303", "UPG", "BANTAENG", "KAB BANTAENG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7304", "UPG", "JENEPONTO", "KAB JENEPONTO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7305", "UPG", "TAKALAR", "KAB TAKALAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7306", "UPG", "GOWA", "KAB GOWA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7307", "BUL", "SINJAI", "KAB SINJAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7308", "BNE", "BONE", "KAB BONE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7309", "MRS", "MAROS", "KAB MAROS", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7310", "PKP", "PANGKAJENE", "KAB PANGKAJENE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7311", "BRU", "BARRU", "KAB BARRU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7312", "SOP", "SOPPENG", "KAB SOPPENG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7313", "SKG", "WAJO", "KAB WAJO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7314", "SDR", "SIDENRENG RAPPANG", "KAB SIDENRENG RAPPANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7315", "PIN", "PINRANG", "KAB PINRANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7316", "EKG", "ENREKANG", "KAB ENREKANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7317", "LUW", "LUWU", "KAB LUWU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7318", "MKL", "TANA TORAJA", "KAB TANA TORAJA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7322", "LUT", "LUWU UTARA", "KAB LUWU UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7324", "LUM", "LUWU TIMUR", "KAB LUWU TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7326", "RTP", "TORAJA UTARA", "KAB TORAJA UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7371", "UPG", "MAKASSAR", "KOTA MAKASSAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7372", "PRE", "PARE PARE", "KOTA PARE PARE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7373", "PLP", "PALOPO", "KOTA PALOPO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "73" },
                    { "7401", "KKA", "KOLAKA", "KAB KOLAKA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7402", "UNH", "KONAWE", "KAB KONAWE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7403", "RAH", "MUNA", "KAB MUNA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7404", "BUW", "BUTON", "KAB BUTON", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7405", "UNH", "KONAWE SELATAN", "KAB KONAWE SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7406", "RMB", "BOMBANA", "KAB BOMBANA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7407", "WKB", "WAKATOBI", "KAB WAKATOBI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7408", "KKA", "KOLAKA UTARA", "KAB KOLAKA UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7409", "UNH", "KONAWE UTARA", "KAB KONAWE UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7410", "BUW", "BUTON UTARA", "KAB BUTON UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7411", "KKA", "KOLAKA TIMUR", "KAB KOLAKA TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7412", "UNH", "KONAWE KEPULAUAN", "KAB KONAWE KEPULAUAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7413", "RAH", "MUNA BARAT", "KAB MUNA BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7414", "BUW", "BUTON TENGAH", "KAB BUTON TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7415", "BUW", "BUTON SELATAN", "KAB BUTON SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7471", "KDI", "KENDARI", "KOTA KENDARI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7472", "BUW", "BAU BAU", "KOTA BAU BAU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "KDI", null, null, "74" },
                    { "7501", "GTL", "GORONTALO", "KAB GORONTALO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GTO", null, null, "75" },
                    { "7502", "BLM", "BOALEMO", "KAB BOALEMO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GTO", null, null, "75" },
                    { "7503", "BLO", "BONE BOLANGO", "KAB BONE BOLANGO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GTO", null, null, "75" },
                    { "7504", "PWH", "PAHUWATO", "KAB PAHUWATO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GTO", null, null, "75" },
                    { "7505", "LBT", "GORONTALO UTARA", "KAB GORONTALO UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GTO", null, null, "75" },
                    { "7571", "GTO", "GORONTALO", "KOTA GORONTALO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GTO", null, null, "75" },
                    { "7601", "MJU", "MAMUJU UTARA", "KAB MAMUJU UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "PLW", null, null, "76" },
                    { "7602", "MMJ", "MAMUJU", "KAB MAMUJU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "76" },
                    { "7603", "MMS", "MAMASA", "KAB MAMASA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "76" },
                    { "7604", "POL", "POLEWALI MANDAR", "KAB POLEWALI MANDAR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "76" },
                    { "7605", "MJN", "MAJENE", "KAB MAJENE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "76" },
                    { "7606", "MJT", "MAMUJU TENGAH", "KAB MAMUJU TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "UPG", null, null, "76" },
                    { "8101", "AHI", "MALUKU TENGAH", "KAB MALUKU TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8102", "LUV", "MALUKU TENGGARA", "KAB MALUKU TENGGARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8103", "SXK", "MALUKU TENGGARA BARAT", "KAB MALUKU TENGGARA BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8104", "NAM", "BURU", "KAB BURU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8105", "BUL", "SERAM BAGIAN TIMUR", "KAB SERAM BAGIAN TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8106", "WHI", "SERAM BAGIAN BARAT", "KAB SERAM BAGIAN BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8107", "DOB", "KEPULAUAN ARU", "KAB KEPULAUAN ARU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8108", "AMQ", "MALUKU BARAT DAYA", "KAB MALUKU BARAT DAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8109", "NRE", "BURU SELATAN", "KAB BURU SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8171", "AMQ", "AMBON", "KOTA AMBON", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8172", "LUV", "TUAL", "KOTA TUAL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AMQ", null, null, "81" },
                    { "8201", "BCN", "HALMAHERA BARAT", "KAB HALMAHERA BARAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8202", "SSP", "HALMAHERA TENGAH", "KAB HALMAHERA TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8203", "TBL", "HALMAHERA UTARA", "KAB HALMAHERA UTARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8204", "WDA", "HALMAHERA SELATAN", "KAB HALMAHERA SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8205", "SLA", "KEPULAUAN SULA", "KAB KEPULAUAN SULA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8206", "BLI", "HALMAHERA TIMUR", "KAB HALMAHERA TIMUR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8207", "MRT", "PULAU MOROTAI", "KAB PULAU MOROTAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8208", "TLB", "PULAU TALIABU", "KAB PULAU TALIABU", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8271", "TTE", "TERNATE", "KOTA TERNATE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TTE", null, null, "82" },
                    { "8272", "TDR", "TIDORE KEPULAUAN", "KOTA TIDORE KEPULAUAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MDC", null, null, "82" },
                    { "9101", "MKQ", "MERAUKE", "KAB MERAUKE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MKQ", null, null, "91" },
                    { "9102", "WMX", "JAYAWIJAYA", "KAB JAYAWIJAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9103", "DJJ", "JAYAPURA", "KAB JAYAPURA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9104", "NBX", "NABIRE", "KAB NABIRE", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BIK", null, null, "91" },
                    { "9105", "ZRI", "KEPULAUAN YAPEN", "KAB KEPULAUAN YAPEN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BIK", null, null, "91" },
                    { "9106", "BIK", "BIAK NUMFOR", "KAB BIAK NUMFOR", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BIK", null, null, "91" },
                    { "9107", "ELR", "PUNCAK JAYA", "KAB PUNCAK JAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9108", "ILA", "PANIAI", "KAB PANIAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BIK", null, null, "91" },
                    { "9109", "TIM", "MIMIKA", "KAB MIMIKA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TIM", null, null, "91" },
                    { "9110", "ZRM", "SARMI", "KAB SARMI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9111", "WAR", "KEEROM", "KAB KEEROM", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9112", "OKL", "PEGUNUNGAN BINTANG", "KAB PEGUNUNGAN BINTANG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9113", "DEK", "YAHUKIMO", "KAB YAHUKIMO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9114", "KBF", "TOLIKARA", "KAB TOLIKARA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9115", "BTW", "WAROPEN", "KAB WAROPEN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BIK", null, null, "91" },
                    { "9116", "MDP", "BOVEN DIGOEL", "KAB BOVEN DIGOEL", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MKQ", null, null, "91" },
                    { "9117", "KEI", "MAPPI", "KAB MAPPI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MKQ", null, null, "91" },
                    { "9118", "AGT", "ASMAT", "KAB ASMAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MKQ", null, null, "91" },
                    { "9119", "SRW", "SUPIORI", "KAB SUPIORI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BIK", null, null, "91" },
                    { "9120", "OKL", "MAMBERAMO RAYA", "KAB MAMBERAMO RAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9121", "OKL", "MAMBERAMO TENGAH", "KAB MAMBERAMO TENGAH", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9122", "ELM", "YALIMO", "KAB YALIMO", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9123", "TOM", "LANNY JAYA", "KAB LANNY JAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9124", "KYM", "NDUGA", "KAB NDUGA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9125", "ILA", "PUNCAK", "KAB PUNCAK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9126", "NBX", "DOGIYAI", "KAB DOGIYAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9127", "ZGP", "INTAN JAYA", "KAB INTAN JAYA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9128", "TIG", "DEIYAI", "KAB DEIYAI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BIK", null, null, "91" },
                    { "9171", "DJJ", "JAYAPURA", "KOTA JAYAPURA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "91" },
                    { "9201", "SOQ", "SORONG", "KAB SORONG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" },
                    { "9202", "MKW", "MANOKWARI", "KAB MANOKWARI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MKW", null, null, "92" },
                    { "9203", "FFK", "FAK FAK", "KAB FAK FAK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" },
                    { "9204", "SOQ", "SORONG SELATAN", "KAB SORONG SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" },
                    { "9205", "GAV", "RAJA AMPAT", "KAB RAJA AMPAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" },
                    { "9206", "NTI", "TELUK BINTUNI", "KAB TELUK BINTUNI", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" },
                    { "9207", "RAS", "TELUK WONDAMA", "KAB TELUK WONDAMA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MKW", null, null, "92" },
                    { "9208", "KNG", "KAIMANA", "KAB KAIMANA", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" },
                    { "9209", "FEF", "TAMBRAUW", "KAB TAMBRAUW", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" },
                    { "9210", "AFT", "MAYBRAT", "KAB MAYBRAT", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" },
                    { "9211", "MKW", "MANOKWARI SELATAN", "KAB MANOKWARI SELATAN", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MKW", null, null, "92" },
                    { "9212", "MKW", "PEGUNUNGAN ARFAK", "KAB PEGUNUNGAN ARFAK", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJJ", null, null, "92" },
                    { "9271", "SOQ", "SORONG", "KOTA SORONG", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SOQ", null, null, "92" }
                });

            migrationBuilder.InsertData(
                table: "app_menu",
                columns: new[] { "menuid", "createdby", "createddate", "description", "flag", "icon", "menuname", "menusort", "modifieddate", "modifier", "moduleid", "parentid", "path", "properties" },
                values: new object[,]
                {
                    { "1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-fingerprint", "Identity", 1, null, null, "101", "", null, null },
                    { "1.1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-user", "User Data", 1, null, null, "101", "1.1", "/admin/user", null },
                    { "1.1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-user-shield", "Role Data", 2, null, null, "101", "1.1", "/admin/role", null },
                    { "1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-wrench", "Configuration", 2, null, null, "101", "", null, null },
                    { "1.2.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-shoe-prints", "Audittrail", 1, null, null, "101", "1.2", "/admin/audittrail", null },
                    { "1.2.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-bell", "Preparing Sign-out", 2, null, null, "101", "1.2", "/admin/preparingsignout", null },
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
                    { "2.4.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-person-arrow-up-from-line", "CRO", 1, null, null, "102", "2.4", "/master/cro", null },
                    { "6.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-truck-ramp-box", "Pickup Entry", 1, null, null, "106", "", null, null },
                    { "6.1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-calendar-plus", "Create Pickup Schedule", 1, null, null, "106", "6.1", "/pickup/entrypickupschedule", null },
                    { "6.1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-phone-volume", "Entry Pickup On-Call", 2, null, null, "106", "6.1", "/pickup/entrypickuponcall", null },
                    { "6.1.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-user-pen", "Entry Pickup Client", 3, null, null, "106", "6.1", "/pickup/entrypickupclient", null },
                    { "6.1.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Entry Pickup Custom", 4, null, null, "106", "6.1", null, null },
                    { "6.1.4.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Entry Pickup Danamon (Pickup)", 1, null, null, "106", "6.1.4", "/pickup/pickupdanamon", null },
                    { "6.1.4.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Entry Pickup Danamon (Retrieval)", 2, null, null, "106", "6.1.4", "/pickup/pickupdanamon", null },
                    { "6.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-cube", "Pickup Status", 2, null, null, "106", "", null, null },
                    { "6.2.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Assign Branch in Charge", 1, null, null, "106", "6.2", "/pickup/assignpickup", null },
                    { "6.2.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Assign Courier", 2, null, null, "106", "6.2", "/pickup/assigncourier", null },
                    { "6.2.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Reschedule Pickup", 3, null, null, "106", "6.2", "/pickup/reschedulepickup", null },
                    { "6.2.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Dispatch to Courier", 4, null, null, "106", "6.2", "/pickup/dispatchtocourier", null },
                    { "6.2.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-marker", "Success Pikup", 5, null, null, "106", "6.2", "/pickup/successpickup", null },
                    { "6.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-cube", "Monitoring Pickup", 3, null, null, "106", "", null, null },
                    { "6.3.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "View Timeline Status", 1, null, null, "106", "6.3", "/pickup/viewstatuspickup", null },
                    { "7.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-cube", "Pra-Delivery", 1, null, null, "107", "", null, null },
                    { "7.1.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-list-ol", "Airwaybill Inventory", 1, null, null, "107", "7.1", "/ocl/awbinventory", null },
                    { "7.1.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-filter", "Pra-Upload", 2, null, null, "107", "7.1", "/ocl/praupload", null },
                    { "7.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-floppy-disk", "Corporate Data Entry", 2, null, null, "107", "", null, null },
                    { "7.2.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data Primary", 1, null, null, "107", "7.2", "/ocl/entrydataprimary", null },
                    { "7.2.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data National", 2, null, null, "107", "7.2", "/ocl/entrydatanational", null },
                    { "7.2.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data Internal", 3, null, null, "107", "7.2", "/ocl/entrydatainternal", null },
                    { "7.2.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data COD", 4, null, null, "107", "7.2", "/ocl/entrydatacod", null },
                    { "7.2.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data Preprinted", 5, null, null, "107", "7.2", "/ocl/entrydatapriprinted", null },
                    { "7.2.6", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data trucking", 6, null, null, "107", "7.2", "/ocl/entrydatatrucking", null },
                    { "7.2.7", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Data API", 7, null, null, "107", "7.2", "/ocl/entrydataapi", null },
                    { "7.2.8", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-file-excel", "Upload Data Primary", 8, null, null, "107", "7.2", "/ocl/uploaddataprimary", null },
                    { "7.2.9", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-file-excel", "Upload Data COD", 9, null, null, "107", "7.2", "/ocl/uploaddatacod", null },
                    { "7.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-floppy-disk", "Retail Data Entry", 3, null, null, "107", "", null, null },
                    { "7.3.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Retail Regular", 1, null, null, "107", "7.3", "/ocl/entryretailprimary", null },
                    { "7.3.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Retail NFD", 2, null, null, "107", "7.3", "/ocl/entryretailnfd", null },
                    { "7.3.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Retail API", 3, null, null, "107", "7.3", "/ocl/entryretailapi", null },
                    { "7.4", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-earth-americas", "International Data Entry", 4, null, null, "107", "", null, null },
                    { "7.4.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-pen", "Entry Intl Regular", 1, null, null, "107", "7.4", "/ocl/entrydataintl", null },
                    { "7.5", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-tags", "Shipping Label", 5, null, null, "107", "", null, null },
                    { "7.5.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-print", "Print AWB Primary", 1, null, null, "107", "7.5", "/ocl/printawbprimary", null },
                    { "7.5.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-print", "Print AWB Internal", 2, null, null, "107", "7.5", "/ocl/printawbinternal", null },
                    { "7.5.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-print", "Print AWB Intl", 3, null, null, "107", "7.5", "/ocl/printawbnational", null },
                    { "7.6", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-cube", "Shipment Validation", 6, null, null, "107", "", null, null },
                    { "7.6.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-diamond", "Reconcile AWB", 1, null, null, "107", "7.6", "/ocl/shipmentreconcile", null },
                    { "7.7", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-box-open", "Bagging", 7, null, null, "107", "", null, null },
                    { "7.7.1", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-box", "Mother Bag", 1, null, null, "107", "7.7", "/ocl/motherbag", null },
                    { "7.7.2", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-sack-xmark", "Baby Bag", 2, null, null, "107", "7.7", "/ocl/babybag", null },
                    { "7.7.3", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "fa-solid fa-boxes-packing", "Loose Bag", 3, null, null, "107", "7.7", "/ocl/loosebag", null }
                });

            migrationBuilder.InsertData(
                table: "mdt_district",
                columns: new[] { "distid", "cityid", "createdby", "createddate", "distname", "flag", "modifieddate", "modifier" },
                values: new object[] { "317307", "3173", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pal Merah", 1, null, null });

            migrationBuilder.InsertData(
                table: "mdt_village",
                columns: new[] { "villid", "createdby", "createddate", "distid", "flag", "modifieddate", "modifier", "villname" },
                values: new object[] { "3173071006", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "317307", 1, null, null, "Kota Bambu Selatan" });

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
                name: "IX_mdt_awbinventory_awb",
                table: "mdt_awbinventory",
                column: "awb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mdt_awbinventory_branchid",
                table: "mdt_awbinventory",
                column: "branchid");

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
                name: "IX_mdt_courier_couriercode",
                table: "mdt_courier",
                column: "couriercode",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickupregular_acctno",
                table: "pum_pickupregular",
                column: "acctno");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickupregular_branchid",
                table: "pum_pickupregular",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickupregular_couriercode",
                table: "pum_pickupregular",
                column: "couriercode");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickupregular_distid",
                table: "pum_pickupregular",
                column: "distid");

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
                name: "IX_pum_pickupschedule_puregid",
                table: "pum_pickupschedule",
                column: "puregid");

            migrationBuilder.CreateIndex(
                name: "IX_pum_pickupstatuspool_pickupno",
                table: "pum_pickupstatuspool",
                column: "pickupno");

            migrationBuilder.CreateIndex(
                name: "IX_trx_checkpointpool_branchid",
                table: "trx_checkpointpool",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_checkpointpool_couriercode",
                table: "trx_checkpointpool",
                column: "couriercode");

            migrationBuilder.CreateIndex(
                name: "IX_trx_checkpointpool_reasonid",
                table: "trx_checkpointpool",
                column: "reasonid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_checkpointpool_relationid",
                table: "trx_checkpointpool",
                column: "relationid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_cneedirectory_distid",
                table: "trx_cneedirectory",
                column: "distid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_consignee_acctno",
                table: "trx_consignee",
                column: "acctno");

            migrationBuilder.CreateIndex(
                name: "IX_trx_consignee_awb",
                table: "trx_consignee",
                column: "awb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trx_consignee_branchid",
                table: "trx_consignee",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_consignee_distid",
                table: "trx_consignee",
                column: "distid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_payment_awb",
                table: "trx_payment",
                column: "awb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trx_shipmentdetail_awb",
                table: "trx_shipmentdetail",
                column: "awb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trx_shipmentdetail_pickupno",
                table: "trx_shipmentdetail",
                column: "pickupno");

            migrationBuilder.CreateIndex(
                name: "IX_trx_shipper_acctno",
                table: "trx_shipper",
                column: "acctno");

            migrationBuilder.CreateIndex(
                name: "IX_trx_shipper_awb",
                table: "trx_shipper",
                column: "awb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trx_shipper_branchid",
                table: "trx_shipper",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_shipper_distid",
                table: "trx_shipper",
                column: "distid");

            migrationBuilder.CreateIndex(
                name: "IX_trx_void_awb",
                table: "trx_void",
                column: "awb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trx_void_branchid",
                table: "trx_void",
                column: "branchid");
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
                name: "mdt_awbinventory");

            migrationBuilder.DropTable(
                name: "mdt_branchaccount");

            migrationBuilder.DropTable(
                name: "mdt_checkpoint");

            migrationBuilder.DropTable(
                name: "mdt_costcomponent");

            migrationBuilder.DropTable(
                name: "mdt_counter");

            migrationBuilder.DropTable(
                name: "pum_pickupschedule");

            migrationBuilder.DropTable(
                name: "pum_pickupstatuspool");

            migrationBuilder.DropTable(
                name: "trx_attachment");

            migrationBuilder.DropTable(
                name: "trx_checkpointpool");

            migrationBuilder.DropTable(
                name: "trx_cneedirectory");

            migrationBuilder.DropTable(
                name: "trx_consignee");

            migrationBuilder.DropTable(
                name: "trx_costitem");

            migrationBuilder.DropTable(
                name: "trx_payment");

            migrationBuilder.DropTable(
                name: "trx_shipper");

            migrationBuilder.DropTable(
                name: "trx_unititem");

            migrationBuilder.DropTable(
                name: "trx_void");

            migrationBuilder.DropTable(
                name: "app_module");

            migrationBuilder.DropTable(
                name: "mdt_cro");

            migrationBuilder.DropTable(
                name: "pum_pickupregular");

            migrationBuilder.DropTable(
                name: "mdt_reasonun");

            migrationBuilder.DropTable(
                name: "mdt_relation");

            migrationBuilder.DropTable(
                name: "trx_shipmentdetail");

            migrationBuilder.DropTable(
                name: "app_modulectg");

            migrationBuilder.DropTable(
                name: "pum_pickuprequest");

            migrationBuilder.DropTable(
                name: "mdt_account");

            migrationBuilder.DropTable(
                name: "mdt_courier");

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
