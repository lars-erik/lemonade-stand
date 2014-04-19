using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LemonadeStand.Common.Persistence;

namespace LemonadeStand.Tests.Fakes
{
    public class FakeRepository<T> : IRepository<T> 
        where T : class
    {
        public List<T> Items { get; set; }

        public FakeRepository()
        {
            Items = new List<T>();
        }

        public void Insert(T entity)
        {
            Items.Add(entity);
        }

        public void Delete(T entity)
        {
            Items.Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return Items.AsQueryable();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return Items.AsQueryable().SingleOrDefault(predicate);
        }
    }
}
