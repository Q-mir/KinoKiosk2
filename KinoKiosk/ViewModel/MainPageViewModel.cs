using Data;
using Domain;
using KinoKiosk.Model.Data;
using KinoKiosk.Model.Movie;
using KinoKiosk.Services.Movie;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TransportLib.DTO;


namespace KinoKiosk
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        AppDbContext _appDbContext;
        private ObservableCollection<MovieModel> _movies;
        public ObservableCollection<MovieModel> Movies { get => _movies; set 
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            }
        } 

        private readonly IRepository _repository;  
        
        public ICommand SearchCommand { get; }
        public ICommand AddMovieCommand { get; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Actor { get; set; }

        private readonly IMovieService _movieService;

        public MainPageViewModel(IMovieService movieService)
        {
            ArgumentNullException.ThrowIfNull(movieService);
            _movieService = movieService;
            _appDbContext = new AppDbContext();
            _repository = new MovieRepository(_appDbContext);
            
            AddMovieCommand = new Command(AddMovie);
            SearchCommand = new Command(SearchAction);
            SearchAction();
        }

        private void AddMovie()
        {
            MovieModel movie = new MovieModel();
            movie.Title = Title;
            movie.Genre = Genre;
            _movieService.AddMovie(movie);
        }

        private void SearchAction()
        {
            string search = Title ?? Genre ?? string.Empty;
            Movies = [.._movieService.Search(search)];
        }
       


        //private void OnSearch()
        //{
        //    var query = _context.Movies.Include(m => m.MovieActors).ThenInclude(ma => ma.Actor).AsQueryable();
        //
        //    if (!string.IsNullOrEmpty(Title))
        //    {
        //        query = query.Where(m => m.Title.Contains(Title));
        //    }
        //
        //    if (!string.IsNullOrEmpty(Genre))
        //    {
        //        query = query.Where(m => m.Genre.Contains(Genre));
        //    }
        //
        //    if (!string.IsNullOrEmpty(Actor))
        //    {
        //        query = query.Where(m => m.MovieActors.Any(ma => ma.Actor.Name.Contains(Actor)));
        //    }
        //
        //    var result = query.ToList();
        //
        //    Movies.Clear();
        //    foreach (var movie in result)
        //    {
        //        Movies.Add(movie);
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
