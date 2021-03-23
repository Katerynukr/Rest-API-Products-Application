using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPIApplication.Migrations
{
    public partial class shop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Vegetables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "MeatProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Fruits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "DieryProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vegetables_ShopId",
                table: "Vegetables",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_MeatProducts_ShopId",
                table: "MeatProducts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_ShopId",
                table: "Fruits",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_DieryProducts_ShopId",
                table: "DieryProducts",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_DieryProducts_Shops_ShopId",
                table: "DieryProducts",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fruits_Shops_ShopId",
                table: "Fruits",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeatProducts_Shops_ShopId",
                table: "MeatProducts",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vegetables_Shops_ShopId",
                table: "Vegetables",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieryProducts_Shops_ShopId",
                table: "DieryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Fruits_Shops_ShopId",
                table: "Fruits");

            migrationBuilder.DropForeignKey(
                name: "FK_MeatProducts_Shops_ShopId",
                table: "MeatProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vegetables_Shops_ShopId",
                table: "Vegetables");

            migrationBuilder.DropIndex(
                name: "IX_Vegetables_ShopId",
                table: "Vegetables");

            migrationBuilder.DropIndex(
                name: "IX_MeatProducts_ShopId",
                table: "MeatProducts");

            migrationBuilder.DropIndex(
                name: "IX_Fruits_ShopId",
                table: "Fruits");

            migrationBuilder.DropIndex(
                name: "IX_DieryProducts_ShopId",
                table: "DieryProducts");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "MeatProducts");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "DieryProducts");
        }
    }
}
