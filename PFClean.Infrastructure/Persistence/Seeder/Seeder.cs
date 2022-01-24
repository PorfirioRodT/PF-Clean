using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFClean.Infrastructure.Persistence.Data;
using PFClean.Infrastructure.Persistence.DataContext;

namespace PFClean.Infrastructure.Persistence.Seeder
{
    //This class insert the data into the static list of Cars(the entity that we defined)
    public static class Seeder
    {
        public static async Task DataSeeder(DataContext.DataContext context) 
        {
            // if the table is empty then return nothing
            if (context.Cars.Any()) return;

            var car = CarData.GetCars();

            await context.Cars.AddRangeAsync(car);
            await context.SaveChangesAsync();

        }
    }
}
