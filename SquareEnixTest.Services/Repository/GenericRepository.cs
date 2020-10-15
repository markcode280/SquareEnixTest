
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SquareEnixTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SquareEnixTest.Services.Service
{
    public class EntityFrameworkContext : IDatabase
    {
        private readonly GamesDbContext _gamesDbContext;
        public EntityFrameworkContext(GamesDbContext gamesDbContext)
        {
            _gamesDbContext = gamesDbContext;
        }
        public T Add<T>(T entity) where T : class
        {
          return _gamesDbContext.Add<T>(entity).Entity; 
        }

        public bool Any<T>(Expression<Func<T, bool>> where) where T : class
        {
            return _gamesDbContext.Set<T>().Where(where).Any();
        }

        public void AttatchTo<T>(T Entity) where T : class
        {
           _gamesDbContext.Entry<T>(Entity).State = EntityState.Modified;
        }

        public void Delete<T>(T Entity) where T : class
        {
            _gamesDbContext.Remove<T>(Entity);
        }

        public void Dispose()
        {
            _gamesDbContext.Dispose();
        }

        public int SaveChanges()
        {
           return _gamesDbContext.SaveChanges();
        }

        public IEnumerable<T> Where<T>(Expression<Func<T, bool>> where) where T : class
        {
           return _gamesDbContext.Set<T>().Where(where);
        }
    }
}
