using MauiAppIA_Formation.Infrastructure;
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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //- ajout de la configuration de l'api config json
            builder.Configuration.AddApiConfigJson();
            // - ajout de la configuration de l'api config
            builder.Services.AddApiConfig(builder.Configuration);

            return builder.Build();
        }
    }
}
