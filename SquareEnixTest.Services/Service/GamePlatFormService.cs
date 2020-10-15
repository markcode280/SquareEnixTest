using SquareEnixTest.Data.Models;
using SquareEnixTest.Services.Interfaces;
using SquareEnixTest.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SquareEnixTest.Services
{
    public class GamePlatformService: IGamePlatformService
    {
        private GamePlatFormRepository _platformRepository;
        public GamePlatformService(GamePlatFormRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public IList<GamePlatforms> getAllGamePlatforms()
        {
            return _platformRepository.GetAll(x=>x!=null).ToList();
        }

        public IList<GamePlatforms> getAllGamePlatformsByGameId(int id)
        {
            return _platformRepository.GetAll(x => x.GameId == id).ToList();
        }

        public GamePlatforms GetGameById(int Id)
        {
            return _platformRepository.GetAll(x => x.Id==Id).SingleOrDefault();
        }

        public GamePlatforms Insert(GamePlatforms gamePlatforms)
        {
            return _platformRepository.Insert(gamePlatforms);
        }
    }
}
