using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class FixSubjectCurriculum3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Courses_CourseId",
                table: "SubjectCurriculums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Users_ProfessorId",
                table: "SubjectCurriculums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Subjects_SubjectId",
                table: "SubjectCurriculums");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculums_CourseId",
                table: "SubjectCurriculums");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculums_ProfessorId",
                table: "SubjectCurriculums");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculums_SubjectId",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectCurriculums");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculums_IdCourse",
                table: "SubjectCurriculums",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculums_IdProfessor",
                table: "SubjectCurriculums",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculums_IdSubject",
                table: "SubjectCurriculums",
                column: "IdSubject");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculums_Courses_IdCourse",
                table: "SubjectCurriculums",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculums_Users_IdProfessor",
                table: "SubjectCurriculums",
                column: "IdProfessor",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculums_Subjects_IdSubject",
                table: "SubjectCurriculums",
                column: "IdSubject",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Courses_IdCourse",
                table: "SubjectCurriculums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Users_IdProfessor",
                table: "SubjectCurriculums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Subjects_IdSubject",
                table: "SubjectCurriculums");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculums_IdCourse",
                table: "SubjectCurriculums");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculums_IdProfessor",
                table: "SubjectCurriculums");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculums_IdSubject",
                table: "SubjectCurriculums");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculums_CourseId",
                table: "SubjectCurriculums",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculums_ProfessorId",
                table: "SubjectCurriculums",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculums_SubjectId",
                table: "SubjectCurriculums",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculums_Courses_CourseId",
                table: "SubjectCurriculums",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculums_Users_ProfessorId",
                table: "SubjectCurriculums",
                column: "ProfessorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculums_Subjects_SubjectId",
                table: "SubjectCurriculums",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
