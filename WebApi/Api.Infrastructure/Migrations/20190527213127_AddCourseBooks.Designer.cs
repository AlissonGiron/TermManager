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
    [Migration("20190527213127_AddCourseBooks")]
    partial class AddCourseBooks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
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

                    b.Property<int>("IdProfessor");

                    b.Property<int?>("IdTermCourseSubject");

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
                    b.HasOne("Api.Models.User", "Professor")
                        .WithMany("ProfessorClasses")
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Models.TermCourseSubject", "TermCourseSubject")
                        .WithMany("Classes")
                        .HasForeignKey("IdTermCourseSubject")
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

            modelBuilder.Entity("Api.Models.TermCourse", b =>
                {
                    b.HasOne("Api.Models.Course", "Course")
                        .WithMany("Terms")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Models.Term", "Term")
                        .WithMany("Courses")
                        .HasForeignKey("IdTerm")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Api.Models.TermCourseSubject", b =>
                {
                    b.HasOne("Api.Models.Subject", "Subject")
                        .WithMany("Terms")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Api.Models.TermCourse", "Term")
                        .WithMany("Subjects")
                        .HasForeignKey("IdTermCourse")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
