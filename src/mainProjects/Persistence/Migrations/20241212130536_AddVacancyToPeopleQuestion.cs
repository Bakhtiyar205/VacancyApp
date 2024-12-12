using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVacancyToPeopleQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "PeopleQuestions",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_PeopleQuestions_VacancyId",
                table: "PeopleQuestions",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleQuestions_Vacancies_VacancyId",
                table: "PeopleQuestions",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleQuestions_Vacancies_VacancyId",
                table: "PeopleQuestions");

            migrationBuilder.DropIndex(
                name: "IX_PeopleQuestions_VacancyId",
                table: "PeopleQuestions");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "PeopleQuestions");
        }
    }
}
