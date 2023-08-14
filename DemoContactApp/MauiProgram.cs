using CommunityToolkit.Maui;
using DemoContactApp.Services;
using DemoContactApp.ViewModels;
using DemoContactApp.Views;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace DemoContactApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IContactService, ContactService>();

            builder.Services.AddTransient<AddContactViewModel>();
            builder.Services.AddTransient<AddContactPage>();

            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<HomePage>();

            

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
