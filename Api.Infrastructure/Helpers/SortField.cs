using System;
using System.Linq.Expressions;

namespace Api.Infrastructure.Helpers
{
    public class SortField<TEntity>
    {
        public Expression<Func<TEntity, Object>> FieldAccessor { get; set; }

        public bool SortDescending { get; set; }

        public SortField(Expression<Func<TEntity, Object>> fieldAccessor, bool sortDescending = false)
        {
            FieldAccessor = fieldAccessor;
            SortDescending = sortDescending;
        }
    }
}
