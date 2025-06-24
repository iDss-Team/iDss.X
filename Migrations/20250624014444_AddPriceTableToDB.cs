using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mdt_zone",
                columns: table => new
                {
                    zoneid = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    zonename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    zonegroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_zone", x => x.zoneid);
                });

            migrationBuilder.CreateTable(
                name: "mdt_cityzone",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zoneid = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    cityid = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mdt_cityzone", x => x.id);
                    table.ForeignKey(
                        name: "FK_mdt_cityzone_mdt_city_cityid",
                        column: x => x.cityid,
                        principalTable: "mdt_city",
                        principalColumn: "cityid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mdt_cityzone_mdt_zone_zoneid",
                        column: x => x.zoneid,
                        principalTable: "mdt_zone",
                        principalColumn: "zoneid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mdt_cityzone_cityid",
                table: "mdt_cityzone",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_mdt_cityzone_zoneid",
                table: "mdt_cityzone",
                column: "zoneid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdt_cityzone");

            migrationBuilder.DropTable(
                name: "mdt_zone");
        }
    }
}
