using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class AddCourseKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Courses_CourseId",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Courses_CourseId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Courses_CourseId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CourseId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Goals_CourseId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Competences_CourseId",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Competences");

            migrationBuilder.AddColumn<int>(
                name: "IdCourse",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCourse",
                table: "Goals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCourse",
                table: "Competences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IdCourse",
                table: "Skills",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_IdCourse",
                table: "Goals",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_IdCourse",
                table: "Competences",
                column: "IdCourse");

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

            migrationBuilder.DropIndex(
                name: "IX_Skills_IdCourse",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Goals_IdCourse",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Competences_IdCourse",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "IdCourse",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IdCourse",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "IdCourse",
                table: "Competences");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Goals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Competences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CourseId",
                table: "Skills",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_CourseId",
                table: "Goals",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_CourseId",
                table: "Competences",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Courses_CourseId",
                table: "Competences",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Courses_CourseId",
                table: "Goals",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Courses_CourseId",
                table: "Skills",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
