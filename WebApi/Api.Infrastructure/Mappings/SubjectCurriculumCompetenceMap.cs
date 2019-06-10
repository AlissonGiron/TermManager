using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class SubjectCurriculumCompetenceMap : IEntityTypeConfiguration<SubjectCurriculumCompetence>
    {
        public void Configure(EntityTypeBuilder<SubjectCurriculumCompetence> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.SubjectCurriculum).WithMany(v => v.Competences).HasForeignKey(v => v.IdSubjectCurriculum);
            builder.HasOne(s => s.Competence).WithMany(v => v.SubjectCurriculums).HasForeignKey(v => v.IdCompetence);
        }
    }
}
