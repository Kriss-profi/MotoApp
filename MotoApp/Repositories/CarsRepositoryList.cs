using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoApp;
using MotoApp.Repositories;

namespace MotoApp
{
    public class CarsRepositoryList
    {
        public readonly IRepository<Car> carsy;

        #region Carsy CREATE

        //public void GenerateCarsList()
        //{
        //    var cars = GenerateSampleCars();
        //    foreach (var car in cars)
        //    {
        //        _carsRepository.Add(car);
        //    }
        //}
        public void GenerateCarsList()
        {
            var cars = GenerateSampleCars();
            foreach (var car in cars)
            {
                carsy.Add(car);
            }
        }

        public static List<Car> GenerateSampleCars()
        {
            return new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Name = "Car1",
                    Color = "Black",
                    StandardCost = 1059.31M,
                    ListPrice = 1431.50M,
                    Type = "44",
                },
                new Car
                {
                    Id = 2,
                    Name = "Car2",
                    Color = "Black",
                    StandardCost = 1159.31M,
                    ListPrice = 1471.50M,
                    Type = "45",
                },
                new Car
                {
                    Id = 3,
                    Name = "Wózek3",
                    Color = "Blue",
                    StandardCost = 963.31M,
                    ListPrice = 1563.50M,
                    Type = "25",
                },
                new Car
                {
                    Id = 4,
                    Name = "Car4",
                    Color = "Red",
                    StandardCost = 1024.31M,
                    ListPrice = 1595.50M,
                    Type = "40",
                },
                new Car
                {
                    Id = 5,
                    Name = "Car5",
                    Color = "White",
                    StandardCost = 1054.31M,
                    ListPrice = 1435.50M,
                    Type = "15",
                },
                new Car
                {
                    Id = 6,
                    Name = "Bryka6",
                    Color = "Pink",
                    StandardCost = 859.31M,
                    ListPrice = 881.50M,
                    Type = "44",
                },
                new Car
                {
                    Id = 7,
                    Name = "Samochód7",
                    Color = "Black",
                    StandardCost = 1109.31M,
                    ListPrice = 1121.50M,
                    Type = "45",
                }

            };
        }
        #endregion
    }
}
