using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.Models;
using MongoDB.Driver;

namespace Company.Domain.Infrastructure.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _db;

        public UserRepository(IMongoDatabase db)
        {
            _db = db;
        }

        public User GetUserByEmail(string email)
        {
            var collection = _db.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Eq("name", "andrew");
            var result = collection.Find(filter);
            return result.Single();
        }
    }
}
