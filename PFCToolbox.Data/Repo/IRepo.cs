using PFCToolbox.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PFCToolbox.Data.Repo
{
    public interface IRepo<T> where T : Entity
    {
        void Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
    }
}
