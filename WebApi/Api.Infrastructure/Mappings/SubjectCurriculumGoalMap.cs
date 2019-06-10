using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class SubjectCurriculumGoalMap : IEntityTypeConfiguration<SubjectCurriculumGoal>
    {
        public void Configure(EntityTypeBuilder<SubjectCurriculumGoal> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.SubjectCurriculum).WithMany(v => v.Goals).HasForeignKey(v => v.IdSubjectCurriculum);
            builder.HasOne(s => s.Goal).WithMany(v => v.SubjectCurriculums).HasForeignKey(v => v.IdGoal);
        }
    }
}
