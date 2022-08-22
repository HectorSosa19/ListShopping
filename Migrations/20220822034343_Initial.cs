using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingList.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRoles = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListShop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListShop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListShop_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supermarket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfSupermarket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdListShop = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supermarket_ListShop_IdListShop",
                        column: x => x.IdListShop,
                        principalTable: "ListShop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdListShop = table.Column<int>(type: "int", nullable: false),
                    IdSupermarket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_ListShop_IdListShop",
                        column: x => x.IdListShop,
                        principalTable: "ListShop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brand_Supermarket_IdSupermarket",
                        column: x => x.IdSupermarket,
                        principalTable: "Supermarket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfProducts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSupermarket = table.Column<int>(type: "int", nullable: false),
                    IdListShop = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ListShop_IdListShop",
                        column: x => x.IdListShop,
                        principalTable: "ListShop",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Supermarket_IdSupermarket",
                        column: x => x.IdSupermarket,
                        principalTable: "Supermarket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandProducts",
                columns: table => new
                {
                    BrandsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandProducts", x => new { x.BrandsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_BrandProducts_Brand_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandProducts_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_IdListShop",
                table: "Brand",
                column: "IdListShop");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_IdSupermarket",
                table: "Brand",
                column: "IdSupermarket");

            migrationBuilder.CreateIndex(
                name: "IX_BrandProducts_ProductsId",
                table: "BrandProducts",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ListShop_IdUser",
                table: "ListShop",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdUser",
                table: "Order",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdListShop",
                table: "Product",
                column: "IdListShop");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdSupermarket",
                table: "Product",
                column: "IdSupermarket");

            migrationBuilder.CreateIndex(
                name: "IX_Supermarket_IdListShop",
                table: "Supermarket",
                column: "IdListShop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandProducts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Supermarket");

            migrationBuilder.DropTable(
                name: "ListShop");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
