using CommunityToolkit.Maui;
using MauiAppIA_Formation.Infrastructure.Extends;
using MauiAppIA_Formation.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiAppIA_Formation
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //- ajout de la configuration de l'api config json
            builder.Configuration.AddApiConfigJson();
            // - ajout de la configuration de l'api config
            builder.Services.AddApiConfig(builder.Configuration);

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // -- injection de dépendance de la page et du viewmodel
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();


            return builder.Build();
        }
    }
}
