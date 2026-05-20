using CityInfo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {

        public DbSet<City> cities { get; set; }

        public DbSet<PointOfInterest> { get; set; }

    }
}
