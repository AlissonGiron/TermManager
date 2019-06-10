using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class ClassPlanResourceMap : IEntityTypeConfiguration<ClassPlanResource>
    {
        public void Configure(EntityTypeBuilder<ClassPlanResource> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.ClassPlan).WithMany(m => m.Resources).HasForeignKey(m => m.IdClassPlan).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
