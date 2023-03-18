using Microsoft.AspNetCore.Mvc;

namespace IntroBackend
{
    public class Repository
    {
        List<Brewery> breweries = new List<Brewery>()
        {
            new Brewery(){ Id = 1, Name = "Pilsen"},
            new Brewery(){ Id = 2, Name = "Poker"},
            new Brewery(){ Id = 3, Name = "Costeñita"},
        };

        public List<Brewery> GetBreweries () => breweries;
        public Brewery? GetBreweryById(int id) => breweries.Find(b => b.Id == id);
                
    }

    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
