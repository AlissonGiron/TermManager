using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class CompetenceMap : IEntityTypeConfiguration<Competence>
    {
        public void Configure(EntityTypeBuilder<Competence> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}
