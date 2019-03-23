using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class CourseSubjectMap : IEntityTypeConfiguration<CourseSubject>
    {
        public void Configure(EntityTypeBuilder<CourseSubject> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(t => t.Course).WithMany(s => s.Subjects).HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Subject).WithMany(s => s.Courses).HasForeignKey(s => s.IdSubject).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
