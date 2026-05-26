using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<City>()
                .HasData(

                    new City("New York City")
                    {
                        Id = 1,
                        Description = "The one with that big park."
                    },

                    new City("Antwerp")
                    {
                        Id = 2,
                        Description = "IDK"
                    },

                    new City("Paris")
                    {
                        Id = 3,
                        Description = "The one with that big tower"
                    }
                );

            modelBuilder.Entity<PointOfInterest>()
                .HasData(

                    new PointOfInterest("Central Park")
                    {
                        Id = 1,
                        CityId = 1,
                        Description = "The most visited urban park in the USA."
                    },

                    new PointOfInterest("Empire State Building")
                    {
                        Id = 2,
                        CityId = 1,
                        Description = "A 102-story skyscraper located in Midtown Manhattam."
                    },

                    new PointOfInterest("Cathedral")
                    {
                        Id = 3,
                        CityId = 2,
                        Description = "A gotic style cathedral."
                    },

                    new PointOfInterest("Eiffel Tower")
                    {
                        Id = 4,
                        CityId = 3,
                        Description = "A wrought iron lattice tower on the Champ de Mars."
                    },

                    new PointOfInterest("The Louvre")
                    {
                        Id = 5,
                        CityId = 3,
                        Description = "The world's largest museum."
                    }

                );

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    }
}