﻿// <auto-generated />
using System;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190610043059_FixSubjectCurriculum2")]
    partial class FixSubjectCurriculum2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("IdCourse");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Api.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int?>("IdClassPlan");

                    b.Property<int>("IdCourse");

                    b.Property<int>("IdProfessor");

                    b.Property<int>("IdSubject");

                    b.Property<string>("Period");

                    b.Property<int>("SemesterNumber");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.HasIndex("IdProfessor");

                    b.HasIndex("IdSubject");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Api.Models.ClassPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdClass");

                    b.Property<int?>("IdClassPlan");

                    b.Property<string>("ScoreFinalDescription");

                    b.HasKey("Id");

                    b.HasIndex("IdClassPlan")
                        .IsUnique()
                        .HasFilter("[IdClassPlan] IS NOT NULL");

                    b.ToTable("ClassPlans");
                });

            modelBuilder.Entity("Api.Models.ClassPlanBookItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BibliographyType");

                    b.Property<int>("IdBook");

                    b.Property<int>("IdClassPlan");

                    b.HasKey("Id");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdClassPlan");

                    b.ToTable("ClassPlanBookItems");
                });

            modelBuilder.Entity("Api.Models.ClassPlanResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("IdClassPlan");

                    b.HasKey("Id");

                    b.HasIndex("IdClassPlan");

                    b.ToTable("ClassPlanResources");
                });

            modelBuilder.Entity("Api.Models.ClassPlanScoreComposition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activity");

                    b.Property<string>("Description");

                    b.Property<int>("IdClassPlan");

                    b.Property<double>("ScoreWeight");

                    b.HasKey("Id");

                    b.HasIndex("IdClassPlan");

                    b.ToTable("ClassPlanScoreCompositions");
                });

            modelBuilder.Entity("Api.Models.ClassPlanWeekItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Books");

                    b.Property<int>("ClassType");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int>("IdClassPlan");

                    b.Property<int>("Week");

                    b.HasKey("Id");

                    b.HasIndex("IdClassPlan");

                    b.ToTable("ClassPlanWeekItems");
                });

            modelBuilder.Entity("Api.Models.Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("IdCourse");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.ToTable("Competences");
                });

            modelBuilder.Entity("Api.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Api.Models.CourseSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCourse");

                    b.Property<int>("IdSubject");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.HasIndex("IdSubject");

                    b.ToTable("CourseSubjects");
                });

            modelBuilder.Entity("Api.Models.CourseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCourse");

                    b.Property<int>("IdUser");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.HasIndex("IdUser");

                    b.ToTable("CourseUsers");
                });

            modelBuilder.Entity("Api.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("IdCourse");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("Api.Models.LessonPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("LessonPlans");
                });

            modelBuilder.Entity("Api.Models.NDEMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("IdCourse");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.ToTable("NDEMembers");
                });

            modelBuilder.Entity("Api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("IdCourse");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Api.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("IdTeacherTeachingPlan");

                    b.Property<string>("Name");

                    b.Property<int>("PracticalWorkload");

                    b.Property<int>("TheoryWorkload");

                    b.HasKey("Id");

                    b.HasIndex("IdTeacherTeachingPlan");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avaliacao");

                    b.Property<int?>("CoordinatorId");

                    b.Property<int?>("CourseId");

                    b.Property<DateTime>("DateAvaliacao");

                    b.Property<DateTime>("DateValidacaoNDE");

                    b.Property<string>("Ementa");

                    b.Property<int>("IdCoordinator");

                    b.Property<int>("IdCourse");

                    b.Property<int>("IdProfessor");

                    b.Property<int>("IdSubject");

                    b.Property<int?>("ProfessorId");

                    b.Property<string>("ProgramContentM1");

                    b.Property<string>("ProgramContentM2");

                    b.Property<int?>("SubjectId");

                    b.Property<string>("TeachingMethod");

                    b.HasKey("Id");

                    b.HasIndex("CoordinatorId");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectCurriculums");
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdBook");

                    b.Property<int>("IdSubjectCurriculum");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdSubjectCurriculum");

                    b.ToTable("SubjectCurriculumBooks");
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumCompetence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCompetence");

                    b.Property<int>("IdSubjectCurriculum");

                    b.HasKey("Id");

                    b.HasIndex("IdCompetence");

                    b.HasIndex("IdSubjectCurriculum");

                    b.ToTable("SubjectCurriculumCompetences");
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdGoal");

                    b.Property<int>("IdSubjectCurriculum");

                    b.HasKey("Id");

                    b.HasIndex("IdGoal");

                    b.HasIndex("IdSubjectCurriculum");

                    b.ToTable("SubjectCurriculumGoals");
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumNDEMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdNDEMember");

                    b.Property<int>("IdSubjectCurriculum");

                    b.HasKey("Id");

                    b.HasIndex("IdNDEMember");

                    b.HasIndex("IdSubjectCurriculum");

                    b.ToTable("SubjectCurriculumNDEMembers");
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdSkill");

                    b.Property<int>("IdSubjectCurriculum");

                    b.HasKey("Id");

                    b.HasIndex("IdSkill");

                    b.HasIndex("IdSubjectCurriculum");

                    b.ToTable("SubjectCurriculumSkills");
                });

            modelBuilder.Entity("Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicTitle");

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Administrator");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<bool>("Coordinator");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<bool>("Professor");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Api.Models.Book", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Books")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Class", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Models.User", "Professor")
                        .WithMany("ProfessorClasses")
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Models.Subject", "Subject")
                        .WithMany("Classes")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.ClassPlan", b =>
                {
                    b.HasOne("Api.Models.Class", "Class")
                        .WithOne("ClassPlan")
                        .HasForeignKey("Api.Models.ClassPlan", "IdClassPlan")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.ClassPlanBookItem", b =>
                {
                    b.HasOne("Api.Models.Book", "Book")
                        .WithMany("BookItems")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Models.ClassPlan", "ClassPlan")
                        .WithMany("BookItems")
                        .HasForeignKey("IdClassPlan")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.ClassPlanResource", b =>
                {
                    b.HasOne("Api.Models.ClassPlan", "ClassPlan")
                        .WithMany("Resources")
                        .HasForeignKey("IdClassPlan")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.ClassPlanScoreComposition", b =>
                {
                    b.HasOne("Api.Models.ClassPlan", "ClassPlan")
                        .WithMany("ScoreCompositions")
                        .HasForeignKey("IdClassPlan")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.ClassPlanWeekItem", b =>
                {
                    b.HasOne("Api.Models.ClassPlan", "ClassPlan")
                        .WithMany("WeekItems")
                        .HasForeignKey("IdClassPlan")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.Competence", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Competences")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.CourseSubject", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Subjects")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Models.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.CourseUser", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Users")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Models.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.Goal", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Goals")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.NDEMember", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("NDEMembers")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Skill", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Skills")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Subject", b =>
                {
                    b.HasOne("Api.Models.User", "ProfessorTeachingPlan")
                        .WithMany("TeachingPlanResponsibleSubjects")
                        .HasForeignKey("IdTeacherTeachingPlan")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculum", b =>
                {
                    b.HasOne("Api.Models.User", "Coordinator")
                        .WithMany()
                        .HasForeignKey("CoordinatorId");

                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Api.Models.User", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.HasOne("Api.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumBook", b =>
                {
                    b.HasOne("Api.Models.Book", "Book")
                        .WithMany("SubjectCurriculums")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.SubjectCurriculum", "SubjectCurriculum")
                        .WithMany("Bibliography")
                        .HasForeignKey("IdSubjectCurriculum")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumCompetence", b =>
                {
                    b.HasOne("Api.Models.Competence", "Competence")
                        .WithMany("SubjectCurriculums")
                        .HasForeignKey("IdCompetence")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.SubjectCurriculum", "SubjectCurriculum")
                        .WithMany("Competences")
                        .HasForeignKey("IdSubjectCurriculum")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumGoal", b =>
                {
                    b.HasOne("Api.Models.Goal", "Goal")
                        .WithMany("SubjectCurriculums")
                        .HasForeignKey("IdGoal")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.SubjectCurriculum", "SubjectCurriculum")
                        .WithMany("Goals")
                        .HasForeignKey("IdSubjectCurriculum")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumNDEMember", b =>
                {
                    b.HasOne("Api.Models.NDEMember", "NDEMember")
                        .WithMany("SubjectCurriculums")
                        .HasForeignKey("IdNDEMember")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.SubjectCurriculum", "SubjectCurriculum")
                        .WithMany("NDEMembers")
                        .HasForeignKey("IdSubjectCurriculum")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.SubjectCurriculumSkill", b =>
                {
                    b.HasOne("Api.Models.Skill", "Skill")
                        .WithMany("SubjectCurriculums")
                        .HasForeignKey("IdSkill")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.SubjectCurriculum", "SubjectCurriculum")
                        .WithMany("Skills")
                        .HasForeignKey("IdSubjectCurriculum")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
