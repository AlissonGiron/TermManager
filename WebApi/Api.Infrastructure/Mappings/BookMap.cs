using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasOne(s => s.Course).WithMany(s => s.Books).HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
