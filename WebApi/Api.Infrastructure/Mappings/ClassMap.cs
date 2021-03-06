using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class ClassMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Professor).WithMany(s => s.ProfessorClasses).HasForeignKey(s => s.IdProfessor).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Subject).WithMany(s => s.Classes).HasForeignKey(s => s.IdSubject).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Course).WithMany(s => s.Classes).HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
