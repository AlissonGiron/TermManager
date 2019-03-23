using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class TermCourseMap : IEntityTypeConfiguration<TermCourse>
    {
        public void Configure(EntityTypeBuilder<TermCourse> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Term).WithMany(s => s.Courses).HasForeignKey(s => s.IdTerm).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Course).WithMany(s => s.Terms).HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
