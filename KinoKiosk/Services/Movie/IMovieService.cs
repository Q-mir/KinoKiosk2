using KinoKiosk.Model.Movie;
using TransportLib.DTO;

namespace KinoKiosk.Services.Movie
{
    public interface IMovieService
    {
        List<MovieModel> Search();
        List<MovieModel> Search(string searchText);
        void AddMovie(MovieModel movie);
    }
}
