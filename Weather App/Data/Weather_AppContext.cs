using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Weather_App.Models;

namespace Weather_App.Data
{
    public class Weather_AppContext : DbContext
    {
        public Weather_AppContext (DbContextOptions<Weather_AppContext> options)
            : base(options)
        {

        }

        public DbSet<Weather_App.Models.City> City { get; set; }
        public DbSet<Weather_App.Models.Forecast> Forecast { get; set; }

    }
}
