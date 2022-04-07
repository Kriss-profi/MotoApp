using MotoApp.Entities;
using MotoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoApp.DataProviders.Extensions;

namespace MotoApp.DataProviders
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;

        public CarsProvider(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }


        #region SELECT
        public List<Car> GetAllCars()
        {
            return (List<Car>)_carsRepository.GetAll();
        }

        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository.GetAll();
            var colors = cars.Select(car => car.Color).Distinct().ToList();
            return colors;
            //var cars = _carsRepository.GetAll();
            //var colors = cars.Select(car => car.Color).Distinct().ToList();
            //return colors;
        }
        public decimal GetMinimumPriceOfAllCars()
        {
            var cars = _carsRepository.GetAll();
            var car = cars.Select(x => x.ListPrice).Min();
            return car;
        }

        public string AnonimousClass()
        {
            var cars = _carsRepository.GetAll();

            var list = cars.Select(car => new Car
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type
            }).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var car in list)
            {
                sb.AppendLine($"Product ID: {car.Id}");
                sb.AppendLine($"    Product Name: {car.Name}");
                sb.AppendLine($"    Product Type: {car.Type}");
            }
            return sb.ToString();
        }

        public decimal GetMinimumPriceOfAllCarsD()
        {
            var cars = _carsRepository.GetAll();
            return cars.Select(x => x.ListPrice).Min();
        }

        public List<Car> GetSpecificColumn()
        {
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new Car
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type,
            }).ToList();

            return list;
        }
        #endregion

        #region ORDER BY

        public List<Car> OrderByName()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.Name).ToList();
        }
        public List<Car> OrderByNameDescending()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderByDescending(x => x.Name).ToList();
        }
        public List<Car> OrderByColorAndName()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Color)
                .ToList();
        }
        public List<Car> OrderByColorAndNameDescending()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderByDescending(x => x.Name)
                .ThenByDescending(x => x.Color)
                .ToList();
        }
        #endregion

        #region WHERE

        public List<Car> FilterCars(decimal minPrice)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.ListPrice > minPrice).ToList();
        }

        public List<Car> WhereStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            //cars.ForeachThis();
            return cars.Where(x => x.Name.StartsWith(prefix)).ToList();
        }
        public List<Car> WhereStartsWithAndCostIsGreatherThan(string prefix, decimal cost)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix) && x.StandardCost > cost).ToList();
        }
        public List<Car> WhereColorIs(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.ByColor(color).ToList();
        }

        #endregion

        #region FIRST, LAST, SINGLE

        public Car FirstByColor(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.First(x => x.Color == color);
        }
        public Car? FirstOrDefaultByColor(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.FirstOrDefault(x => x.Color == color);
        }
        public Car FirstOrDefaultByColorWithDefault(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.FirstOrDefault(x=>x.Color == color, new Car { Id = -1, Name = "NOT FOUND YOUR BRYKI"});
        }
        public Car LastByColor(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.LastOrDefault(x => x.Color == color, new Car { Id = -1, Name = "Jak dobrze zaplacisz to Ci przemalujemy"});
        }
        public Car SingleById(int id)
        {
            var cars = _carsRepository.GetAll();
            return cars.SingleOrDefault(x => x.Id == id, new Car { Id = -1, Name = "Sorry ale przegiołeś z tą ilością"});
        }
        #endregion

        #region TAKE

        // TAKE
        public List<Car> TakeCars(int howMany)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .Take(howMany)  // ilość elementów do pobrania
                .ToList();
        }

        public List<Car> TakeCars(Range range)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x=>x.Name) //  sortowanie
                .Take(range)    // Zakres z jakiego pobieramy np: 2..7
                .ToList();
        }

        public List<Car> TakeCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .TakeWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        #endregion

        #region SKIP
        // SKIP

        public List<Car> SkipCars(int howMany)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .Skip(howMany)
                .ToList();
        }

        public List<Car> SkipCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .SkipWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<string> DistinctAllColors()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .Select(x => x.Color)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public List<Car> DistinctByColors()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .DistinctBy(x => x.Color)
                .OrderBy(c => c.Color)
                .ToList();
        }

        public List<Car[]> ChunkCars(int size)
        {
            var cars = _carsRepository.GetAll();
            return cars.Chunk(size).ToList();
        }

        #endregion
    }
}
