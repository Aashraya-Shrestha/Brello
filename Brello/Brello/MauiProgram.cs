using Microsoft.Extensions.Logging;
using Brello.Services;
using Microsoft.EntityFrameworkCore;

namespace Brello
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
                });

            // Add the DbContext to the services collection
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=brello.db"));

   
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<TransactionService>();
            builder.Services.AddSingleton<DebtService>();
         




            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
