using MotoApp.DataProviders;
using MotoApp.DataProviders.Extensions;
using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IRepository<Car> _carsRepository;
        private readonly ICarsProvider _carsProvider;


        // Wstrzykiwanie zależności
        public App(IRepository<Employee> employeesRepository, IRepository<Car> carsRepository, ICarsProvider carsProvider)
        {
            _employeesRepository = employeesRepository;
            _carsRepository = carsRepository;
            _carsProvider = carsProvider;
        }
        #region MENU
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("\tMenu");
            Console.WriteLine("\t[1] - Employee");
            Console.WriteLine("\t[2] - All Cars");
            Console.WriteLine("\t[3] - Cars FIRST SINGLE and LAST");
            Console.WriteLine("\t[4] - Car min. Price");
            Console.WriteLine("\t[5] - Car Colors");
            Console.WriteLine("\t[6] - Car Colors Unique");
            Console.WriteLine("\t-\t-\t-");
            Console.WriteLine("\t[0] - EXIT");
        }

        public void SubMenuCars()
        {
            Console.Clear();
            Console.WriteLine("\tMenu Cars");
            Console.WriteLine("\t[1] - All Cars");
            Console.WriteLine("\t[2] - Cars OrderBy Name");
            Console.WriteLine("\t[3] - Cars OrderBy Name - Descending");
            Console.WriteLine("\t[4] - Cars OrderBy Color And Name");
            Console.WriteLine("\t[5] - Cars OrderBy Color And Name - Descending");
            Console.WriteLine("\t[6] - Car Prefix");
            Console.WriteLine("\t[7] - Car Prefix And > Cost");
            Console.WriteLine("\t[8] - Car Colors ???");
            Console.WriteLine("\t-\t-\t-");
            Console.WriteLine("\t[0] - EXIT");
        }

        public void TabCars()
        {
            int x;

            do
            {
                SubMenuCars();
                x = Cyferka();
                switch (x)
                {
                    case 0:
                        {
                            //Console.Clear();
                            //Console.ReadKey();
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            RunCar();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            CarsOrderByName();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            CarsOrderByNameDescending();
                            Console.WriteLine(x);
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            CarsOrderByColorAndName();
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            CarsOrderByColorAndNameDescending();
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {   //Prefix
                            Console.Clear();
                            CarsWithPrefix();
                            Console.ReadKey();
                            break;
                        }
                    case 7:
                        {   //Prefix and Cost
                            Console.Clear();
                            CarsWithPrefixAndCost();
                            Console.ReadKey();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            CarsColor();
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Słabo dawaj jeszcze raz");
                            break;
                        }
                }
            } while (x != 0);

        }

        public int Cyferka()
        {
            Console.Write("Dawaj cyferkę: ");
            string line = Console.ReadLine()!;
            bool result = int.TryParse(line, out int x);
            if (result == false) return x = 1;
            else return x;
        }

#endregion

        #region EMPLOYEE
        public void RunEmployee()
        {
            Console.WriteLine("I'm here in Run() method.");

            var employees = new[]
            {
                new Employee { FirstName = "Krzysiek" },
                new Employee { FirstName = "Jakub" },
                new Employee { FirstName = "Kacper" }
            };

            foreach (var employee in employees)
            {
                _employeesRepository.Add(employee);
            }

            _employeesRepository.Save();

            //var items = _employeesRepository.GetAll();
            //foreach (var item in items)
            //{
            //    Console.WriteLine(item);
            //}
        }
        #endregion

        #region CARS
        public void RunCarsy()
        {
            
        }

        public void RunCar() 
        {
            var cars = _carsProvider.GetAllCars();
            cars.ForeachThis();
            
        }
        private void CarsOrderByName() 
        {
            var cars = _carsProvider.OrderByName();
            cars.ForeachThis();
        }
        private void CarsOrderByNameDescending()
        {
            var cars = _carsProvider.OrderByNameDescending();
            cars.ForeachThis();
        }

        private void CarsOrderByColorAndName()
        {
            var cars = _carsProvider.OrderByColorAndName();
            cars.ForeachThis();
        }

        private void CarsOrderByColorAndNameDescending()
        {
            var cars = _carsProvider.OrderByColorAndNameDescending();
            cars.ForeachThis();
        }
        #endregion

        #region CARS SELECT

        private void CarsColor()
        {
            Console.Write("Where Color?: ");
            string str = Console.ReadLine();
            var cars = _carsProvider.WhereColorIs(str);
            cars.ForeachThis();
        }

        private void CarsWithPrefix()
        {
            Console.Write("Where Prefix?: ");
            string str = Console.ReadLine();
            var cars = _carsProvider.WhereStartsWith(str);
            cars.ForeachThis();
        }

        private void CarsWithPrefixAndCost()
        {
            Console.Write("Where Prefix?: ");
            string str = Console.ReadLine();
            Console.Write("Where Cost?: ");
            decimal cost = Convert.ToDecimal(Console.ReadLine());
            var cars = _carsProvider.WhereStartsWithAndCostIsGreatherThan(str, cost);
            cars.ForeachThis();
        }


        #endregion

        #region WHERE
        public void RunCarsPrice()
        {

            // Cars
            int i = 1;
            Console.WriteLine();
            Console.Write("Podaj kwotę od której pokazać samochody: ");
            var temp = Console.ReadLine();
            Console.WriteLine(temp);
            decimal price = Convert.ToDecimal(temp);
            Console.WriteLine(price);
            Console.ReadKey();
            foreach (var car in _carsProvider.FilterCars(price))
            {
                Console.WriteLine($"\t{i}. {car}");
                i++;
            }
        }

        public void GetColorsCars()
        {
            int i = 1;
            foreach(var color in _carsProvider.GetUniqueCarColors())
            {
                Console.WriteLine($"\t{i}. {color}");
                i++;
            }
        }

        public void Anonim()
        {
            string anonim = _carsProvider.AnonimousClass();
            Console.WriteLine(anonim);
        }
        #endregion

        #region Carsy CREATE

        public void GenerateCarsList()
        {
            var cars = GenerateSampleCars();
            foreach (var car in cars)
            {
                _carsRepository.Add(car);
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

        #region START END

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void By()
        {
            Console.WriteLine(  " BY BY.");
        }
        #endregion

        #region HELPERS
        //private void ForeachThis(List<Car> cars)
        //{
        //    Console.WriteLine("\n");
        //    foreach (var car in cars)
        //    {
        //        Console.WriteLine(car);
        //    }
        //}
        #endregion

    }
}
