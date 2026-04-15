using SravaniWebAPI.Models;
using SravaniWebAPI.Repository;

namespace SravaniWebAPI.Services
{
    public class MongoOrderService : IMongoOrderServicecs
    {
        public readonly IMongoOrderRepository _mongoOrderRepository;
        public MongoOrderService(IMongoOrderRepository mongoOrderRepository) { 
            _mongoOrderRepository = mongoOrderRepository;
        }
        public async Task<Orders> SaveOrdersAsync(Orders objOrders)
        {
            return await _mongoOrderRepository.SaveOrderAsync(objOrders);
        }
    }
}
