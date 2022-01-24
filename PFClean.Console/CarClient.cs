using PFClean.Console.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PFClean.Console
{
    internal class CarClient
    {

        static HttpClient client = new HttpClient();

        public static async Task<Car> GetCars()
        {

            Car car = null;
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000");
            if (response.IsSuccessStatusCode) 
            {
                car = await response.Content.ReadAsAsync<Car>();
            }

            return car;

        }

        public static async Task<Car> GetCarByID(Guid id)
        {
            Car? car = null;
            HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:5000");
            if (responseMessage.IsSuccessStatusCode && id == car.Id)
            {
                car = await responseMessage.Content.ReadAsAsync<Car>();
            }

            return car;
        }

        public static async Task<Uri> CreateCar(Car car)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(
                "api/v1/Cars", car);
            responseMessage.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return responseMessage.Headers.Location;
        }


        public static async Task<Car> UpdateCar(Car car)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(
                $"api/v1/Cars/{car.Id}", car);
            responseMessage.EnsureSuccessStatusCode();

            car = await responseMessage.Content.ReadAsAsync<Car>();
            return car;
        }

        public static async Task<HttpStatusCode> DeleteCar(Guid id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(
                $"api/v1/Cars/{id}");
            return responseMessage.StatusCode;
        }

        public static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new car
                Car car = new Car
                {
                    Brand = "Audi",
                    CarModel = "Q5",
                    CarColor = "Green",
                    CarType = "SUV",
                    HorsePower = 400,
                    EngineType = "V6"
                };

                var url = await CreateCar(car);
                System.Console.WriteLine($"Created at {url}");

                // Get the cars
                car = await GetCars();
                await GetCars();

                // Update the car
                System.Console.WriteLine("Updating horsepower...");
                car.HorsePower = 499;
                await UpdateCar(car);

                // Get the updated car
                car = await GetCarByID(car.Id);
                GetCarByID(car.Id);

                // Delete the car
                var statusCode = await DeleteCar(car.Id);
                System.Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            System.Console.ReadLine();
        }

    }
}
