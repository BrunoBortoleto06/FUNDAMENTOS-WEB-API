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
                    Description = "The one with that big park"
                },

                new CityDTO
                {
                    Id = 2,
                    Name = "Antwerp",
                },

                new CityDTO
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower"
                }
            };

        }
    }
}
