using PFClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFClean.Infrastructure.Persistence.Data
{
    public static class CarData
    {

        public static List<Car> GetCars() {

            return new List<Car>()
            {
                
               // Insert data to avoid having to enter that data manually
               new Car(){ 
               
                   Brand = "Mercedes Benz",
                   CarModel = "AMG GT R PRO",
                   CarColor = "Gray and Green",
                   CarType = "Coupe",
                   HorsePower = 577,
                   EngineType = "V8 Twin Turbo"

               },
               new Car(){

                   Brand = "Ferrari",
                   CarModel = "SF90",
                   CarColor = "White",
                   CarType = "Coupe",
                   HorsePower = 769,
                   EngineType = "V8 Twin Turbocharged"

               },
               new Car(){

                   Brand = "Bugatti",
                   CarModel = "La Voiture Noire",
                   CarColor = "Black",
                   CarType = "Atlantic Coupe",
                   HorsePower = 1500,
                   EngineType = "W16"

               },
               new Car(){

                   Brand = "Toyota",
                   CarModel = "Camry",
                   CarColor = "Red",
                   CarType = "Coupe",
                   HorsePower = 203,
                   EngineType = "V4"

               },
               new Car(){

                   Brand = "Hyundai",
                   CarModel = "Sonata",
                   CarColor = "Red",
                   CarType = "Coupe",
                   HorsePower = 180,
                   EngineType = "V4"

               }

            }; 

        }

    }
}
