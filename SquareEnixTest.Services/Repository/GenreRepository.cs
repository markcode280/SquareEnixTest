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
    public class GenreRepository : IGenericRepository<Genre>
    {
        private readonly IDatabase _database;
        public GenreRepository(IDatabase database)
        {
            _database = database;
        }
        public void Delete(Genre game)
        {
            _database.Delete(game);
            _database.SaveChanges();
            _database.Dispose();
        }

        public bool Exists(Expression<Func<Genre, bool>> where)
        {
            var result = _database.Any(where);
            _database.Dispose();
            return result;
        }

        public IEnumerable<Genre> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAll(Expression<Func<Genre, bool>> where)
        {
            var result=_database.Where(where);
            _database.Dispose();
            return result;
        }

        public Genre Insert(Genre game)
        {
            var genre=_database.Add(game);
            _database.SaveChanges();
            _database.Dispose();
            return genre;
        }

        public void Update(Genre game)
        {
            _database.AttatchTo(game);
            _database.SaveChanges();
            _database.Dispose();
        }
    }
}
