using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class ClassPlanBookItemMap : IEntityTypeConfiguration<ClassPlanBookItem>
    {
        public void Configure(EntityTypeBuilder<ClassPlanBookItem> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.ClassPlan).WithMany(m => m.BookItems).HasForeignKey(m => m.IdClassPlan).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Book).WithMany(m => m.BookItems).HasForeignKey(m => m.IdBook).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
