using Microsoft.Extensions.Logging;
using MauiApp1.Views;
using MauiApp1.ViewModels;

namespace MauiApp1
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

            // Singleton - Global static, it creates at once
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            // Transient - New instance every time it is requested
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient<NewGoalPage>();
            builder.Services.AddTransient<NewGoalViewModel>();

            // Register the Data Access Layer pairs
            builder.Services.AddSingleton<MauiApp1.DAL.IGoalRepository, MauiApp1.DAL.GoalRepository>();

            return builder.Build();
        }
    }
}
