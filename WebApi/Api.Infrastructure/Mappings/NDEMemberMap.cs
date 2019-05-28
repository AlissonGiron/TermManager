using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class NDEMemberMap : IEntityTypeConfiguration<NDEMember>
    {
        public void Configure(EntityTypeBuilder<NDEMember> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Course).WithMany(s => s.NDEMembers).HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
