using KinoKiosk.Services.Movie;
using Microsoft.Extensions.Logging;

namespace KinoKiosk
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
    		builder.Logging.AddDebug();

            //VM
            //builder.Services.AddSingleton<MainPageViewModel>();
            //SER
            //builder.Services.AddSingleton<IMovieService, MovieService>();
#endif

            return builder.Build();
        }
    }
}
