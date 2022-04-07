using MotoApp.DataProviders;
using MotoApp.DataProviders.Extensions;
using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp
{
    public class App3 : IApp3
    {
        //private readonly IRepository<Car> _carsRepository;
        private readonly ICarsProvider _carsProvider;

        public App3(IRepository<Car> carsReepository, ICarsProvider carsProvider)
        {
            //_carsRepository = carsReepository;
            _carsProvider = carsProvider;
        }

        public void CarFirstByColor()
        {
            var car = _carsProvider.FirstByColor("Red");
            Console.WriteLine(car);
        }

        public void CarFirstOrDefaultByColor()
        {
            var car = _carsProvider.FirstOrDefaultByColor("Blue");
            Console.WriteLine(car);
        }

        public void CarFirstOrDefaultByColorWithDefault()
        {
            var car = _carsProvider.FirstOrDefaultByColorWithDefault("Purple");
            Console.WriteLine(car);
        }

        public void CarLastByColor()
        {
            var car = _carsProvider.LastByColor("Black");
            Console.WriteLine(car);
        }

        public void CarSingleById()
        {
            var car = _carsProvider.SingleById(12);
            Console.WriteLine(car);
        }

        // TAKE
        public void CarsTakeHowMany()
        {
            var cars = _carsProvider.TakeCars(5);
            cars.ForeachThis();
        }

        public void CarsTakeRange()
        {
            var cars = _carsProvider.TakeCars(2..5);
            cars.ForeachThis();
        }

        public void CarsTakeWithPrefix()
        {            
            var cars = _carsProvider.TakeCarsWhileNameStartsWith("C");
            cars.ForeachThis();
        }

        // SKIP

        public void CarsSkipHowMany()
        {
            var cars = _carsProvider.SkipCars(4);
            cars.ForeachThis();
        }

        public void CarsSkipWhileNameStartsWithPrefix()
        {
            var cars = _carsProvider.SkipCarsWhileNameStartsWith("C");
            cars.ForeachThis();
        }


        // DISTINCT

        public void CarsDistinctAllColors()
        {   
            var colors = _carsProvider.DistinctAllColors();
            colors.ForeachString();
        }

        public void CarsDistinctByColows()
        {
            var cars = _carsProvider.DistinctByColors();
            cars.ForeachThis(); 
        }


        public List<Car[]> CarsChunk(int i)
        {
            var cars = _carsProvider.ChunkCars(i);
            foreach (var car in cars)
            {
                //Console.WriteLine(car);
                for (int j = 0; j < car.Length; j++)
                {
                    Console.WriteLine($"ID:{car[j].Id} Color: {car[j].Color} Type: {car[j].Type} Cost{car[j].StandardCost} Price: {car[j].ListPrice}");
                }
                Console.WriteLine();
                Console.ReadKey();
            }
            return cars;
        }

        #region MENU

        public void Menu3Cars()
        {
            Console.Clear();
            Console.WriteLine("\n\tMenu FIRST, LAST or SINGE\n");
            Console.WriteLine("\t[1] - First By Color");
            Console.WriteLine("\t[2] - First Or Default By Color");
            Console.WriteLine("\t[3] - First or default by color with default");
            Console.WriteLine("\t[4] - Last by color");
            Console.WriteLine("\t[5] - Single by Id");
            Console.WriteLine("\t[6] - Take first 5 Cars");
            Console.WriteLine("\t[7] - Take Range 2..5 Cars");
            Console.WriteLine("\t[8] - Take Cars with prefix Ca...");
            Console.WriteLine("\t[9] - Skip 4 Cars ");
            Console.WriteLine("\t[10]- Skip Cars with prefix C...");
            Console.WriteLine("\t[11]- Distinct all colors from Cars");
            Console.WriteLine("\t[12]- Distinct Cars by colors");
            Console.WriteLine("\t[13]- Chunk Cars");
            Console.WriteLine("\t-\t-\t-");
            Console.WriteLine("\t[0] - EXIT");
        }
        public void TabCars()
        {
            int x;

            do
            {
                Menu3Cars();
                x = Cyferka();
                switch (x)
                {
                    case 0:
                        {
                            //Console.Clear();
                            //Console.ReadKey();
                            x = 99;
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            CarFirstByColor();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            CarFirstOrDefaultByColor();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            CarFirstOrDefaultByColorWithDefault();
                            Console.WriteLine(x);
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            CarLastByColor();
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            CarSingleById();
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            CarsTakeHowMany();
                            Console.ReadKey();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            CarsTakeRange();
                            Console.ReadKey();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            CarsTakeWithPrefix();
                            Console.ReadKey();
                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            CarsSkipHowMany();
                            Console.ReadKey();
                            break;
                        }
                    case 10:
                        {
                            Console.Clear();
                            CarsSkipWhileNameStartsWithPrefix();
                            Console.ReadKey();
                            break;
                        }
                    case 11:
                        {
                            Console.Clear();
                            CarsDistinctAllColors();
                            Console.ReadKey();
                            break;
                        }
                    case 12:
                        {
                            Console.Clear();
                            CarsDistinctByColows();
                            Console.ReadKey();
                            break;
                        }
                    case 13:
                        {
                            Console.Clear();
                            Console.Write("Podaj ilość elementów na stronę: ");
                            int i = int.Parse(Console.ReadLine());
                            CarsChunk(i);
                            //Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Słabo dawaj jeszcze raz");
                            break;
                        }
                }
            } while (x != 99);

        }


        private static int Cyferka()
        {
            Console.Write("Dawaj cyferkę: ");
            string line = Console.ReadLine()!;
            bool result = int.TryParse(line, out int x);
            if (result == false) return x = 100;
            else return x;
        }

        #endregion

        #region Carsy CREATE

        //public void GenerateCarsList()
        //{
        //    var cars = GenerateSampleCars();
        //    foreach (var car in cars)
        //    {
        //        _carsRepository.Add(car);
        //    }
        //}


        //public static List<Car> GenerateSampleCars()
        //{
        //    return new List<Car>
        //    {
        //        new Car
        //        {
        //            Id = 1,
        //            Name = "Car1",
        //            Color = "Black",
        //            StandardCost = 1059.31M,
        //            ListPrice = 1431.50M,
        //            Type = "44",
        //        },
        //        new Car
        //        {
        //            Id = 2,
        //            Name = "Car2",
        //            Color = "Black",
        //            StandardCost = 1159.31M,
        //            ListPrice = 1471.50M,
        //            Type = "45",
        //        },
        //        new Car
        //        {
        //            Id = 3,
        //            Name = "Wózek3",
        //            Color = "Blue",
        //            StandardCost = 963.31M,
        //            ListPrice = 1563.50M,
        //            Type = "25",
        //        },
        //        new Car
        //        {
        //            Id = 4,
        //            Name = "Car4",
        //            Color = "Red",
        //            StandardCost = 1024.31M,
        //            ListPrice = 1595.50M,
        //            Type = "40",
        //        },
        //        new Car
        //        {
        //            Id = 5,
        //            Name = "Car5",
        //            Color = "White",
        //            StandardCost = 1054.31M,
        //            ListPrice = 1435.50M,
        //            Type = "15",
        //        },
        //        new Car
        //        {
        //            Id = 6,
        //            Name = "Bryka6",
        //            Color = "Pink",
        //            StandardCost = 859.31M,
        //            ListPrice = 881.50M,
        //            Type = "44",
        //        },
        //        new Car
        //        {
        //            Id = 7,
        //            Name = "Samochód7",
        //            Color = "Black",
        //            StandardCost = 1109.31M,
        //            ListPrice = 1121.50M,
        //            Type = "45",
        //        }

        //    };
       // }



        #endregion
    }
}
