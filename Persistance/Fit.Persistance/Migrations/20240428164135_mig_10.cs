using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fit.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCalorie_AspNetUsers_UserId",
                table: "BasketCalorie");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketCalorie_Nutrients_NutrientId",
                table: "BasketCalorie");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_BasketCalorie_BasketCalorieId",
                table: "BasketItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Nutrients_NutrientId",
                table: "BasketItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketCalorie",
                table: "BasketCalorie");

            migrationBuilder.RenameTable(
                name: "BasketItem",
                newName: "BasketItems");

            migrationBuilder.RenameTable(
                name: "BasketCalorie",
                newName: "BasketCalories");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_NutrientId",
                table: "BasketItems",
                newName: "IX_BasketItems_NutrientId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_BasketCalorieId",
                table: "BasketItems",
                newName: "IX_BasketItems_BasketCalorieId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCalorie_UserId",
                table: "BasketCalories",
                newName: "IX_BasketCalories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCalorie_NutrientId",
                table: "BasketCalories",
                newName: "IX_BasketCalories_NutrientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketCalories",
                table: "BasketCalories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCalories_AspNetUsers_UserId",
                table: "BasketCalories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCalories_Nutrients_NutrientId",
                table: "BasketCalories",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_BasketCalories_BasketCalorieId",
                table: "BasketItems",
                column: "BasketCalorieId",
                principalTable: "BasketCalories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Nutrients_NutrientId",
                table: "BasketItems",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCalories_AspNetUsers_UserId",
                table: "BasketCalories");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketCalories_Nutrients_NutrientId",
                table: "BasketCalories");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_BasketCalories_BasketCalorieId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Nutrients_NutrientId",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketCalories",
                table: "BasketCalories");

            migrationBuilder.RenameTable(
                name: "BasketItems",
                newName: "BasketItem");

            migrationBuilder.RenameTable(
                name: "BasketCalories",
                newName: "BasketCalorie");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_NutrientId",
                table: "BasketItem",
                newName: "IX_BasketItem_NutrientId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_BasketCalorieId",
                table: "BasketItem",
                newName: "IX_BasketItem_BasketCalorieId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCalories_UserId",
                table: "BasketCalorie",
                newName: "IX_BasketCalorie_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCalories_NutrientId",
                table: "BasketCalorie",
                newName: "IX_BasketCalorie_NutrientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketCalorie",
                table: "BasketCalorie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCalorie_AspNetUsers_UserId",
                table: "BasketCalorie",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCalorie_Nutrients_NutrientId",
                table: "BasketCalorie",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_BasketCalorie_BasketCalorieId",
                table: "BasketItem",
                column: "BasketCalorieId",
                principalTable: "BasketCalorie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Nutrients_NutrientId",
                table: "BasketItem",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id");
        }
    }
}
