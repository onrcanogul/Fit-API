using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fit.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BasketCalorie_BasketCalorieId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Nutrients_NutrientId",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BasketCalorieId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "NutrientId",
                table: "BasketItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<float>(
                name: "Measure",
                table: "BasketItem",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BasketCalorie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "BasketCalorieId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BasketCalorieId",
                table: "AspNetUsers",
                column: "BasketCalorieId",
                unique: true,
                filter: "[BasketCalorieId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BasketCalorie_BasketCalorieId",
                table: "AspNetUsers",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BasketCalorie_BasketCalorieId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Nutrients_NutrientId",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BasketCalorieId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "NutrientId",
                table: "BasketItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Measure",
                table: "BasketItem",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BasketCalorie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BasketCalorieId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BasketCalorieId",
                table: "AspNetUsers",
                column: "BasketCalorieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BasketCalorie_BasketCalorieId",
                table: "AspNetUsers",
                column: "BasketCalorieId",
                principalTable: "BasketCalorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Nutrients_NutrientId",
                table: "BasketItem",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
