using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fit.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_BasketCalories_BasketCalorieId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketCalorieId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "BasketCalorieId",
                table: "BasketItems");

            migrationBuilder.CreateTable(
                name: "BasketCalorieBasketItem",
                columns: table => new
                {
                    BasketCaloriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasketItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketCalorieBasketItem", x => new { x.BasketCaloriesId, x.BasketItemsId });
                    table.ForeignKey(
                        name: "FK_BasketCalorieBasketItem_BasketCalories_BasketCaloriesId",
                        column: x => x.BasketCaloriesId,
                        principalTable: "BasketCalories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketCalorieBasketItem_BasketItems_BasketItemsId",
                        column: x => x.BasketItemsId,
                        principalTable: "BasketItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketCalorieBasketItem_BasketItemsId",
                table: "BasketCalorieBasketItem",
                column: "BasketItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketCalorieBasketItem");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketCalorieId",
                table: "BasketItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketCalorieId",
                table: "BasketItems",
                column: "BasketCalorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_BasketCalories_BasketCalorieId",
                table: "BasketItems",
                column: "BasketCalorieId",
                principalTable: "BasketCalories",
                principalColumn: "Id");
        }
    }
}
