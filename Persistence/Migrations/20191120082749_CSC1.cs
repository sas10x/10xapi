using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CSC1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VarDiameters",
                columns: table => new
                {
                    VarDiameterId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Sunod = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarDiameters", x => x.VarDiameterId);
                });

            migrationBuilder.CreateTable(
                name: "VarGrades",
                columns: table => new
                {
                    VarGradeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarGrades", x => x.VarGradeId);
                });

            migrationBuilder.CreateTable(
                name: "VarLengths",
                columns: table => new
                {
                    VarLengthId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Sunod = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarLengths", x => x.VarLengthId);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Pursinto = table.Column<decimal>(nullable: false),
                    VarGradeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                    table.ForeignKey(
                        name: "FK_Discounts_VarGrades_VarGradeId",
                        column: x => x.VarGradeId,
                        principalTable: "VarGrades",
                        principalColumn: "VarGradeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BasePrice = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    DiscountId = table.Column<long>(nullable: true),
                    VarGradeId = table.Column<long>(nullable: true),
                    VarDiameterId = table.Column<long>(nullable: true),
                    VarLengthId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_VarDiameters_VarDiameterId",
                        column: x => x.VarDiameterId,
                        principalTable: "VarDiameters",
                        principalColumn: "VarDiameterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_VarGrades_VarGradeId",
                        column: x => x.VarGradeId,
                        principalTable: "VarGrades",
                        principalColumn: "VarGradeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_VarLengths_VarLengthId",
                        column: x => x.VarLengthId,
                        principalTable: "VarLengths",
                        principalColumn: "VarLengthId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_VarGradeId",
                table: "Discounts",
                column: "VarGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountId",
                table: "Products",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VarDiameterId",
                table: "Products",
                column: "VarDiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VarGradeId",
                table: "Products",
                column: "VarGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VarLengthId",
                table: "Products",
                column: "VarLengthId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "VarDiameters");

            migrationBuilder.DropTable(
                name: "VarLengths");

            migrationBuilder.DropTable(
                name: "VarGrades");
        }
    }
}
