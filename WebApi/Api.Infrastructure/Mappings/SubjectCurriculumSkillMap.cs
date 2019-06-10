using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class SubjectCurriculumSkillMap : IEntityTypeConfiguration<SubjectCurriculumSkill>
    {
        public void Configure(EntityTypeBuilder<SubjectCurriculumSkill> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.SubjectCurriculum).WithMany(v => v.Skills).HasForeignKey(v => v.IdSubjectCurriculum);
            builder.HasOne(s => s.Skill).WithMany(v => v.SubjectCurriculums).HasForeignKey(v => v.IdSkill);
        }
    }
}
