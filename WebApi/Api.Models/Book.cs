using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class Book : ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }
    }
}
