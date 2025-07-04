using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddReasonTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pum_cancelpickup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pickupstatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    reasonid = table.Column<int>(type: "int", nullable: false),
                    reasonname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    requestor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    attachment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_cancelpickup", x => x.id);
                    table.ForeignKey(
                        name: "FK_pum_cancelpickup_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pum_reassignpickup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pickupstatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    reasonid = table.Column<int>(type: "int", nullable: false),
                    reasonname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    prevcourier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_reassignpickup", x => x.id);
                    table.ForeignKey(
                        name: "FK_pum_reassignpickup_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pum_reschedulepickup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pickupstatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    reasonid = table.Column<int>(type: "int", nullable: false),
                    reasonname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    requestor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_reschedulepickup", x => x.id);
                    table.ForeignKey(
                        name: "FK_pum_reschedulepickup_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pum_successpickup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pickupstatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    attach1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    attach2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cashreceived = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_successpickup", x => x.id);
                    table.ForeignKey(
                        name: "FK_pum_successpickup_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pum_unsuccesspickup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pickupno = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pickupstatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    reasonid = table.Column<int>(type: "int", nullable: false),
                    reasonname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pum_unsuccesspickup", x => x.id);
                    table.ForeignKey(
                        name: "FK_pum_unsuccesspickup_pum_pickuprequest_pickupno",
                        column: x => x.pickupno,
                        principalTable: "pum_pickuprequest",
                        principalColumn: "pickupno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pum_cancelpickup_pickupno",
                table: "pum_cancelpickup",
                column: "pickupno");

            migrationBuilder.CreateIndex(
                name: "IX_pum_reassignpickup_pickupno",
                table: "pum_reassignpickup",
                column: "pickupno");

            migrationBuilder.CreateIndex(
                name: "IX_pum_reschedulepickup_pickupno",
                table: "pum_reschedulepickup",
                column: "pickupno");

            migrationBuilder.CreateIndex(
                name: "IX_pum_successpickup_pickupno",
                table: "pum_successpickup",
                column: "pickupno");

            migrationBuilder.CreateIndex(
                name: "IX_pum_unsuccesspickup_pickupno",
                table: "pum_unsuccesspickup",
                column: "pickupno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pum_cancelpickup");

            migrationBuilder.DropTable(
                name: "pum_reassignpickup");

            migrationBuilder.DropTable(
                name: "pum_reschedulepickup");

            migrationBuilder.DropTable(
                name: "pum_successpickup");

            migrationBuilder.DropTable(
                name: "pum_unsuccesspickup");
        }
    }
}
