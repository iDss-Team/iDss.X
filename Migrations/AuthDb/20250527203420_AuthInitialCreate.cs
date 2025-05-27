using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDss.X.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AuthInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "idm_role",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idm_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "idm_user",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    grouptype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passexpireddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    passexpired = table.Column<bool>(type: "bit", nullable: false),
                    loginattempt = table.Column<int>(type: "int", nullable: false),
                    securitycode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "bit", nullable: false),
                    passwordhash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    securitystamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concurrencystamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "bit", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "bit", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "bit", nullable: false),
                    accessfailedcount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idm_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "idm_roleclaim",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claimtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claimvalue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idm_roleclaim", x => x.id);
                    table.ForeignKey(
                        name: "FK_idm_roleclaim_idm_role_roleid",
                        column: x => x.roleid,
                        principalTable: "idm_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "idm_userclaim",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claimtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claimvalue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idm_userclaim", x => x.id);
                    table.ForeignKey(
                        name: "FK_idm_userclaim_idm_user_userid",
                        column: x => x.userid,
                        principalTable: "idm_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "idm_userlogin",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    providerkey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    providerdisplayname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idm_userlogin", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "FK_idm_userlogin_idm_user_userid",
                        column: x => x.userid,
                        principalTable: "idm_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "idm_userrole",
                columns: table => new
                {
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    roleid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idm_userrole", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "FK_idm_userrole_idm_role_roleid",
                        column: x => x.roleid,
                        principalTable: "idm_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_idm_userrole_idm_user_userid",
                        column: x => x.userid,
                        principalTable: "idm_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "idm_usertoken",
                columns: table => new
                {
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    loginprovider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idm_usertoken", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "FK_idm_usertoken_idm_user_userid",
                        column: x => x.userid,
                        principalTable: "idm_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "idm_role",
                column: "normalizedname",
                unique: true,
                filter: "[normalizedname] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_idm_roleclaim_roleid",
                table: "idm_roleclaim",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "idm_user",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "idm_user",
                column: "normalizedusername",
                unique: true,
                filter: "[normalizedusername] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_idm_userclaim_userid",
                table: "idm_userclaim",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_idm_userlogin_userid",
                table: "idm_userlogin",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_idm_userrole_roleid",
                table: "idm_userrole",
                column: "roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "idm_roleclaim");

            migrationBuilder.DropTable(
                name: "idm_userclaim");

            migrationBuilder.DropTable(
                name: "idm_userlogin");

            migrationBuilder.DropTable(
                name: "idm_userrole");

            migrationBuilder.DropTable(
                name: "idm_usertoken");

            migrationBuilder.DropTable(
                name: "idm_role");

            migrationBuilder.DropTable(
                name: "idm_user");
        }
    }
}
