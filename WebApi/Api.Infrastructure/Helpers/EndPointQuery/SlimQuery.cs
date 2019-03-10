using System.Collections.Generic;

namespace Api.Infrastructure.Helpers
{
        public class SlimQuery {
                public bool track { get; set; }

                public int take { get; set; }

                public int skip { get; set; }

                public List<SlimSortField> sorts { get; set; }
                public List<Filter> filters { get; set; }

                public List<string> includes { get; set; }
        }
}
