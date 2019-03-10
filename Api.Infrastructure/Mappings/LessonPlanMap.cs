using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class LessonPlanMap : IEntityTypeConfiguration<LessonPlan>
    {
        public void Configure(EntityTypeBuilder<LessonPlan> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}
