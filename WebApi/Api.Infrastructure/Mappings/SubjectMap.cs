using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class SubjectMap : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.ProfessorTeachingPlan).WithMany(s => s.TeachingPlanResponsibleSubjects).HasForeignKey(s => s.IdTeacherTeachingPlan).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
