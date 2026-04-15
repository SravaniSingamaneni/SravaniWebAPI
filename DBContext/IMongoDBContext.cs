using MongoDB.Driver;
using SravaniWebAPI.Models;

namespace SravaniWebAPI.DBContext
{
    public interface IMongoDBContext
    {
        IMongoCollection<Orders> Orders { get; }
    }
}
