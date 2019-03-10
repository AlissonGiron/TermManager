using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.Infrastructure.Helpers
{
    public class Query<T> where T : class
    {
        public Query()
        {
            SortFields = new List<SortField<T>>();
            Filters = new List<Expression<Func<T, Boolean>>>();
            Includes = new List<Expression<Func<T, Object>>>();
            TrackEntity = true;
        }

        public bool TrackEntity { get; set; }

        public int TakeQuantity { get; set; }

        public int SkipQuantity { get; set; }

        public List<SortField<T>> SortFields { get; set; }
        public List<Expression<Func<T, bool>>> Filters { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Query<T> Sort(Expression<Func<T, object>> field, bool descending = false)
        {
            SortFields.Add(new SortField<T>(field, descending));
            return this;
        }
        public Query<T> Filter(Expression<Func<T, Boolean>> filter)
        {
            Filters.Add(filter);
            return this;
        }

        public Query<T> Include(Expression<Func<T, Object>> field)
        {
            Includes.Add(field);
            return this;
        }

        public Query<T> Skip(Int32 quantity)
        {
            SkipQuantity = quantity;
            return this;
        }

        public Query<T> Take(Int32 quantity)
        {
            TakeQuantity = quantity;
            return this;
        }

        public Query<T> Track(bool trackEntity = true)
        {
            TrackEntity = trackEntity;
            return this;
        }
    }
}
