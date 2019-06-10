using System;
using System.Collections.Generic;
using System.Text;
using static Api.Models.Enums;

namespace Api.Models
{
    public class ClassPlanBookItem : ModelBase
    {
        public int IdClassPlan { get; set; }
        public ClassPlan ClassPlan { get; set; }

        public int IdBook { get; set; }
        public Book Book { get; set; }

        public BibliographyType BibliographyType { get; set; }
    }
}
