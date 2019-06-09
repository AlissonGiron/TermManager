using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class UpdateSubjectCurriculum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bibliography",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "Competence",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "MembersNDE",
                table: "SubjectCurriculums");

            migrationBuilder.RenameColumn(
                name: "ValuationMethod",
                table: "SubjectCurriculums",
                newName: "ProgramContentM2");

            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "SubjectCurriculums",
                newName: "ProgramContentM1");

            migrationBuilder.RenameColumn(
                name: "ProgramContents",
                table: "SubjectCurriculums",
                newName: "Ementa");

            migrationBuilder.RenameColumn(
                name: "Menu",
                table: "SubjectCurriculums",
                newName: "Avaliacao");

            migrationBuilder.AddColumn<int>(
                name: "CoordinatorId",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAvaliacao",
                table: "SubjectCurriculums",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateValidacaoNDE",
                table: "SubjectCurriculums",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdCoordinator",
                table: "SubjectCurriculums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCourse",
                table: "SubjectCurriculums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProfessor",
                table: "SubjectCurriculums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSubject",
                table: "SubjectCurriculums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubjectCurriculumBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdSubjectCurriculum = table.Column<int>(nullable: false),
                    SubjectCurriculumId = table.Column<int>(nullable: true),
                    IdBook = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCurriculumBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumBook_SubjectCurriculums_SubjectCurriculumId",
                        column: x => x.SubjectCurriculumId,
                        principalTable: "SubjectCurriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCurriculumCompetence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdSubjectCurriculum = table.Column<int>(nullable: false),
                    SubjectCurriculumId = table.Column<int>(nullable: true),
                    IdCompetence = table.Column<int>(nullable: false),
                    CompetenceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCurriculumCompetence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumCompetence_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumCompetence_SubjectCurriculums_SubjectCurriculumId",
                        column: x => x.SubjectCurriculumId,
                        principalTable: "SubjectCurriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCurriculumGoal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdSubjectCurriculum = table.Column<int>(nullable: false),
                    SubjectCurriculumId = table.Column<int>(nullable: true),
                    IdGoal = table.Column<int>(nullable: false),
                    GoalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCurriculumGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumGoal_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumGoal_SubjectCurriculums_SubjectCurriculumId",
                        column: x => x.SubjectCurriculumId,
                        principalTable: "SubjectCurriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCurriculumNDEMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdSubjectCurriculum = table.Column<int>(nullable: false),
                    SubjectCurriculumId = table.Column<int>(nullable: true),
                    IdNDEMember = table.Column<int>(nullable: false),
                    NDEMemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCurriculumNDEMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumNDEMember_NDEMembers_NDEMemberId",
                        column: x => x.NDEMemberId,
                        principalTable: "NDEMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumNDEMember_SubjectCurriculums_SubjectCurriculumId",
                        column: x => x.SubjectCurriculumId,
                        principalTable: "SubjectCurriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCurriculumSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdSubjectCurriculum = table.Column<int>(nullable: false),
                    SubjectCurriculumId = table.Column<int>(nullable: true),
                    IdSkill = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCurriculumSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCurriculumSkill_SubjectCurriculums_SubjectCurriculumId",
                        column: x => x.SubjectCurriculumId,
                        principalTable: "SubjectCurriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculums_CoordinatorId",
                table: "SubjectCurriculums",
                column: "CoordinatorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumBook_BookId",
                table: "SubjectCurriculumBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumBook_SubjectCurriculumId",
                table: "SubjectCurriculumBook",
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
                name: "IX_SubjectCurriculumGoal_GoalId",
                table: "SubjectCurriculumGoal",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumGoal_SubjectCurriculumId",
                table: "SubjectCurriculumGoal",
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
                name: "IX_SubjectCurriculumSkill_SkillId",
                table: "SubjectCurriculumSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCurriculumSkill_SubjectCurriculumId",
                table: "SubjectCurriculumSkill",
                column: "SubjectCurriculumId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectCurriculums_Users_CoordinatorId",
                table: "SubjectCurriculums",
                column: "CoordinatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Users_CoordinatorId",
                table: "SubjectCurriculums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Courses_CourseId",
                table: "SubjectCurriculums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Users_ProfessorId",
                table: "SubjectCurriculums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectCurriculums_Subjects_SubjectId",
                table: "SubjectCurriculums");

            migrationBuilder.DropTable(
                name: "SubjectCurriculumBook");

            migrationBuilder.DropTable(
                name: "SubjectCurriculumCompetence");

            migrationBuilder.DropTable(
                name: "SubjectCurriculumGoal");

            migrationBuilder.DropTable(
                name: "SubjectCurriculumNDEMember");

            migrationBuilder.DropTable(
                name: "SubjectCurriculumSkill");

            migrationBuilder.DropIndex(
                name: "IX_SubjectCurriculums_CoordinatorId",
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
                name: "CoordinatorId",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "DateAvaliacao",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "DateValidacaoNDE",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "IdCoordinator",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "IdCourse",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "IdProfessor",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "IdSubject",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectCurriculums");

            migrationBuilder.RenameColumn(
                name: "ProgramContentM2",
                table: "SubjectCurriculums",
                newName: "ValuationMethod");

            migrationBuilder.RenameColumn(
                name: "ProgramContentM1",
                table: "SubjectCurriculums",
                newName: "Skill");

            migrationBuilder.RenameColumn(
                name: "Ementa",
                table: "SubjectCurriculums",
                newName: "ProgramContents");

            migrationBuilder.RenameColumn(
                name: "Avaliacao",
                table: "SubjectCurriculums",
                newName: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "Bibliography",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Competence",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MembersNDE",
                table: "SubjectCurriculums",
                nullable: true);
        }
    }
}
