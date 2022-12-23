using lb3.Models;
using MongoDB.Driver;

namespace lb3.Services
{
    public class AbonentService
    {
        private readonly IMongoCollection<Abonent> _abonents;

        public AbonentService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _abonents = database.GetCollection<Abonent>("Abonents");
        }

        public Abonent Create(Abonent abonent)
        {
            _abonents.InsertOne(abonent);
            return abonent;
        }

        public IList<Abonent> Read() =>
            _abonents.Find(sub => true).ToList();

        public Abonent Find(string id) =>
            _abonents.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(Abonent abonent) =>
            _abonents.ReplaceOne(sub => sub.Id == abonent.Id, abonent);

        public void Delete(string id) =>
            _abonents.DeleteOne(sub => sub.Id == id);
    }
}

