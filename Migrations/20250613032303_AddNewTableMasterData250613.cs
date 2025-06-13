using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableMasterData250613 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branchori",
                table: "trx_shipper");

            migrationBuilder.DropColumn(
                name: "statecode",
                table: "trx_shipper");

            migrationBuilder.DropColumn(
                name: "branchcne",
                table: "trx_consignee");

            migrationBuilder.DropColumn(
                name: "statecode",
                table: "trx_consignee");

            migrationBuilder.DropColumn(
                name: "statecode",
                table: "trx_cneedirectory");

            migrationBuilder.AddColumn<string>(
                name: "countrycode",
                table: "trx_shipper",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "branchid",
                table: "trx_consignee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "countrycode",
                table: "trx_consignee",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "countrycode",
                table: "trx_cneedirectory",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "couriername",
                table: "pum_pickuprequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "isautodispatch",
                table: "pum_pickupregular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isvat",
                table: "mdt_account",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "mgmtfee",
                table: "mdt_account",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ppn",
                table: "mdt_account",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "stampcosttype",
                table: "mdt_account",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vattype",
                table: "mdt_account",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mdt_bank",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bankname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    bankcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    swiftcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_bank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mdt_ncsbankaccount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bankcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    bankname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    accountno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    accountname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_ncsbankaccount", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdt_bank");

            migrationBuilder.DropTable(
                name: "mdt_ncsbankaccount");

            migrationBuilder.DropColumn(
                name: "countrycode",
                table: "trx_shipper");

            migrationBuilder.DropColumn(
                name: "countrycode",
                table: "trx_consignee");

            migrationBuilder.DropColumn(
                name: "countrycode",
                table: "trx_cneedirectory");

            migrationBuilder.DropColumn(
                name: "isautodispatch",
                table: "pum_pickupregular");

            migrationBuilder.DropColumn(
                name: "isvat",
                table: "mdt_account");

            migrationBuilder.DropColumn(
                name: "mgmtfee",
                table: "mdt_account");

            migrationBuilder.DropColumn(
                name: "ppn",
                table: "mdt_account");

            migrationBuilder.DropColumn(
                name: "stampcosttype",
                table: "mdt_account");

            migrationBuilder.DropColumn(
                name: "vattype",
                table: "mdt_account");

            migrationBuilder.AddColumn<int>(
                name: "branchori",
                table: "trx_shipper",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "statecode",
                table: "trx_shipper",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "branchid",
                table: "trx_consignee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "branchcne",
                table: "trx_consignee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statecode",
                table: "trx_consignee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "statecode",
                table: "trx_cneedirectory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "couriername",
                table: "pum_pickuprequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
