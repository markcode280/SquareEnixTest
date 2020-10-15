using SquareEnixTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareEnixTest.Services.Interfaces
{
    public interface IGamePlatformService
    {
        GamePlatforms Insert(GamePlatforms gamePlatforms);
        GamePlatforms GetGameById(int Id);

        IList<GamePlatforms> getAllGamePlatforms();
        IList<GamePlatforms> getAllGamePlatformsByGameId(int id);

    }
}
