using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace bobo.orm.efcore.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Author = table.Column<string>(type: "longtext", nullable: true),
                    Click = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    DiggBad = table.Column<int>(type: "int", nullable: false),
                    DiggGood = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<string>(type: "longtext", nullable: true),
                    ImgUrl = table.Column<string>(type: "longtext", nullable: true),
                    InputAuthor = table.Column<string>(type: "longtext", nullable: true),
                    IsAddRSS = table.Column<bool>(type: "bit", nullable: false),
                    IsBig = table.Column<bool>(type: "bit", nullable: false),
                    IsHot = table.Column<bool>(type: "bit", nullable: false),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    IsMsg = table.Column<bool>(type: "bit", nullable: false),
                    IsRed = table.Column<bool>(type: "bit", nullable: false),
                    IsShow = table.Column<bool>(type: "bit", nullable: false),
                    IsSlide = table.Column<bool>(type: "bit", nullable: false),
                    IsTop = table.Column<bool>(type: "bit", nullable: false),
                    LinkUrl = table.Column<string>(type: "longtext", nullable: true),
                    RealClick = table.Column<int>(type: "int", nullable: false),
                    SeoDescription = table.Column<string>(type: "longtext", nullable: true),
                    SeoKeywords = table.Column<string>(type: "longtext", nullable: true),
                    SeoTitle = table.Column<string>(type: "longtext", nullable: true),
                    ShareCount = table.Column<int>(type: "int", nullable: false),
                    SortId = table.Column<int>(type: "int", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Title1 = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BackGround = table.Column<string>(type: "longtext", nullable: true),
                    CallIndex = table.Column<string>(type: "longtext", nullable: true),
                    CategoryTypeId = table.Column<int>(type: "int", nullable: true),
                    ClickCount = table.Column<string>(type: "longtext", nullable: true),
                    Content = table.Column<string>(type: "longtext", nullable: true),
                    GuanZhuCount = table.Column<int>(type: "int", nullable: false),
                    HeadChar = table.Column<string>(type: "longtext", nullable: true),
                    ImgUrl = table.Column<string>(type: "longtext", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsGuoYuan = table.Column<bool>(type: "bit", nullable: false),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    LinkUrl = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PlatformLoginText = table.Column<string>(type: "longtext", nullable: true),
                    PlatformLoginUrl = table.Column<string>(type: "longtext", nullable: true),
                    PlatformSetUpShopText = table.Column<string>(type: "longtext", nullable: true),
                    PlatformSetUpShopUrl = table.Column<string>(type: "longtext", nullable: true),
                    RealGuanZhuCount = table.Column<int>(type: "int", nullable: false),
                    SeoDescription = table.Column<string>(type: "longtext", nullable: true),
                    SeoKeywords = table.Column<string>(type: "longtext", nullable: true),
                    SeoTitle = table.Column<string>(type: "longtext", nullable: true),
                    SortId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_ArticleId",
                table: "ArticleCategory",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_CategoryId",
                table: "ArticleCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
