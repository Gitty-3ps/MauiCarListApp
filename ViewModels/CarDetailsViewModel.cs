using CarListApp.Models;
using CarListApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarListApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class CarDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly CarApiService carApiService;

        public CarDetailsViewModel(CarApiService carApiService)
        {
            this.carApiService = carApiService;
        }

        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        [ObservableProperty]
        Car car;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
        }

        public async Task GetCarData()
        {
            if (accessType == NetworkAccess.Internet)
            {
                Car = await carApiService.GetCar(Id);
            }
            else
            {
                Car = App.CarDatabaseService.GetCar(Id);
            }
        }
    }
}