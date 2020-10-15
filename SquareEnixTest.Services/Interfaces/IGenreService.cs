using SquareEnixTest.Data.Models;
using SquareEnixTest.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareEnixTest.Services.Interfaces
{
    public interface IGenreService
    {
        IList<GenreVm> getAllGenres();
        Genre getGenreByName(string name);
        Genre getGenreById(int id);

        Genre getGenreObjByName(string name);
    }

}
