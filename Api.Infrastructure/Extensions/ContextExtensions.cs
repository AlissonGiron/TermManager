using Api.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Infrastructure.Extensions
{
    public static class ContextExtensions
    {
        public static void Add<T>(this Context context, T entity) where T : class
        {
            context.Set<T>().Add(entity);
        }

        public static T Edit<T>(this Context context, T entity) where T : class
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public static void Delete<T>(this Context context, T entity) where T : class
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public static Int32 Count<T>(this Context context, Query<T> query = null) where T : class
        {
            return context.Set<T>().AsQueryable().ApplyQuery(query).Count();
        }

        public static ICollection<T> Read<T>(this Context context, Query<T> query = null) where T : class
        {
            return context.Set<T>().AsQueryable().ApplyQuery(query).ToList();
        }

        public static T FirstOrDefault<T>(this Context context, Query<T> query = null) where T : class
        {
            return context.Set<T>().AsQueryable().ApplyQuery(query).FirstOrDefault();
        }

        private static IQueryable<T> ApplyQuery<T>(this IQueryable<T> queryable, Query<T> query = null) where T : class
        {
            if (query == null) return queryable;

            query.Includes?.ForEach(include => {
                if (include.Body is MemberExpression)
                {
                    queryable = queryable.Include(include);
                    return;
                }

                List<String> LIncludeFields = ((MethodCallExpression)include.Body).ToString().Split('.', ')', '(').Skip(1).ToList();
                LIncludeFields.RemoveAll(t => t.StartsWith("Select") || t.Contains("=>") || string.IsNullOrEmpty(t));

                queryable = queryable.Include(String.Join('.', LIncludeFields));
            });

            if (query.Filters?.Count > 0)
            {
                query.Filters?.ForEach(f => queryable = queryable.Where(f));
            }

            if (query.SortFields?.Count > 0)
            {
                query.SortFields?.ForEach(ASortField =>
                {
                    // TODO: TESTAR
                        queryable = ASortField.SortDescending
                        ? queryable.OrderByDescending(ASortField.FieldAccessor)
                        : queryable.OrderBy(ASortField.FieldAccessor);
                });
            }

            if (query.SkipQuantity > 0) { queryable = queryable.Skip(query.SkipQuantity); }

            if ((query.TakeQuantity > 0) && (query.TakeQuantity < Int32.MaxValue)) { queryable = queryable.Take(query.TakeQuantity); }

            if (!query.TrackEntity) { queryable = queryable.AsNoTracking(); }

            return queryable;
        }
    }
}