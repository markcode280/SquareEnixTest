using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SquareEnixTest.Services.Interfaces
{
   public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);
        void Update(T entity);
        T Insert(T entity);
        void Delete(T entity);
        bool Exists(Expression<Func<T, bool>> where);
    }
}
