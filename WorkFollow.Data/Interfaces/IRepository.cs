using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WorkFollow.Data.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        IList<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
       
        T Get(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
       
    }
}
