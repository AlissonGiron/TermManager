﻿// <auto-generated />
using System;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("IdProfessor");

                    b.Property<int>("IdTermCourseSubject");

                    b.Property<string>("Number");

                    b.Property<string>("Period");

                    b.HasKey("Id");

                    b.HasIndex("IdProfessor");

                    b.HasIndex("IdTermCourseSubject");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Api.Models.Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

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

                    b.Property<int?>("CourseId");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

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

            modelBuilder.Entity("Api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

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

                    b.Property<string>("Bibliography");

                    b.Property<string>("Competence");

                    b.Property<string>("Goal");

                    b.Property<string>("MembersNDE");

                    b.Property<string>("Menu");

                    b.Property<string>("ProgramContents");

                    b.Property<string>("Skill");

                    b.Property<string>("TeachingMethod");

                    b.Property<string>("ValuationMethod");

                    b.HasKey("Id");

                    b.ToTable("SubjectCurriculums");
                });

            modelBuilder.Entity("Api.Models.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SemesterNumber");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("Api.Models.TermCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCourse");

                    b.Property<int>("IdTerm");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.HasIndex("IdTerm");

                    b.ToTable("TermCourses");
                });

            modelBuilder.Entity("Api.Models.TermCourseSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdSubject");

                    b.Property<int>("IdTermCourse");

                    b.HasKey("Id");

                    b.HasIndex("IdSubject");

                    b.HasIndex("IdTermCourse");

                    b.ToTable("TermCourseSubjects");
                });

            modelBuilder.Entity("Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicTitle");

                    b.Property<bool>("Administrator");

                    b.Property<bool>("Coordinator");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<bool>("Professor");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Api.Models.Class", b =>
                {
                    b.HasOne("Api.Models.User", "Professor")
                        .WithMany("ProfessorClasses")
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.TermCourseSubject", "TermCourseSubject")
                        .WithMany("Classes")
                        .HasForeignKey("IdTermCourseSubject")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Competence", b =>
                {
                    b.HasOne("Api.Models.Course")
                        .WithMany("Competences")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Api.Models.CourseSubject", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Subjects")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.CourseUser", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Users")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Goal", b =>
                {
                    b.HasOne("Api.Models.Course")
                        .WithMany("Goals")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Api.Models.Skill", b =>
                {
                    b.HasOne("Api.Models.Course")
                        .WithMany("Skills")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Api.Models.Subject", b =>
                {
                    b.HasOne("Api.Models.User", "ProfessorTeachingPlan")
                        .WithMany("TeachingPlanResponsibleSubjects")
                        .HasForeignKey("IdTeacherTeachingPlan")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.TermCourse", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Terms")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.Term", "Term")
                        .WithMany("Courses")
                        .HasForeignKey("IdTerm")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.TermCourseSubject", b =>
                {
                    b.HasOne("Api.Models.Subject", "Subject")
                        .WithMany("Terms")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.TermCourse", "Term")
                        .WithMany("Subjects")
                        .HasForeignKey("IdTermCourse")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
