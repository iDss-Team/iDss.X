using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations.PriceDb
{
    /// <inheritdoc />
    public partial class InitialPriceDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pri_pricegeneral",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oritype = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    oricode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    destype = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    descode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    service = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    minweight = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    maxweight = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    minpiece = table.Column<int>(type: "int", nullable: true),
                    maxpiece = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    addprice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    slafrom = table.Column<int>(type: "int", nullable: true),
                    slato = table.Column<int>(type: "int", nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pri_pricegeneral", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pri_pricegeneral");
        }
    }
}
