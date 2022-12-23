using lb3.Models;
using MongoDB.Driver;

namespace lb3.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _cities;

        public CityService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _cities= database.GetCollection<City>("Cities");
        }

        public City Create(City city)
        {
            _cities.InsertOne(city);
            return city;
        }

        public IList<City> Read() =>
            _cities.Find(sub => true).ToList();

        public City Find(string id) =>
            _cities.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(City city) =>
            _cities.ReplaceOne(sub => sub.Id == city.Id, city);

        public void Delete(string id) =>
            _cities.DeleteOne(sub => sub.Id == id);
    }
}
