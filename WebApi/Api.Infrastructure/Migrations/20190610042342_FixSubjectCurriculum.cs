using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class FixSubjectCurriculum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumBook_Books_BookId",
                table: "SubjectCurriculumBook");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumBook_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumBook");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumCompetence_Competences_CompetenceId",
                table: "SubjectCurriculumCompetence");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumCompetence_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumCompetence");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumGoal_Goals_GoalId",
                table: "SubjectCurriculumGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumGoal_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumNDEMember_NDEMembers_NDEMemberId",
                table: "SubjectCurriculumNDEMember");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumNDEMember_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumNDEMember");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumSkill_Skills_SkillId",
                table: "SubjectCurriculumSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculumSkill_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumSkill",
                table: "SubjectCurriculumSkill");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumSkill_SkillId",
                table: "SubjectCurriculumSkill");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumSkill_SubjectCurriculumId",
                table: "SubjectCurriculumSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumNDEMember",
                table: "SubjectCurriculumNDEMember");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumNDEMember_NDEMemberId",
                table: "SubjectCurriculumNDEMember");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumNDEMember_SubjectCurriculumId",
                table: "SubjectCurriculumNDEMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumGoal",
                table: "SubjectCurriculumGoal");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumGoal_GoalId",
                table: "SubjectCurriculumGoal");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumGoal_SubjectCurriculumId",
                table: "SubjectCurriculumGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumCompetence",
                table: "SubjectCurriculumCompetence");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumCompetence_CompetenceId",
                table: "SubjectCurriculumCompetence");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumCompetence_SubjectCurriculumId",
                table: "SubjectCurriculumCompetence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumBook",
                table: "SubjectCurriculumBook");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumBook_BookId",
                table: "SubjectCurriculumBook");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumBook_SubjectCurriculumId",
                table: "SubjectCurriculumBook");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "SubjectCurriculumSkill");

            migrationBuilder.DropColumn(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumSkill");

            migrationBuilder.DropColumn(
                name: "NDEMemberId",
                table: "SubjectCurriculumNDEMember");

            migrationBuilder.DropColumn(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumNDEMember");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "SubjectCurriculumGoal");

            migrationBuilder.DropColumn(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumGoal");

            migrationBuilder.DropColumn(
                name: "CompetenceId",
                table: "SubjectCurriculumCompetence");

            migrationBuilder.DropColumn(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumCompetence");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "SubjectCurriculumBook");

            migrationBuilder.DropColumn(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumBook");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumSkill",
                newName: "SubjectCurriculumSkills");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumNDEMember",
                newName: "SubjectCurriculumNDEMembers");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumGoal",
                newName: "SubjectCurriculumGoals");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumCompetence",
                newName: "SubjectCurriculumCompetences");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumBook",
                newName: "SubjectCurriculumBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumSkills",
                table: "SubjectCurriculumSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumNDEMembers",
                table: "SubjectCurriculumNDEMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumGoals",
                table: "SubjectCurriculumGoals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumCompetences",
                table: "SubjectCurriculumCompetences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumBooks",
                table: "SubjectCurriculumBooks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumSkills_IdSkill",
                table: "SubjectCurriculumSkills",
                column: "IdSkill");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumSkills_IdSubjectCurriculum",
                table: "SubjectCurriculumSkills",
                column: "IdSubjectCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumNDEMembers_IdNDEMember",
                table: "SubjectCurriculumNDEMembers",
                column: "IdNDEMember");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumNDEMembers_IdSubjectCurriculum",
                table: "SubjectCurriculumNDEMembers",
                column: "IdSubjectCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumGoals_IdGoal",
                table: "SubjectCurriculumGoals",
                column: "IdGoal");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumGoals_IdSubjectCurriculum",
                table: "SubjectCurriculumGoals",
                column: "IdSubjectCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumCompetences_IdCompetence",
                table: "SubjectCurriculumCompetences",
                column: "IdCompetence");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumCompetences_IdSubjectCurriculum",
                table: "SubjectCurriculumCompetences",
                column: "IdSubjectCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumBooks_IdBook",
                table: "SubjectCurriculumBooks",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumBooks_IdSubjectCurriculum",
                table: "SubjectCurriculumBooks",
                column: "IdSubjectCurriculum");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumSkills",
                table: "SubjectCurriculumSkills");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumSkills_IdSkill",
                table: "SubjectCurriculumSkills");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumSkills_IdSubjectCurriculum",
                table: "SubjectCurriculumSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumNDEMembers",
                table: "SubjectCurriculumNDEMembers");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumNDEMembers_IdNDEMember",
                table: "SubjectCurriculumNDEMembers");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumNDEMembers_IdSubjectCurriculum",
                table: "SubjectCurriculumNDEMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumGoals",
                table: "SubjectCurriculumGoals");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumGoals_IdGoal",
                table: "SubjectCurriculumGoals");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumGoals_IdSubjectCurriculum",
                table: "SubjectCurriculumGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumCompetences",
                table: "SubjectCurriculumCompetences");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumCompetences_IdCompetence",
                table: "SubjectCurriculumCompetences");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumCompetences_IdSubjectCurriculum",
                table: "SubjectCurriculumCompetences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectCurriculumBooks",
                table: "SubjectCurriculumBooks");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumBooks_IdBook",
                table: "SubjectCurriculumBooks");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculumBooks_IdSubjectCurriculum",
                table: "SubjectCurriculumBooks");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumSkills",
                newName: "SubjectCurriculumSkill");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumNDEMembers",
                newName: "SubjectCurriculumNDEMember");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumGoals",
                newName: "SubjectCurriculumGoal");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumCompetences",
                newName: "SubjectCurriculumCompetence");

            migrationBuilder.RenameTable(
                name: "SubjectCurriculumBooks",
                newName: "SubjectCurriculumBook");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "SubjectCurriculumSkill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumSkill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NDEMemberId",
                table: "SubjectCurriculumNDEMember",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumNDEMember",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "SubjectCurriculumGoal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumGoal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompetenceId",
                table: "SubjectCurriculumCompetence",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumCompetence",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "SubjectCurriculumBook",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectCurriculumId",
                table: "SubjectCurriculumBook",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumSkill",
                table: "SubjectCurriculumSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumNDEMember",
                table: "SubjectCurriculumNDEMember",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumGoal",
                table: "SubjectCurriculumGoal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumCompetence",
                table: "SubjectCurriculumCompetence",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectCurriculumBook",
                table: "SubjectCurriculumBook",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumSkill_SkillId",
                table: "SubjectCurriculumSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumSkill_SubjectCurriculumId",
                table: "SubjectCurriculumSkill",
                column: "SubjectCurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumNDEMember_NDEMemberId",
                table: "SubjectCurriculumNDEMember",
                column: "NDEMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumNDEMember_SubjectCurriculumId",
                table: "SubjectCurriculumNDEMember",
                column: "SubjectCurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumGoal_GoalId",
                table: "SubjectCurriculumGoal",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumGoal_SubjectCurriculumId",
                table: "SubjectCurriculumGoal",
                column: "SubjectCurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumCompetence_CompetenceId",
                table: "SubjectCurriculumCompetence",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumCompetence_SubjectCurriculumId",
                table: "SubjectCurriculumCompetence",
                column: "SubjectCurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumBook_BookId",
                table: "SubjectCurriculumBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumBook_SubjectCurriculumId",
                table: "SubjectCurriculumBook",
                column: "SubjectCurriculumId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumBook_Books_BookId",
                table: "SubjectCurriculumBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumBook_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumBook",
                column: "SubjectCurriculumId",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumCompetence_Competences_CompetenceId",
                table: "SubjectCurriculumCompetence",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumCompetence_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumCompetence",
                column: "SubjectCurriculumId",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumGoal_Goals_GoalId",
                table: "SubjectCurriculumGoal",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumGoal_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumGoal",
                column: "SubjectCurriculumId",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumNDEMember_NDEMembers_NDEMemberId",
                table: "SubjectCurriculumNDEMember",
                column: "NDEMemberId",
                principalTable: "NDEMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumNDEMember_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumNDEMember",
                column: "SubjectCurriculumId",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumSkill_Skills_SkillId",
                table: "SubjectCurriculumSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculumSkill_SubjectCurriculums_SubjectCurriculumId",
                table: "SubjectCurriculumSkill",
                column: "SubjectCurriculumId",
                principalTable: "SubjectCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
