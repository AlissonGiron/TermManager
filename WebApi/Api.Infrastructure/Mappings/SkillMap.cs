using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class SkillMap : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Course).WithMany(s => s.Skills).HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
