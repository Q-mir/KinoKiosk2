using Data;
using KinoKiosk.Model.Movie;
using KinoKiosk.Services.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLib.DTO;

namespace KinoKiosk.Services.Movie
{
    internal class MovieService : IMovieService
    {
        private readonly MovieRepository _movieRepository;

        public MovieService()
        {
            _movieRepository = new MovieRepository(new Model.Data.AppDbContext());
        }

        public void AddMovie(MovieModel movie)
        {
            _movieRepository.AddMovie(new MovieDTO { Genre = movie.Genre, Title = movie.Title });
        }

        public List<MovieModel> Search(string searchText)
        {
            return [.. _movieRepository.GetAllMovies().Select(mDto => new MovieModel() 
            {
                Title = mDto.Title,
                Genre = mDto.Genre,
            }).Where(mDto => mDto.Title.StartsWith(searchText))];
        }

        public List<MovieModel> Search()
        {
            return [.. _movieRepository.GetAllMovies().Select(mDto => new MovieModel()
            {
                Title = mDto.Title,
                Genre = mDto.Genre,
            })];
        }
    }
}
