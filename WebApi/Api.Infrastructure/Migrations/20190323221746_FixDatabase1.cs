using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class FixDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemesterNumber",
                table: "Terms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Terms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTeacherTeachingPlan",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PracticalWorkload",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TheoryWorkload",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<string>(
                name: "Menu",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramContents",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeachingMethod",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuationMethod",
                table: "SubjectCurriculums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Goals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Goals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Competences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Competences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProfessor",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTermCourseSubject",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCourse = table.Column<int>(nullable: false),
                    IdSubject = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCourse = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseUsers_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUsers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TermCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTerm = table.Column<int>(nullable: false),
                    IdCourse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermCourses_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermCourses_Terms_IdTerm",
                        column: x => x.IdTerm,
                        principalTable: "Terms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TermCourseSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTermCourse = table.Column<int>(nullable: false),
                    IdSubject = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermCourseSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermCourseSubjects_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermCourseSubjects_TermCourses_IdTermCourse",
                        column: x => x.IdTermCourse,
                        principalTable: "TermCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_IdTeacherTeachingPlan",
                table: "Subjects",
                column: "IdTeacherTeachingPlan");

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

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdProfessor",
                table: "Classes",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdTermCourseSubject",
                table: "Classes",
                column: "IdTermCourseSubject");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_IdCourse",
                table: "CourseSubjects",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_IdSubject",
                table: "CourseSubjects",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUsers_IdCourse",
                table: "CourseUsers",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUsers_IdUser",
                table: "CourseUsers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TermCourses_IdCourse",
                table: "TermCourses",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_TermCourses_IdTerm",
                table: "TermCourses",
                column: "IdTerm");

            migrationBuilder.CreateIndex(
                name: "IX_TermCourseSubjects_IdSubject",
                table: "TermCourseSubjects",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_TermCourseSubjects_IdTermCourse",
                table: "TermCourseSubjects",
                column: "IdTermCourse");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_IdProfessor",
                table: "Classes",
                column: "IdProfessor",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_TermCourseSubjects_IdTermCourseSubject",
                table: "Classes",
                column: "IdTermCourseSubject",
                principalTable: "TermCourseSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Users_IdTeacherTeachingPlan",
                table: "Subjects",
                column: "IdTeacherTeachingPlan",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_IdProfessor",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_TermCourseSubjects_IdTermCourseSubject",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Courses_CourseId",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Courses_CourseId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Courses_CourseId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Users_IdTeacherTeachingPlan",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "CourseSubjects");

            migrationBuilder.DropTable(
                name: "CourseUsers");

            migrationBuilder.DropTable(
                name: "TermCourseSubjects");

            migrationBuilder.DropTable(
                name: "TermCourses");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_IdTeacherTeachingPlan",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CourseId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Goals_CourseId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Competences_CourseId",
                table: "Competences");

            migrationBuilder.DropIndex(
                name: "IX_Classes_IdProfessor",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_IdTermCourseSubject",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SemesterNumber",
                table: "Terms");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Terms");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IdTeacherTeachingPlan",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "PracticalWorkload",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TheoryWorkload",
                table: "Subjects");

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

            migrationBuilder.DropColumn(
                name: "Menu",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "ProgramContents",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "TeachingMethod",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "ValuationMethod",
                table: "SubjectCurriculums");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "IdProfessor",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "IdTermCourseSubject",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Classes");
        }
    }
}
