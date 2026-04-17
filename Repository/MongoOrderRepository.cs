using MongoDB.Driver;
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

        // Get Customer Orders information from MongoDB
        public async Task<List<Orders>> GetByOrderCodeAsync(RequestCustomerOrders reqCustOrders) 
        { 
            return await _context.Orders.Find(x => x.OrderCode == reqCustOrders.OrderCode).ToListAsync();
        }

        // Save Order information to MongoDB
        public async Task<Orders> SaveOrderAsync(Orders objOrders)
        {
            await _context.Orders.InsertOneAsync(objOrders);
            return objOrders;
        }

        // Update Order information to MongoDB
        public async Task<Orders> GetByIdAsync(string id)
        {
            return await _context.Orders.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Orders> UpdateOrderAsync(string id, Orders objUpdateOrder)
        {
            await _context.Orders.ReplaceOneAsync(x => x.Id == id, objUpdateOrder);
            return objUpdateOrder;
        }

    }
}
