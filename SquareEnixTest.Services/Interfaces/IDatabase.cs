using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SquareEnixTest.Services.Interfaces
{
    public interface IDatabase
    {
        void Dispose();
        int SaveChanges();
        void AttatchTo<T>(T Entity) where T : class;

        IEnumerable<T> Where<T>(Expression<Func<T, bool>> where) where T : class;

        T Add<T>(T entity) where T : class;

        bool Any<T>(Expression<Func<T, bool>> where) where T : class;
        void Delete<T>(T Entity) where T : class;
    }
}
