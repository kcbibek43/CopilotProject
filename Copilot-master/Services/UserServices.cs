using MongoDB.Driver;
using YourNamespace.Models;
using System.Collections.Generic;
using System.Linq;


namespace YourNamespace.Services
{
    using BCrypt.Net;
    public class UsersService
    {
        private readonly IMongoCollection<User> _users;

        public UsersService(MongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>("Tenants");
        }

        public User GetByEmail(string email)
        {
            return _users.Find<User>(user => user.Email == email).FirstOrDefault();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            var user = _users.Find<User>(user => user.Email == email).FirstOrDefault();

            if (user == null || !BCrypt.Verify(password, user.Password))
            {
                return null;
            }

            return user;
        }

        public User Create(User user)
        {
            user.Password = BCrypt.HashPassword(user.Password);
            _users.InsertOne(user);
            return user;
        }

        public User GetById(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();
        // Other methods...
    }
}