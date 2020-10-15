using SquareEnixTest.Data;
using SquareEnixTest.Data.ViewModel;
using SquareEnixTest.Services.Interfaces;
using SquareEnixTest.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SquareEnixTest.Services
{
    public class GamesService: IGameService
    {
        private GameRepository _gameRepository;
        private readonly IGenreService _genreService;
        private readonly IPlatformService _platformService;
        private readonly IGamePlatformService _gamePlatformService;
        public GamesService(GameRepository gameRepository, IGenreService genreService, IPlatformService platformService, IGamePlatformService gamePlatformService)
        {
            _gameRepository = gameRepository;
            _genreService = genreService;
            _platformService = platformService;
            _gamePlatformService = gamePlatformService;
        }

        public Game GetGameById(int Id)
        {
            return _gameRepository.GetAll(x => x.Id == Id).SingleOrDefault();
        }

        public IList<Game> GetAllGamesAToZ()
        {
            var result=_gameRepository.GetAll(x => x != null).Select(x => new Game
            {
              Genre= x.Genre ==null?_genreService.getGenreById(x.GenreId): x.Genre,
               GenreId = x.GenreId,
               Id=x.Id,
               Name= x.Name,
               Platforms = x.Platforms != null? x.Platforms : (from gamePlatform in _gamePlatformService.getAllGamePlatforms()
                                              where (gamePlatform.GameId == x.Id)
                                              select new Data.Models.GamePlatforms
                                              {
                                                  Game = x,
                                                  GameId = x.Id,
                                                  Id = gamePlatform.Id,
                                                  Platform = gamePlatform.Platform == null ? _platformService.getPlatformById(gamePlatform.PlatFormId) : gamePlatform.Platform,
                                                  PlatFormId = gamePlatform.PlatFormId
                                              }).ToList()

            }).OrderByDescending(x=>x.Name).ToList();
            return result;
        }

        public bool DeleteGame(int id)
        {
            try
            {
                var game = _gameRepository.GetAll(x => x.Id == id).SingleOrDefault();
                game.Genre=game?.Genre == null ? _genreService.getGenreById(game.GenreId):game.Genre;
                game.Platforms=game?.Platforms == null ? _gamePlatformService.getAllGamePlatformsByGameId(game.Id): game.Platforms;

                if (game != null)
                {
                    _gameRepository.Delete(game);
                    
                    return true;
                }

            }catch(Exception e)
            {
               
            }

            return false;
        }

        public Game UpdateGame(Game game)
        {
            try
            {
                var gameObj = _gameRepository.GetAll(x => x.Id == game.Id).SingleOrDefault();

                if (gameObj != null)
                {
                    gameObj.Genre = game.Genre;
                    gameObj.GenreId = game.GenreId;
                    gameObj.Name = game.Name;
                    gameObj.Platforms = game.Platforms;
                    _gameRepository.Update(gameObj);

                   return _gameRepository.GetAll(x => x.Id == gameObj.Id).SingleOrDefault();
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }

        public Game AddGame(Game game)
        {
            
            return _gameRepository.Insert(game);

          
        }
    }
}
