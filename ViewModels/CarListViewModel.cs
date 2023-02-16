using CarListApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.ViewModels
{
    public partial class CarListViewModel : BaseViewModel
    {
        private readonly CarService carService;

        public CarListViewModel(CarService carService)
        {
            this.carService = carService;
        }
    }
}
