namespace YourNamespace.Services
{
    using YourNamespace.Model;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;
    using YourNamespace.Models;

    public class PropertiesService
    {
        private readonly IMongoCollection<Property> _properties;

        public PropertiesService(MongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _properties = database.GetCollection<Property>("Properties");
        }

        public List<Property> Get() =>
            _properties.Find(property => true).ToList();

        public Property Get(string id) =>
            _properties.Find<Property>(property => property.Id == id).FirstOrDefault();

        public Property Create(Property property)
        {
            _properties.InsertOne(property);
            return property;
        }
        public List<Property> GetByLandLordId(string landLordId) =>
            _properties.Find<Property>(property => property.LandLordId == landLordId).ToList();

        public void Update(string id, Property propertyIn) =>
            _properties.ReplaceOne(property => property.Id == id, propertyIn);

        public void Remove(string id) => 
            _properties.DeleteOne(property => property.Id == id);
    }
}
