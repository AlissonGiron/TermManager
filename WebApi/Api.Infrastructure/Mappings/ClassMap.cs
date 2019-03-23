using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class ClassMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Professor).WithMany(s => s.ProfessorClasses).HasForeignKey(s => s.IdProfessor);
            builder.HasOne(s => s.TermCourseSubject).WithMany(s => s.Classes).HasForeignKey(s => s.IdTermCourseSubject);
        }
    }
}
