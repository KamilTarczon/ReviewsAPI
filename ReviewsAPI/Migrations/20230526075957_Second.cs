using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Drinkid",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reviewerid",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Drinkid",
                table: "Reviews",
                column: "Drinkid");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Reviewerid",
                table: "Reviews",
                column: "Reviewerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Drinks_Drinkid",
                table: "Reviews",
                column: "Drinkid",
                principalTable: "Drinks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_Reviewerid",
                table: "Reviews",
                column: "Reviewerid",
                principalTable: "Reviewers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Drinks_Drinkid",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_Reviewerid",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_Drinkid",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_Reviewerid",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Drinkid",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Reviewerid",
                table: "Reviews");
        }
    }
}
