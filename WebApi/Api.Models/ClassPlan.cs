using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class ClassPlan : ModelBase
    {
        public int IdClass { get; set; }
        public Class Class { get; set; }

        public ICollection<ClassPlanWeekItem> WeekItems { get; set; }

        public ICollection<ClassPlanBookItem> BookItems { get; set; }

        public ICollection<ClassPlanScoreComposition> ScoreCompositions { get; set; }
        public string ScoreFinalDescription { get; set; }

        public ICollection<ClassPlanResource> Resources { get; set; }
    }
}
