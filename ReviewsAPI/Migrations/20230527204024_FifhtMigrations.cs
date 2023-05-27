using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsAPI.Migrations
{
    /// <inheritdoc />
    public partial class FifhtMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "Reviewers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Reviewers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Reviewers");
        }
    }
}
