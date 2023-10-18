using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGuadian.API.Migrations
{
    /// <inheritdoc />
    public partial class PetWeightPropertyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Weight",
                table: "Pets",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Pets");
        }
    }
}
