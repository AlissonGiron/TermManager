using Api.Infrastructure.Mappings;
using Api.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Term> Terms { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<SubjectCurriculum> SubjectCurriculums { get; set; }

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
            modelBuilder.ApplyConfiguration(new TermMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new LessonPlanMap());
            modelBuilder.ApplyConfiguration(new SubjectCurriculumMap());
        }
    }
}