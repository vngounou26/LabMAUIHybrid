using MauiBlazorApp.Pages;
using MauiBlazorApp.Services;
using MauiBlazorApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiBlazorApp
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
                    fonts.AddFont("OpenSans-Regular.ttf","OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddSingleton<IImageService,ImageService>();
            builder.Services.AddSingleton<ViewCapture>().AddSingleton<CaptureViewModel>();

            builder.Services.AddHttpClient<IImageService,ImageService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5066");
            });

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
