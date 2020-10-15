using SquareEnixTest.Data;
using SquareEnixTest.Services.Interfaces;
using SquareEnixTest.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SquareEnixTest.Services.Repository
{
    public class GameRepository : IGenericRepository<Game>
    {
        private readonly IDatabase _database;
        public GameRepository(IDatabase database)
        {
            _database = database;
        }
        public void Delete(Game game)
        {
            _database.Delete(game);
            _database.SaveChanges();
            _database.Dispose();
        }

        public bool Exists(Expression<Func<Game, bool>> where)
        {
            var result=_database.Any(where);
            _database.Dispose();
            return result;
        }

        public IEnumerable<Game> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAll(Expression<Func<Game, bool>> where)
        {
            var result= _database.Where(where);
            _database.Dispose();
            return result;
        }

        public Game Insert(Game game)
        {
            var result = _database.Add(game);
            _database.SaveChanges();
            _database.Dispose();
            return result;
        }

        public void Update(Game game)
        {
            _database.AttatchTo(game);
            _database.SaveChanges();
            _database.Dispose();
        }
    }
}
