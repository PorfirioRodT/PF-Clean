using PFClean.Console.Entity;
using System.Net.Http.Headers;

namespace PFClean.Console
{
    class Progranm
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
            
        }

        private static bool MainMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("Choose an option:");
            System.Console.WriteLine("1) Create Car");
            System.Console.WriteLine("2) Remove Whitespace");
            System.Console.WriteLine("3) Exit");
            System.Console.Write("\r\nSelect an option: ");

            switch (System.Console.ReadLine())
            {
                case "1":
                    System.Console.Clear();
                    CreateAsync();
                    return true;
                case "2":
                    //RemoveWhitespace();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }

        }

        private static async Task CreateAsync()
        {
            Car car = new Car();

            System.Console.Write("Digite la marca del Carro: ");
            car.Brand = System.Console.ReadLine();

            System.Console.Write("Digite el modelo del carro: ");
            car.CarModel = System.Console.ReadLine();

            System.Console.Write("Digite el color del carro: ");
            car.CarColor = System.Console.ReadLine();

            System.Console.Write("Digite el tipo del carro: ");
            car.CarType = System.Console.ReadLine();

            System.Console.Write("Digite los caballos de fuerza del carro: ");
            car.HorsePower = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite el tipo de motor del carro: ");
            car.EngineType = System.Console.ReadLine();

            var url = await CarClient.CreateCar(car);
        }
    }
}