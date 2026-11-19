using Microsoft.Extensions.Logging;
using Masrwof.Data;
using Microsoft.EntityFrameworkCore;
using Masrwof.Interfaces;
using Masrwof.Service;
namespace Masrwof
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Masrwof.db");
            builder.Services.AddDbContext<AppDpContext>(options =>
            {
                options.UseSqlite($"Data Source={dbPath}");
            }, ServiceLifetime.Scoped);


            builder.Services.AddScoped<IExpenseService, ExpenseService>();
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var Context = scope.ServiceProvider.GetRequiredService<AppDpContext>();
                Context.Database.EnsureCreated();
            }
            return app;
        }
    }
}
