using System;

namespace Api.Models
{
    public class ClassPlanResource : ModelBase
    {
        public int IdClassPlan { get; set; }
        public ClassPlan ClassPlan { get; set; }

        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}
