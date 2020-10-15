using SquareEnixTest.Data;
using SquareEnixTest.Data.Models;
using SquareEnixTest.Services.Interfaces;
using SquareEnixTest.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SquareEnixTest.Services.Repository
{
    public class PlatFormRepository : IGenericRepository<Platform>
    {
        private readonly IDatabase _database;
        public PlatFormRepository(IDatabase database)
        {
            _database = database;
        }
        public void Delete(Platform game)
        {
            _database.Delete(game);
            _database.SaveChanges();
            _database.Dispose();
        }

        public bool Exists(Expression<Func<Platform, bool>> where)
        {
            var result= _database.Any(where);
            _database.Dispose();
            return result;
        }

        public IEnumerable<Platform> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Platform> GetAll(Expression<Func<Platform, bool>> where)
        {
            var result= _database.Where(where);
            _database.Dispose();
            return result;
        }

        public Platform Insert(Platform game)
        {
            var result=_database.Add(game);
            _database.SaveChanges();
            _database.Dispose();
            return result;
        }

        public void Update(Platform game)
        {
            _database.AttatchTo(game);
            _database.SaveChanges();
            _database.Dispose();
        }
    }
}
