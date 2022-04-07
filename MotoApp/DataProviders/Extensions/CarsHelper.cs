//using MotoApp.Entities;

namespace MotoApp.DataProviders.Extensions;

public static class CarsHelper
{
    public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color)
    {
        return query.Where(x => x.Color == color);
    }

    public static void ForeachThis(this IEnumerable<Car> cars)
    {
        Console.WriteLine("Uwaga drukuję");
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    public static void ForeachString(this IEnumerable<string> str)
    {
        foreach (var s in str)
            Console.WriteLine($"\t{s}");
    }
}

