using MauiBlazorApp.Pages;
using MauiBlazorApp.Services;
using MauiBlazorApp.ViewModels;
using Microsoft.Extensions.Logging;
using SharedLibrary.Services;

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
            builder.Services.AddSingleton<ISharedImageService, SharedImageService>();
            builder.Services.AddSingleton<ViewCapture>().AddSingleton<CaptureViewModel>();

            builder.Services.AddSingleton(sp =>new HttpClient
            {
#if ANDROID
                BaseAddress = new Uri("http://10.0.2.2:5066")
#else

                BaseAddress = new Uri("http://localhost:5066")
#endif
            });

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
