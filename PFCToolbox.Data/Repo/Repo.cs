using PFCToolbox.Common.Model;
using PFCToolbox.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PFCToolbox.Data.Repo
{
    public interface IRepo<T> where T : DatabaseEntity
    {
        void Delete(T entity);
        void DeleteByID(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        T Insert(T entity);
        void Update(T entity);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
    }

    public class Repo<T> : IRepo<T> where T : DatabaseEntity
    {
        private readonly PFCToolboxContext _dbContext;

        public Repo(PFCToolboxContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            var itemToDelete = _dbContext.Set<T>()
                .FirstOrDefault(x => x.ID.Equals(id));

            if (itemToDelete != null)
            {
                Delete(itemToDelete);
            }
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public T Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                .Where(predicate)
                .AsEnumerable();
        }
    }
}
