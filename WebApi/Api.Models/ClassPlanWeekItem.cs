using System;
using static Api.Models.Enums;

namespace Api.Models
{
    public class ClassPlanWeekItem : ModelBase
    {
        public int IdClassPlan { get; set; }
        public ClassPlan ClassPlan { get; set; }

        public int Week { get; set; }
        public DateTime Date { get; set; }
        public ClassType ClassType { get; set; }
        public string Content { get; set; }
        public string Books { get; set; }
    }
}
