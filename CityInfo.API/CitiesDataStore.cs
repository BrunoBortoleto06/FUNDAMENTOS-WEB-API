using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDTO> Cities { get; set; }
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDTO>()
            {
                new CityDTO
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park",
                    PointsOfInterest = new List<PointOfInterestDTO>()
                    {
                        new PointOfInterestDTO()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited urban park in the USA."
                        },
                        new PointOfInterestDTO()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattam."
                        }
                    }
                },

                new CityDTO
                {
                    Id = 2,
                    Name = "Antwerp",
                    PointsOfInterest = new List<PointOfInterestDTO>()
                    {
                        new PointOfInterestDTO()
                        {
                            Id = 3,
                            Name = "Cathedral of Our Lady",
                            Description = "A gotic style cathedral."
                        },
                        new PointOfInterestDTO()
                        {
                            Id = 4,
                            Name = "Antwerp central station",
                        }
                    }
                },

                new CityDTO
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower",
                    PointsOfInterest = new List<PointOfInterestDTO>()
                    {
                        new PointOfInterestDTO()
                        {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars."
                        },
                        new PointOfInterestDTO()
                        {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "The world's largest museum."
                        }
                    }
                }
            };

        }
    }
}
