using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WorkFollow.Data.DataContext;
using WorkFollow.Data.Interfaces;


namespace WorkFollow.Data.Implementaions
{
    public class EfRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly WorkFollowDataContext _dbContext;
        internal DbSet<T> dbSet;
        public EfRepository(WorkFollowDataContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();

        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        
        {
            return dbSet.Find(id);
        }

        public IList<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);

        }

        public void Update(T entity)
        {
            using (var context = new WorkFollowDataContext())
            {
                context.Entry<T>(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            //dbSet.Update(entity);
        }
    }
}
