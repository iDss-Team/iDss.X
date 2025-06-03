using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AppendMasterDataToDB250603 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mdt_packingsize",
                columns: table => new
                {
                    sizecode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    sizename = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_packingsize", x => x.sizecode);
                });

            migrationBuilder.CreateTable(
                name: "mdt_packingprice",
                columns: table => new
                {
                    packingcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    sizecode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_packingprice", x => new { x.packingcode, x.sizecode });
                    table.ForeignKey(
                        name: "FK_mdt_packingprice_mdt_packingsize_sizecode",
                        column: x => x.sizecode,
                        principalTable: "mdt_packingsize",
                        principalColumn: "sizecode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mdt_packingprice_mdt_packingtype_packingcode",
                        column: x => x.packingcode,
                        principalTable: "mdt_packingtype",
                        principalColumn: "packingcode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "mdt_packingsize",
                columns: new[] { "sizecode", "createdby", "createddate", "flag", "remarks", "sizename" },
                values: new object[,]
                {
                    { "l", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Large" },
                    { "m", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Medium" },
                    { "X", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Small" }
                });

            migrationBuilder.InsertData(
                table: "mdt_packingtype",
                columns: new[] { "packingcode", "createdby", "createddate", "flag", "modifieddate", "modifier", "packingname", "remarks" },
                values: new object[,]
                {
                    { "101", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Bubble Wrap", "" },
                    { "102", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Kardus (Box)", "" },
                    { "103", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Kayu", "" },
                    { "104", "System", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Styrofoam", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_mdt_packingprice_sizecode",
                table: "mdt_packingprice",
                column: "sizecode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdt_packingprice");

            migrationBuilder.DropTable(
                name: "mdt_packingsize");

            migrationBuilder.DeleteData(
                table: "mdt_packingtype",
                keyColumn: "packingcode",
                keyValue: "101");

            migrationBuilder.DeleteData(
                table: "mdt_packingtype",
                keyColumn: "packingcode",
                keyValue: "102");

            migrationBuilder.DeleteData(
                table: "mdt_packingtype",
                keyColumn: "packingcode",
                keyValue: "103");

            migrationBuilder.DeleteData(
                table: "mdt_packingtype",
                keyColumn: "packingcode",
                keyValue: "104");
        }
    }
}
