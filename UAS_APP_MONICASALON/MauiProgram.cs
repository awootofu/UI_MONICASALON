using Microsoft.Extensions.Logging;
using UAS_APP_MONICASALON.Controls;
using UraniumUI;
using UraniumUI.Icons.MaterialSymbols;
using UraniumUI.Material.Handlers;

namespace UAS_APP_MONICASALON
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureMauiHandlers(handlers =>
                {
                    // The shim derives from UraniumUI's ButtonView, so it needs the
                    // same handler to receive pointer/tap input.
                    handlers.AddHandler<ButtonView, ButtonViewHandler>();
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddMaterialSymbolsFonts();
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
