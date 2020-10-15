using SquareEnixTest.Data.Models;
using SquareEnixTest.Data.ViewModel;
using SquareEnixTest.Services.Interfaces;
using SquareEnixTest.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SquareEnixTest.Services
{
    public class GenreService: IGenreService
    {
        private GenreRepository _genreRepository;
        public GenreService(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IList<GenreVm> getAllGenres()
        {
            return _genreRepository.GetAll(x => x != null).Select(x => new GenreVm
            {
                Id = x.Id.ToString(),
                Name = x.Name

            }).ToList();
        }

        public Genre getGenreByName(string name)
        {
            return _genreRepository.GetAll(x => x.Name == name).SingleOrDefault();
        }

        public Genre getGenreById(int id)
        {
            return _genreRepository.GetAll(x => x.Id == id).SingleOrDefault();
        }

        public Genre getGenreObjByName(string name)
        {
            return _genreRepository.GetAll(x => x.Name == name).FirstOrDefault();
        }
    }
}
