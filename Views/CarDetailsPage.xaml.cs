using CarListApp.ViewModels;

namespace CarListApp.Views;

public partial class CarDetailsPage : ContentPage
{
    public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = carDetailsViewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        // Do fanciness 

        base.OnNavigatedTo(args);
    }

        
}