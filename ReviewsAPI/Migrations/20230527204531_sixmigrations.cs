using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsAPI.Migrations
{
    /// <inheritdoc />
    public partial class sixmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Drinks_Drinkid",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Drinkid",
                table: "Reviews",
                newName: "DrinkId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_Drinkid",
                table: "Reviews",
                newName: "IX_Reviews_DrinkId");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Drinks_DrinkId",
                table: "Reviews",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Drinks_DrinkId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "DrinkId",
                table: "Reviews",
                newName: "Drinkid");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_DrinkId",
                table: "Reviews",
                newName: "IX_Reviews_Drinkid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Drinks_Drinkid",
                table: "Reviews",
                column: "Drinkid",
                principalTable: "Drinks",
                principalColumn: "id");
        }
    }
}
