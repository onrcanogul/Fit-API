using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fit.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BasketCalorieId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BasketCalorie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutrientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketCalorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketCalorie_Nutrients_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NutrientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Measure = table.Column<float>(type: "real", nullable: false),
                    BasketCalorieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItem_BasketCalorie_BasketCalorieId",
                        column: x => x.BasketCalorieId,
                        principalTable: "BasketCalorie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BasketItem_Nutrients_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BasketCalorieId",
                table: "AspNetUsers",
                column: "BasketCalorieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketCalorie_NutrientId",
                table: "BasketCalorie",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_BasketCalorieId",
                table: "BasketItem",
                column: "BasketCalorieId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_NutrientId",
                table: "BasketItem",
                column: "NutrientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BasketCalorie_BasketCalorieId",
                table: "AspNetUsers",
                column: "BasketCalorieId",
                principalTable: "BasketCalorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BasketCalorie_BasketCalorieId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BasketItem");

            migrationBuilder.DropTable(
                name: "BasketCalorie");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BasketCalorieId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BasketCalorieId",
                table: "AspNetUsers");
        }
    }
}
