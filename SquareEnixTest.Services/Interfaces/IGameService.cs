using SquareEnixTest.Data;
using SquareEnixTest.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareEnixTest.Services.Interfaces
{
    public interface IGameService
    {
        Game AddGame(Game game);
        Game GetGameById(int Id);

        IList<Game> GetAllGamesAToZ();

        bool DeleteGame(int id);
        
        Game UpdateGame(Game game);
    }
}
