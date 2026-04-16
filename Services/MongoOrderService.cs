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

        public async Task<Orders> UpdateOrdersAsync(string id, Orders objUpdateOrders)
        {
            // Get existing record first
            var existingData=await _mongoOrderRepository.GetByIdAsync(id);
            if (existingData == null) {
                throw new Exception("Order Info not found!");
            }

            // OrderCreatedDate - Original date
            objUpdateOrders.OrderCreatedDate=existingData.OrderCreatedDate;

            // SET OrderModifiedDate 
            objUpdateOrders.OrderModifiedDate=DateTime.Now;
            objUpdateOrders.Id=id;

            return await _mongoOrderRepository.UpdateOrderAsync(id,objUpdateOrders);
        }
    }
}
