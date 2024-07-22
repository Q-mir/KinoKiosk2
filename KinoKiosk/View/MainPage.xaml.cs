using Data;
using KinoKiosk.Services.Movie;
namespace KinoKiosk
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(new MovieService());
        }
    }

}
