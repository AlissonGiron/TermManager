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
        }
    }
}
