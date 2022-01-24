using Microsoft.EntityFrameworkCore;
using PFClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFClean.Infrastructure.Persistence.DataContext
{
    // This class allows us to define the objects
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

    }
}
