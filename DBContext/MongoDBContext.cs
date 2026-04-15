using MongoDB.Driver;
using SravaniWebAPI.Models;

namespace SravaniWebAPI.DBContext
{
    public class MongoDBContext: IMongoDBContext
    {
        private readonly IMongoDatabase _database;
        public MongoDBContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDB");
            var client= new MongoClient(connectionString);
            _database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
        }
        public IMongoCollection<Orders> Orders =>
            _database.GetCollection<Orders>("ReturnOrders");
    }
}
