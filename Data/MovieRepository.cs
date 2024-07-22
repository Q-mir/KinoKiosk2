using Domain;
using KinoKiosk.Model.Data;
using TransportLib.DTO;


namespace Data
{
    public class MovieRepository : IRepository
    {
        private AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            _context = context;
        }

        public bool AddMovie(MovieDTO obj)
        {
            if (Exist(obj.Title))
            {
                _context.Add(new Movie() { Title = obj.Title, Genre = obj.Genre });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<MovieDTO> GetAllMovies()
        {
            return [.. _context.Movies.Select(m => new MovieDTO()
            {
                Title = m.Title,
                Genre = m.Genre,
            })];
        }

        public List<MovieDTO> GetMovies(string searchText)
        {
            return [.. GetAllMovies().Where(m => m.Title.StartsWith(searchText))];
            
        }


        public bool Exist(string title)
        {
            return _context.Movies.Any(m => m.Title.Equals(title));
        }
    }
}
