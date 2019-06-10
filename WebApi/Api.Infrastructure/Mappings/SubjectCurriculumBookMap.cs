using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class SubjectCurriculumBookMap : IEntityTypeConfiguration<SubjectCurriculumBook>
    {
        public void Configure(EntityTypeBuilder<SubjectCurriculumBook> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.SubjectCurriculum).WithMany(v => v.Bibliography).HasForeignKey(v => v.IdSubjectCurriculum);
            builder.HasOne(s => s.Book).WithMany(v => v.SubjectCurriculums).HasForeignKey(v => v.IdBook);
        }
    }
}
