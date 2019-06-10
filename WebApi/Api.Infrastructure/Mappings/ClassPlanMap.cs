using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class ClassPlanMap : IEntityTypeConfiguration<ClassPlan>
    {
        public void Configure(EntityTypeBuilder<ClassPlan> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .HasOne(m => m.Class)
                .WithOne(m => m.ClassPlan)
                .HasForeignKey(typeof(ClassPlan), "IdClassPlan")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
