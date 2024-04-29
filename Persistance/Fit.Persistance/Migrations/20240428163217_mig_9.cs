using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fit.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BasketCalorie_BasketCalorieId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BasketCalorieId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BasketCalorie",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketCalorie_UserId",
                table: "BasketCalorie",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCalorie_AspNetUsers_UserId",
                table: "BasketCalorie",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCalorie_AspNetUsers_UserId",
                table: "BasketCalorie");

            migrationBuilder.DropIndex(
                name: "IX_BasketCalorie_UserId",
                table: "BasketCalorie");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BasketCalorie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
        }
    }
}
