using MotoApp.Entities;
using MotoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.DataProviders
{
    public class CarsProviderBasic //: ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;

        public CarsProviderBasic(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }



        public List<Car> FilterCars(decimal minPrice)
        {
            var cars = _carsRepository.GetAll();
            var list = new List<Car>();
            foreach (var car in cars)
            {
                if(car.ListPrice > minPrice)
                {
                    Console.WriteLine($"{car.ListPrice} ??? {minPrice}");
                    list.Add(car);
                }
            }
            return list;
        }


        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository.GetAll();
            List<string> colors = new List<string>();

            foreach (var car in cars)
            {
                if(!colors.Contains(car.Color))
                {
                    colors.Add(car.Color);
                }
            }
            return colors;
        }

        public Car GetMinimumPriceOfAllCars()
        {
            decimal minPrice = decimal.MaxValue;
            var cars = _carsRepository.GetAll();
            var carMin = new Car();
            foreach (var car in cars)
            {
                if(minPrice < car.ListPrice)
                {
                    //minPrice = car.ListPrice;
                    Console.WriteLine($"{minPrice} <?> {car.ListPrice}");
                }
                else
                {
                    Console.WriteLine($"{minPrice} <? ? ?> {car.ListPrice}");
                    minPrice = car.ListPrice;
                    carMin = car;
                }
            }

            return carMin;
        }

        public List<Car> GetSpecificColumn()
        {
            throw new NotImplementedException();
        }

        public decimal GetMinimumPriceOfAllCarsD()
        {
            throw new NotImplementedException();
        }

        public string AnonimousClass()
        {
            throw new NotImplementedException();
        }
    }
}
