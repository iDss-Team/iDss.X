using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AppendMasterDataToDb250602 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branchori",
                table: "trx_void");

            migrationBuilder.RenameColumn(
                name: "reqisuestpoint",
                table: "trx_void",
                newName: "requestpoint");

            migrationBuilder.AlterColumn<decimal>(
                name: "itemvalue",
                table: "trx_shipmentdetail",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "mdt_costcomponent",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<int>(
                name: "issystem",
                table: "mdt_costcomponent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "mdt_country",
                columns: table => new
                {
                    countrycode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    countryname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isoalpha3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    phonecode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_country", x => x.countrycode);
                });

            migrationBuilder.CreateTable(
                name: "mdt_postcode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    villid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_postcode", x => x.id);
                    table.ForeignKey(
                        name: "FK_mdt_postcode_mdt_village_villid",
                        column: x => x.villid,
                        principalTable: "mdt_village",
                        principalColumn: "villid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mdt_cityintl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    citycode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    airport = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    countrycode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    region = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    zone3pl1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    zone3pl2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    zone3pl3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    disc3pl1 = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    disc3pl2 = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    disc3pl3 = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_cityintl", x => x.id);
                    table.ForeignKey(
                        name: "FK_mdt_cityintl_mdt_country_countrycode",
                        column: x => x.countrycode,
                        principalTable: "mdt_country",
                        principalColumn: "countrycode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mdt_cityintl_countrycode",
                table: "mdt_cityintl",
                column: "countrycode");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_postcode_villid",
                table: "mdt_postcode",
                column: "villid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdt_cityintl");

            migrationBuilder.DropTable(
                name: "mdt_postcode");

            migrationBuilder.DropTable(
                name: "mdt_country");

            migrationBuilder.DropColumn(
                name: "issystem",
                table: "mdt_costcomponent");

            migrationBuilder.RenameColumn(
                name: "requestpoint",
                table: "trx_void",
                newName: "reqisuestpoint");

            migrationBuilder.AddColumn<int>(
                name: "branchori",
                table: "trx_void",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "itemvalue",
                table: "trx_shipmentdetail",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "mdt_costcomponent",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);
        }
    }
}
