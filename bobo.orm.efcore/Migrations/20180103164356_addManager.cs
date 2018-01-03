using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace bobo.orm.efcore.Migrations
{
    public partial class addManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManagerLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActionType = table.Column<string>(nullable: true),
                    LoginIp = table.Column<string>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagerRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    RoleType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagerSysChannel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<int>(nullable: false),
                    LinkUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SortId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    parentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerSysChannel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagerSysChannel_ManagerSysChannel_parentId",
                        column: x => x.parentId,
                        principalTable: "ManagerSysChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<int>(nullable: true),
                    IsLock = table.Column<int>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    RoleType = table.Column<int>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    UserPwd = table.Column<string>(maxLength: 100, nullable: false),
                    roleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_ManagerRole_roleId",
                        column: x => x.roleId,
                        principalTable: "ManagerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagerRoleValue",
                columns: table => new
                {
                    roleId = table.Column<int>(nullable: false),
                    channelId = table.Column<int>(nullable: false),
                    ActionType = table.Column<string>(nullable: true),
                    ChannelName = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    ManagerRoleId = table.Column<int>(nullable: true),
                    SysChannelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerRoleValue", x => new { x.roleId, x.channelId });
                    table.ForeignKey(
                        name: "FK_ManagerRoleValue_ManagerRole_ManagerRoleId",
                        column: x => x.ManagerRoleId,
                        principalTable: "ManagerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagerRoleValue_ManagerSysChannel_SysChannelId",
                        column: x => x.SysChannelId,
                        principalTable: "ManagerSysChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manager_roleId",
                table: "Manager",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerRoleValue_ManagerRoleId",
                table: "ManagerRoleValue",
                column: "ManagerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerRoleValue_SysChannelId",
                table: "ManagerRoleValue",
                column: "SysChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerSysChannel_parentId",
                table: "ManagerSysChannel",
                column: "parentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "ManagerLog");

            migrationBuilder.DropTable(
                name: "ManagerRoleValue");

            migrationBuilder.DropTable(
                name: "ManagerRole");

            migrationBuilder.DropTable(
                name: "ManagerSysChannel");
        }
    }
}
