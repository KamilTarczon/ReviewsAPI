using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsAPI.Migrations
{
    /// <inheritdoc />
    public partial class seventhmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_Reviewerid",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Reviewerid",
                table: "Reviews",
                newName: "ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_Reviewerid",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Reviews",
                newName: "Reviewerid");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                newName: "IX_Reviews_Reviewerid");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_Reviewerid",
                table: "Reviews",
                column: "Reviewerid",
                principalTable: "Reviewers",
                principalColumn: "id");
        }
    }
}
