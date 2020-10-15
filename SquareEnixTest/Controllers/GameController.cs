using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using SquareEnixTest.Data;
using SquareEnixTest.Data.ViewModel;
using SquareEnixTest.Services.Interfaces;

namespace SquareEnixTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;
        private IGenreService _genreService;
        private IPlatformService _platformService;
        private IGamePlatformService _gamePlatformService;
        public GameController(IGameService gameService, IGenreService genreService, IPlatformService platformService, IGamePlatformService gamePlatformService)
        {
            _gamePlatformService = gamePlatformService;
            _gameService = gameService;
            _genreService = genreService;
            _platformService = platformService;
        }


        [HttpGet]
        [Route("GetPlatforms")]
        public IActionResult GetPlatforms()
        {
            try
            {
                var platforms = _platformService.getAllPlatform();

                if (platforms.Any())
                {
                    return Ok(platforms);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetGenres")]
        public IActionResult GetGenres()
        {
            try
            {
                var genres = _genreService.getAllGenres();

                if (genres != null && genres.Any())
                {
                    return Ok(genres);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var games = _gameService.GetAllGamesAToZ().Select(x => new GameVm
                {

                    Genre = x.Genre.Name,
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Platforms = x.Platforms.Select(x => x?.Platform?.Name ?? _platformService.getPlatformById(x.PlatFormId).Name).ToList()

                });

                if (games != null)
                {
                    return Ok(games);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(GameVm game)
        {
            Game gameVm = null;

            try
            {
                int gameId = Convert.ToInt32(game.Id);
                var existingGame = _gameService.GetGameById(Convert.ToInt32(game.Id));
                existingGame.Genre = _genreService.getGenreByName(game.Genre);
                existingGame.GenreId = existingGame.Genre.Id;
                existingGame.Platforms = _gamePlatformService.getAllGamePlatforms().Where(x => game.Platforms.Contains(x.Platform == null ? _platformService.getPlatformById(x.PlatFormId).Name : x.Platform.Name) && x.Id == gameId).ToList();
                existingGame.Name = game.Name;


                gameVm = _gameService.UpdateGame(existingGame);

                if (gameVm != null)
                {
                    return Ok(game);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(game);
        }

        [HttpPost]
        public IActionResult Post(GameVm game)
        {
            Game newGame = null;
            try
            {
                if (!string.IsNullOrEmpty(game.Genre) && !string.IsNullOrEmpty(game.Name) && game.Platforms != null && game.Platforms.Any())
                {

                    newGame = _gameService.AddGame(new Data.Game
                    {
                        Genre = _genreService.getGenreObjByName(game.Genre), // use genre service to add exissting genre
                        Name = game.Name,
                        Platforms = null // use platform service to add existing platforms
                    });


                    var gamesPlatforms = from platform in game.Platforms
                                         let platformObj = _platformService.getPlatformByName(platform)
                                         let GameplatformObj = _gamePlatformService.Insert(new Data.Models.GamePlatforms()
                                         {
                                             GameId = newGame.Id,
                                             Game = newGame,
                                             Platform = platformObj,
                                             PlatFormId = platformObj.Id

                                         })
                                         select GameplatformObj;

                    newGame.Platforms = gamesPlatforms.ToList();
                }

                if (newGame != null)
                {
                    var updatedGame = _gameService.UpdateGame(newGame);
                    var gameVm = new GameVm
                    {
                        Genre = updatedGame.Genre.Name,
                        Name = updatedGame.Name,
                        Id = updatedGame.Id.ToString(),
                        IsSelected = false,
                        Platforms = updatedGame.Platforms.Select(x => x.Platform.Name).ToList()
                    };
                    return Ok(gameVm);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("GetAllGenres")]
        public IActionResult GetAllGenres()
        {
            try
            {
                var games = _genreService.getAllGenres().Select(x => x);

                if (games != null)
                {
                    return Ok(games);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return BadRequest("No Games Added!");
        }

        [HttpPost]
        [Route("DeleteGame")]
        public IActionResult DeleteGame(GameVm game)
        {
            try
            {
                if (game != null)
                {
                }
                var result = _gameService.DeleteGame(Convert.ToInt32(game.Id));
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("object doesnt exist");
                }

            }catch(Exception e)
            {

            }
          
            return BadRequest("Did no Delete");
        }
    }
}
