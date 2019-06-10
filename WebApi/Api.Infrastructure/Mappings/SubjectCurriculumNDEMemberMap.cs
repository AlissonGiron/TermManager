using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class SubjectCurriculumNDEMemberMap : IEntityTypeConfiguration<SubjectCurriculumNDEMember>
    {
        public void Configure(EntityTypeBuilder<SubjectCurriculumNDEMember> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.SubjectCurriculum).WithMany(v => v.NDEMembers).HasForeignKey(v => v.IdSubjectCurriculum);
            builder.HasOne(s => s.NDEMember).WithMany(v => v.SubjectCurriculums).HasForeignKey(v => v.IdNDEMember);
        }
    }
}
