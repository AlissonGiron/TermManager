using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class GoalMap : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Course).WithMany(s => s.Goals).HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
