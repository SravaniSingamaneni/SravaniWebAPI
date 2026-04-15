using SravaniWebAPI.DBContext;
using SravaniWebAPI.Models;

namespace SravaniWebAPI.Repository
{
    public class MongoOrderRepository : IMongoOrderRepository
    {
        public readonly IMongoDBContext _context;
        public MongoOrderRepository(IMongoDBContext context)
        {
            _context = context;
        }

        //
        public async Task<Orders> SaveOrderAsync(Orders objOrders)
        {
            await _context.Orders.InsertOneAsync(objOrders);
            return objOrders;
        }
    }
}
