using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class ClassPlanWeekItemMap : IEntityTypeConfiguration<ClassPlanWeekItem>
    {
        public void Configure(EntityTypeBuilder<ClassPlanWeekItem> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.ClassPlan).WithMany(m => m.WeekItems).HasForeignKey(m => m.IdClassPlan).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
