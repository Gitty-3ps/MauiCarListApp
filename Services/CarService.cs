using CarListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Services
{
    public class CarService
    {
        public List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car
                {
                    Id = 1, Make = "Honda", Model = "Fit", Vin = "123"
                },
                   new Car
                {
                    Id = 2, Make = "Toyota", Model = "Prado", Vin = "123"
                },
                   new Car
                {
                    Id = 3, Make = "Honda", Model = "Civic", Vin = "123"
                },
                   new Car
                {
                    Id = 4, Make = "Audi", Model = "AS", Vin = "123"
                },
                   new Car
                {
                    Id = 5, Make = "BMW", Model = "MJ", Vin = "123"
                },
                   new Car
                {
                    Id = 6, Make = "Nissan", Model = "Note", Vin = "123"
                },
                   new Car
                {
                    Id = 7, Make = "Ferrari", Model = "Spider", Vin = "123"
                }
            };
        }
    }
}
