using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class FixSubjectCurriculum2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumBooks_SubjectCurriculums_IdBook",
                table: "SubjectCurriculumBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumBooks_Books_IdSubjectCurriculum",
                table: "SubjectCurriculumBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumCompetences_SubjectCurriculums_IdCompetence",
                table: "SubjectCurriculumCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumCompetences_Competences_IdSubjectCurriculum",
                table: "SubjectCurriculumCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumGoals_SubjectCurriculums_IdGoal",
                table: "SubjectCurriculumGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumGoals_Goals_IdSubjectCurriculum",
                table: "SubjectCurriculumGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumNDEMembers_SubjectCurriculums_IdNDEMember",
                table: "SubjectCurriculumNDEMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumNDEMembers_NDEMembers_IdSubjectCurriculum",
                table: "SubjectCurriculumNDEMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumSkills_SubjectCurriculums_IdSkill",
                table: "SubjectCurriculumSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumSkills_Skills_IdSubjectCurriculum",
                table: "SubjectCurriculumSkills");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumBooks_Books_IdBook",
                table: "SubjectCurriculumBooks",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumBooks_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumBooks",
                column: "IdSubjectCurriculum",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumCompetences_Competences_IdCompetence",
                table: "SubjectCurriculumCompetences",
                column: "IdCompetence",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumCompetences_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumCompetences",
                column: "IdSubjectCurriculum",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumGoals_Goals_IdGoal",
                table: "SubjectCurriculumGoals",
                column: "IdGoal",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumGoals_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumGoals",
                column: "IdSubjectCurriculum",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumNDEMembers_NDEMembers_IdNDEMember",
                table: "SubjectCurriculumNDEMembers",
                column: "IdNDEMember",
                principalTable: "NDEMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumNDEMembers_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumNDEMembers",
                column: "IdSubjectCurriculum",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumSkills_Skills_IdSkill",
                table: "SubjectCurriculumSkills",
                column: "IdSkill",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumSkills_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumSkills",
                column: "IdSubjectCurriculum",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumBooks_Books_IdBook",
                table: "SubjectCurriculumBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumBooks_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumCompetences_Competences_IdCompetence",
                table: "SubjectCurriculumCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumCompetences_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumGoals_Goals_IdGoal",
                table: "SubjectCurriculumGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumGoals_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumNDEMembers_NDEMembers_IdNDEMember",
                table: "SubjectCurriculumNDEMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumNDEMembers_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumNDEMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumSkills_Skills_IdSkill",
                table: "SubjectCurriculumSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumSkills_SubjectCurriculums_IdSubjectCurriculum",
                table: "SubjectCurriculumSkills");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumBooks_SubjectCurriculums_IdBook",
                table: "SubjectCurriculumBooks",
                column: "IdBook",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumBooks_Books_IdSubjectCurriculum",
                table: "SubjectCurriculumBooks",
                column: "IdSubjectCurriculum",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumCompetences_SubjectCurriculums_IdCompetence",
                table: "SubjectCurriculumCompetences",
                column: "IdCompetence",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumCompetences_Competences_IdSubjectCurriculum",
                table: "SubjectCurriculumCompetences",
                column: "IdSubjectCurriculum",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumGoals_SubjectCurriculums_IdGoal",
                table: "SubjectCurriculumGoals",
                column: "IdGoal",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumGoals_Goals_IdSubjectCurriculum",
                table: "SubjectCurriculumGoals",
                column: "IdSubjectCurriculum",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumNDEMembers_SubjectCurriculums_IdNDEMember",
                table: "SubjectCurriculumNDEMembers",
                column: "IdNDEMember",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumNDEMembers_NDEMembers_IdSubjectCurriculum",
                table: "SubjectCurriculumNDEMembers",
                column: "IdSubjectCurriculum",
                principalTable: "NDEMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumSkills_SubjectCurriculums_IdSkill",
                table: "SubjectCurriculumSkills",
                column: "IdSkill",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumSkills_Skills_IdSubjectCurriculum",
                table: "SubjectCurriculumSkills",
                column: "IdSubjectCurriculum",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
