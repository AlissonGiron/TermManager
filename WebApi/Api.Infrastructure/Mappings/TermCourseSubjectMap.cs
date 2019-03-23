using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class TermCourseSubjectMap : IEntityTypeConfiguration<TermCourseSubject>
    {
        public void Configure(EntityTypeBuilder<TermCourseSubject> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Term).WithMany(s => s.Subjects).HasForeignKey(s => s.IdTermCourse);
            builder.HasOne(s => s.Subject).WithMany(s => s.Terms).HasForeignKey(s => s.IdSubject);
        }
    }
}
