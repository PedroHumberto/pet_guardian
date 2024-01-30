using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGuadian.API.Migrations
{
    /// <inheritdoc />
    public partial class PetExams_correctName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.CreateTable(
                name: "PetExams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    petId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamName = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetExams_Pets_petId",
                        column: x => x.petId,
                        principalTable: "Pets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetExams_petId",
                table: "PetExams",
                column: "petId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetExams");

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    petId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamName = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Pets_petId",
                        column: x => x.petId,
                        principalTable: "Pets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_petId",
                table: "Exams",
                column: "petId");
        }
    }
}
