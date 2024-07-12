using KinoKiosk.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinoKiosk
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _context;
        public ObservableCollection<Movie> Movies { get; set; }
        public ICommand SearchCommand { get; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Actor { get; set; }

        public MainPageViewModel()
        {
            _context = new AppDbContext();
            Movies = new ObservableCollection<Movie>();
            SearchCommand = new Command(OnSearch);
        }

        private void OnSearch()
        {
            var query = _context.Movies.Include(m => m.MovieActors).ThenInclude(ma => ma.Actor).AsQueryable();

            if (!string.IsNullOrEmpty(Title))
            {
                query = query.Where(m => m.Title.Contains(Title));
            }

            if (!string.IsNullOrEmpty(Genre))
            {
                query = query.Where(m => m.Genre.Contains(Genre));
            }

            if (!string.IsNullOrEmpty(Actor))
            {
                query = query.Where(m => m.MovieActors.Any(ma => ma.Actor.Name.Contains(Actor)));
            }

            var result = query.ToList();

            Movies.Clear();
            foreach (var movie in result)
            {
                Movies.Add(movie);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
