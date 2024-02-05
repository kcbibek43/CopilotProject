using YourNamespace.Model;
using MongoDB.Driver;
using YourNamespace.Models;

namespace YourNamespace.Services
{
    public class ReviewService
    {
        private readonly IMongoCollection<Reviews> _reviews;

        public ReviewService(MongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reviews = database.GetCollection<Reviews>("Reviews");
        }
        // other methods
        public List<Reviews> Get() =>
            _reviews.Find(review => true).ToList();

        public Reviews GetByProperty(string id) =>
            _reviews.Find<Reviews>(review => review.PropertyId == id).FirstOrDefault();

        public Reviews Get(string id) =>
            _reviews.Find<Reviews>(review => review.Id == id).FirstOrDefault();
        
        public Reviews Create(Reviews review)
        {
            _reviews.InsertOne(review);
            return review;
        }

        public void Update(string id, Reviews reviewIn) =>
            _reviews.ReplaceOne(review => review.Id == id, reviewIn);

        public void Remove(Reviews reviewIn) =>
            _reviews.DeleteOne(review => review.Id == reviewIn.Id);

        public void Remove(string id) => 
            _reviews.DeleteOne(review => review.Id == id);
    }
}
