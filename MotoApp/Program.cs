using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.DataProviders;
using MotoApp.DataProviders.Extensions;
using MotoApp.Entities;
using MotoApp.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IApp3, App3>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();

var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetService<IApp>();
var servicesProvider3 = services.BuildServiceProvider();
var app3 = servicesProvider3.GetService<IApp3>();
//app.Run();
//app.By();
int x = 1;
app.GenerateCarsList();
//app3.GenerateCarsList();


do
{
    app.Menu();
    x = app.Cyferka(); 
    switch (x)
    {
        case 0:
            {
                Console.Clear();
                app.By();
                Console.ReadKey();
                break;
            }
        case 1:
            {
                Console.Clear();
                app.RunEmployee();
                Console.ReadKey();
                break;
            }
        case 2:
            {
                Console.Clear();
                app.RunCar();
                Console.ReadKey();
                break;
            }
        case 3:
            {
                Console.Clear();
                app3.TabCars();
                //Console.ReadKey();
                break;
            }
        case 4:
            {
                Console.Clear();
                app.RunCarsPrice();
                //Console.ReadKey();
                break;
            }
        case 5:
            {
                Console.Clear();
                app.GetColorsCars();
                Console.ReadKey();
                break;
            }
        case 6:
            {
                Console.Clear();
                app.Anonim();
                Console.ReadKey();
                break;
            }
        default:
            {
                Console.WriteLine("Słabo dawaj jeszcze raz");
                break;
            }
    }
} while ( x != 0);

//int Menu()
//{
//    Console.Clear();
//    Console.WriteLine("\tMenu");
//    Console.WriteLine("\t[1] - Employee");
//    Console.WriteLine("\t[2] - Cars");
//    Console.WriteLine("\t[3] - Cars min. Price 1000");
//    Console.WriteLine("\t[4] - Car min. Price");
//    Console.WriteLine("\t[5] - Car Colors");
//    Console.WriteLine("\t-\t-\t-");
//    Console.WriteLine("\t[0] - EXIT");
//    Console.Write("Dawaj cyferkę: ");
//    string line = Console.ReadLine();
//    bool result = int.TryParse(line, out int x);
//    if (result == false) return x = 0;
//    else return x;
//}



//using MotoApp.Repositories;
//using MotoApp.Entities;
//using MotoApp.Data;



////var employeeRepository = new GenericRepository<Employee>();
////employeeRepository.Add(new Employee { FirstName = "Krzysiek"});
////employeeRepository.Add(new Employee { FirstName = "Jakub"});
////employeeRepository.Add(new Employee { FirstName = "Kacper"});
////employeeRepository.Save();


////employeeRepository.Add(new Employee { FirstName = "Krzysiek" });
////employeeRepository.Add(new Employee { FirstName = "Jakub" });
////employeeRepository.Add(new Employee { FirstName = "Kacper" });
////employeeRepository.Save();

////GetEmployeeById(employeeRepository);

////static void GetEmployeeById(IRepository<IEntity> employeeRepository)
////{
////    var emp = employeeRepository.GetById(2);
////    Console.WriteLine(emp.ToString());

////}


//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
//AddEmployees(employeeRepository);
//AddManager(employeeRepository);
//WriteAllToConsole(employeeRepository);

//static void AddEmployees(IRepository<Employee> employeeRepository)
//{
//    employeeRepository.Add(new Employee { FirstName = "Zenek" });
//    employeeRepository.Add(new Employee { FirstName = "Stefan" });
//    employeeRepository.Add(new Employee { FirstName = "Bronek" });
//    employeeRepository.Save();
//}

//static void AddManager(IWriteRepository<Manager> managerRepository)
//{

//    managerRepository.Add(new Manager { FirstName = "Krzysiek" });
//    managerRepository.Add(new Manager { FirstName = "Jakub" });
//    managerRepository.Add(new Manager { FirstName = "Kacper" });
//    managerRepository.Save();
//}

//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}