using CarListApp.Views;

namespace CarListApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage));
    }
}
