using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class ClassPlanScoreComposition : ModelBase
    {
        public int IdClassPlan { get; set; }
        public ClassPlan ClassPlan { get; set; }

        public string Activity { get; set; }
        public string Description { get; set; }
        public double ScoreWeight { get; set; }
    }
}
