using Api.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.Interfaces
{
    public interface IServiceBase : IDisposable
    {
        ICollection<T> Read<T>(Query<T> query = null) where T: class, new();
        ICollection<T> Read<T>(Expression<Func<T, bool>> filter) where T : class, new();

        T FirstOrDefault<T>(Query<T> query = null) where T: class, new();
        T FirstOrDefault<T>(Expression<Func<T, bool>> filter) where T: class, new();

        int Count<T>(Query<T> query = null) where T: class, new();
        int Count<T>(Expression<Func<T, bool>> filter) where T: class, new();
        
        void Create<T>(T entity) where T: class, new();
        void Edit<T>(T entity) where T: class, new();
        void Delete<T>(T entity) where T: class, new();
        void Save();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
