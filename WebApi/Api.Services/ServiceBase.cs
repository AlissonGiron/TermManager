using Api.Infrastructure;
using Api.Infrastructure.Extensions;
using Api.Infrastructure.Helpers;
using Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Services
{
    public class ServiceBase : IServiceBase
    {
        private Context _context;

        public ServiceBase(Context context) => _context = context;

        public virtual ICollection<T> Read<T>(Query<T> query = null) where T : class, new() => _context.Read(query);
        public virtual ICollection<T> Read<T>(Expression<Func<T, bool>> filter) where T : class, new() => Read(new Query<T>().Filter(filter));

        public virtual T FirstOrDefault<T>(Query<T> query = null) where T : class, new() => _context.FirstOrDefault(query);
        public virtual T FirstOrDefault<T>(Expression<Func<T, bool>> filter) where T : class, new() => FirstOrDefault(new Query<T>().Filter(filter));

        public virtual int Count<T>(Query<T> query = null) where T : class, new() => _context.Count(query);
        public virtual int Count<T>(Expression<Func<T, bool>> filter) where T : class, new() => Count(new Query<T>().Filter(filter));

        public virtual void Create<T>(T entity) where T : class, new() => _context.Add(entity);
        public virtual void Edit<T>(T entity) where T : class, new() => _context.Edit(entity);
        public virtual void Delete<T>(T entity) where T : class, new() => _context.Delete(entity);

        public virtual void Save() => _context.SaveChanges();
        public virtual void Dispose() { } // => _context.Dispose();

        public void BeginTransaction() => _context.Database.BeginTransaction();
        public void CommitTransaction() => _context.Database.CommitTransaction();
        public void RollbackTransaction() => _context.Database.RollbackTransaction();
    }
}
