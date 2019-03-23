using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class CourseUserMap : IEntityTypeConfiguration<CourseUser>
    {
        public void Configure(EntityTypeBuilder<CourseUser> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(t => t.Course).WithMany(t => t.Users).HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.User).WithMany(t => t.Courses).HasForeignKey(s => s.IdUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
