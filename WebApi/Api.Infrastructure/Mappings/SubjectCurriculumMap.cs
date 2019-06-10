using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class SubjectCurriculumMap : IEntityTypeConfiguration<SubjectCurriculum>
    {
        public void Configure(EntityTypeBuilder<SubjectCurriculum> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Course).WithMany().HasForeignKey(s => s.IdCourse).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Subject).WithMany().HasForeignKey(s => s.IdSubject).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Professor).WithMany().HasForeignKey(s => s.IdProfessor).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
