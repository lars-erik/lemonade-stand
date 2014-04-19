using System;
using System.Linq;
using System.Linq.Expressions;

namespace LemonadeStand.Common.Persistence
{
    public interface IRepository<T>
        where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> Query();
        T Get(Expression<Func<T, bool>> predicate);
    }
}
