using CarListApp.ViewModels;

namespace CarListApp;



public partial class MainPage : ContentPage
{
	public MainPage(CarListViewModel carListViewModel)
	{
        InitializeComponent();
        BindingContext = carListViewModel;
    }
}

