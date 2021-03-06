﻿using Api.Infrastructure.Mappings;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<NDEMember> NDEMembers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<SubjectCurriculum> SubjectCurriculums { get; set; }
        public DbSet<SubjectCurriculumBook> SubjectCurriculumBooks { get; set; }
        public DbSet<SubjectCurriculumGoal> SubjectCurriculumGoals { get; set; }
        public DbSet<SubjectCurriculumSkill> SubjectCurriculumSkills { get; set; }
        public DbSet<SubjectCurriculumNDEMember> SubjectCurriculumNDEMembers { get; set; }
        public DbSet<SubjectCurriculumCompetence> SubjectCurriculumCompetences { get; set; }

        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }

        public DbSet<ClassPlan> ClassPlans { get; set; }
        public DbSet<ClassPlanBookItem> ClassPlanBookItems { get; set; }
        public DbSet<ClassPlanResource> ClassPlanResources { get; set; }
        public DbSet<ClassPlanScoreComposition> ClassPlanScoreCompositions { get; set; }
        public DbSet<ClassPlanWeekItem> ClassPlanWeekItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyMappings(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ApplyMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new SubjectMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new GoalMap());
            modelBuilder.ApplyConfiguration(new SkillMap());
            modelBuilder.ApplyConfiguration(new CompetenceMap());
            modelBuilder.ApplyConfiguration(new NDEMemberMap());
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new LessonPlanMap());
            modelBuilder.ApplyConfiguration(new SubjectCurriculumMap());

            modelBuilder.ApplyConfiguration(new SubjectCurriculumBookMap());
            modelBuilder.ApplyConfiguration(new SubjectCurriculumGoalMap());
            modelBuilder.ApplyConfiguration(new SubjectCurriculumCompetenceMap());
            modelBuilder.ApplyConfiguration(new SubjectCurriculumSkillMap());
            modelBuilder.ApplyConfiguration(new SubjectCurriculumNDEMemberMap());

            modelBuilder.ApplyConfiguration(new CourseSubjectMap());
            modelBuilder.ApplyConfiguration(new CourseUserMap());

            modelBuilder.ApplyConfiguration(new ClassPlanMap());
            modelBuilder.ApplyConfiguration(new ClassPlanBookItemMap());
            modelBuilder.ApplyConfiguration(new ClassPlanResourceMap());
            modelBuilder.ApplyConfiguration(new ClassPlanScoreCompositionMap());
            modelBuilder.ApplyConfiguration(new ClassPlanWeekItemMap());
        }

        public void Seed()
        {
            if (Users.Any()) return;

            Users.Add(new User
            {
                UserName = "masteradmin",
                NormalizedUserName = "MASTERADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEKCyrh8Hw9O+tClDmELUfcjo/qIAmuJpMx7tayC1zroNz5ienl4end/dDhUVjcAZrg==",
                Administrator = true,
                Professor = true,
                Coordinator = true
            });

            SaveChanges();
        }
    }
}