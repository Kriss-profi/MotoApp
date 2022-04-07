using MotoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.DataProviders
{
    public interface ICarsProvider
    {
        // SELECT
        List<Car> GetAllCars();
        List<Car> FilterCars(decimal minPrice);

        List<string> GetUniqueCarColors();

        decimal GetMinimumPriceOfAllCars();
        decimal GetMinimumPriceOfAllCarsD();

        List<Car> GetSpecificColumn();

        string AnonimousClass();

        // ORDER BY
        List<Car> OrderByName();
        List<Car> OrderByNameDescending();
        List<Car> OrderByColorAndName();
        List<Car> OrderByColorAndNameDescending();

        // WHERE
        List<Car> WhereStartsWith(string prefix);
        List<Car> WhereStartsWithAndCostIsGreatherThan(string prefix, decimal cost);
        List<Car> WhereColorIs(string color);

        // FIRST LAST SINGLE
        Car FirstByColor(string color);
        Car? FirstOrDefaultByColor(string color);
        Car FirstOrDefaultByColorWithDefault(string color);
        Car LastByColor(string color);
        Car SingleById(int id);

        // TAKE
        List<Car> TakeCars(int howMany);
        List<Car> TakeCars(Range range);
        List<Car> TakeCarsWhileNameStartsWith(string prefix);

        // SKIP
        List<Car> SkipCars(int howMany);
        List<Car> SkipCarsWhileNameStartsWith(string prefix);

        // DISTINCT
        List<string> DistinctAllColors();
        List<Car> DistinctByColors();

        // CHUNK
        List<Car[]> ChunkCars(int size);
    }
}
