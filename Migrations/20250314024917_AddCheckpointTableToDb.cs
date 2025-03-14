using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckpointTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mdt_checkpoint");
        }
    }
}
