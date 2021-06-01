using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPIApplication.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    ShopId1 = table.Column<int>(type: "int", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Shops_ShopId1",
                        column: x => x.ShopId1,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoughtProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoughtProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoughtProducts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DairyProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DairyProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DairyProducts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fruits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fruits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fruits_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeatProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeatProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeatProducts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vegetables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vegetables_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoughtProducts_ShopId",
                table: "BoughtProducts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_DairyProducts_ShopId",
                table: "DairyProducts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_ShopId",
                table: "Fruits",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_MeatProducts_ShopId",
                table: "MeatProducts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ShopId1",
                table: "Shops",
                column: "ShopId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vegetables_ShopId",
                table: "Vegetables",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoughtProducts");

            migrationBuilder.DropTable(
                name: "DairyProducts");

            migrationBuilder.DropTable(
                name: "Fruits");

            migrationBuilder.DropTable(
                name: "MeatProducts");

            migrationBuilder.DropTable(
                name: "Vegetables");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
