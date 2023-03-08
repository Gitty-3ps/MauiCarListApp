using CarListApp.Services;
using CarListApp.ViewModels;
using CarListApp.Views;

namespace CarListApp;

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

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "cars.db3");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<CarService>(s, dbPath));

        builder.Services.AddSingleton<CarListViewModel>();
		builder.Services.AddSingleton<CarDetailsViewModel>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<CarDetailsPage>();

        return builder.Build();
	}
}
