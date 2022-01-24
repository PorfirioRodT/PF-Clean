using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFClean.Contracts.Services;
using PFClean.Web.Models;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PFClean.Web.Controllers
{
    public class CarController : Controller
    {
        // GET: CarController
        Uri baseAdress = new Uri("http://localhost:5000/api/v1");
        HttpClient client;

        public CarController() 
        { 
            client = new HttpClient();
            client.BaseAddress = baseAdress;
        }
        public ActionResult GetAllCars()
        {

            List<CarViewModel> models = new List<CarViewModel>();
            //fetching users
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/Cars").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                // Converting the json to show it as a page list of cars
                models = JsonConvert.DeserializeObject<List<CarViewModel>>(data);

            }

            return View(models);

            /*try
            {
                
                return View();
            }
            catch (Exception)
            {
                throw;
            }*/
        }

        public ActionResult CreateCar() 
        { 
            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(CarViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress + "/Cars", content).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCars");
            }

            return View();
        }

        public ActionResult EditCar(Guid id)
        {
            CarViewModel models = new CarViewModel();
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/Cars/"+id).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                models = JsonConvert.DeserializeObject<CarViewModel>(data);

            }

            return View(/*"CreateCar",*/ models);
        }

        [HttpPut]
        public ActionResult EditCar(CarViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress + "/Cars/"+model.Id, content).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCars");
            }

            return View(/*"CreateCar",*/ model);
        }

        public ActionResult DeleteCar(Guid id)
        {
            CarViewModel models = new CarViewModel();
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/Cars/" + id).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                models = JsonConvert.DeserializeObject<CarViewModel>(data);

            }

            return View(/*"CreateCar",*/ models);
        }

        [HttpDelete]
        public ActionResult DeleteCar(CarViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.DeleteAsync(client.BaseAddress + "/Cars/" + model.Id).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCars");
            }

            return View(/*"CreateCar",*/ model);
        }

    }
}
