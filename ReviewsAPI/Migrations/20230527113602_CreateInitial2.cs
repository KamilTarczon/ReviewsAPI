using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Drinks_Drinkid",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_Reviewerid",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Reviewers",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Reviewers",
                newName: "Firstname");

            migrationBuilder.AlterColumn<int>(
                name: "Reviewerid",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Drinkid",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Drinks_Drinkid",
                table: "Reviews",
                column: "Drinkid",
                principalTable: "Drinks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_Reviewerid",
                table: "Reviews",
                column: "Reviewerid",
                principalTable: "Reviewers",
                principalColumn: "id");
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

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Reviewers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Reviewers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<int>(
                name: "Reviewerid",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Drinkid",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
