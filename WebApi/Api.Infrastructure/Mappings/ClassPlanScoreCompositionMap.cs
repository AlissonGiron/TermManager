using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Infrastructure.Mappings
{
    public class ClassPlanScoreCompositionMap : IEntityTypeConfiguration<ClassPlanScoreComposition>
    {
        public void Configure(EntityTypeBuilder<ClassPlanScoreComposition> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.ClassPlan).WithMany(m => m.ScoreCompositions).HasForeignKey(m => m.IdClassPlan).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
