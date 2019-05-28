using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class RemoveTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_TermCourseSubjects_IdTermCourseSubject",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "TermCourseSubjects");

            migrationBuilder.DropTable(
                name: "TermCourses");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropIndex(
                name: "IX_Classes_IdTermCourseSubject",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "IdTermCourseSubject",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "IdCourse",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSubject",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SemesterNumber",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdCourse",
                table: "Classes",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdSubject",
                table: "Classes",
                column: "IdSubject");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_IdCourse",
                table: "Classes",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Subjects_IdSubject",
                table: "Classes",
                column: "IdSubject",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_IdCourse",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Subjects_IdSubject",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_IdCourse",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_IdSubject",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "IdCourse",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "IdSubject",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SemesterNumber",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "IdTermCourseSubject",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SemesterNumber = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCourse = table.Column<int>(nullable: false),
                    IdTerm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermCourses_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TermCourses_Terms_IdTerm",
                        column: x => x.IdTerm,
                        principalTable: "Terms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TermCourseSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdSubject = table.Column<int>(nullable: false),
                    IdTermCourse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermCourseSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermCourseSubjects_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TermCourseSubjects_TermCourses_IdTermCourse",
                        column: x => x.IdTermCourse,
                        principalTable: "TermCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdTermCourseSubject",
                table: "Classes",
                column: "IdTermCourseSubject");

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
                name: "FK_Classes_TermCourseSubjects_IdTermCourseSubject",
                table: "Classes",
                column: "IdTermCourseSubject",
                principalTable: "TermCourseSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
