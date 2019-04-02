using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class FixCourseFKS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Courses_IdCourse",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Courses_IdCourse",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Courses_IdCourse",
                table: "Skills");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Courses_IdCourse",
                table: "Competences",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Courses_IdCourse",
                table: "Goals",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Courses_IdCourse",
                table: "Skills",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Courses_IdCourse",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Courses_IdCourse",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Courses_IdCourse",
                table: "Skills");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Courses_IdCourse",
                table: "Competences",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Courses_IdCourse",
                table: "Goals",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Courses_IdCourse",
                table: "Skills",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
