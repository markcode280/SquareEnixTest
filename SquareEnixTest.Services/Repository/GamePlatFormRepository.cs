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
    public class GamePlatFormRepository : IGenericRepository<GamePlatforms>
    {
        private readonly IDatabase _database;
        public GamePlatFormRepository(IDatabase database)
        {
            _database = database;
        }
        public void Delete(GamePlatforms game)
        {
            _database.Delete(game);
            _database.SaveChanges();
            _database.Dispose();
        }

        public bool Exists(Expression<Func<GamePlatforms, bool>> where)
        {
            var result= _database.Any(where);
            _database.Dispose();
            return result;
        }

        public IEnumerable<GamePlatforms> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GamePlatforms> GetAll(Expression<Func<GamePlatforms, bool>> where)
        {
            var result = _database.Where(where);
            _database.Dispose();
            return result;
        }

        public GamePlatforms Insert(GamePlatforms game)
        {
            var platformGame = _database.Add(game);
            _database.SaveChanges();
            _database.Dispose();
            return platformGame;
        }

        public void Update(GamePlatforms game)
        {
            _database.AttatchTo(game);
            _database.SaveChanges();
            _database.Dispose();
        }
    }
}
