using SravaniWebAPI.Models;

namespace SravaniWebAPI.Repository
{
    public interface IMongoOrderRepository
    {
        Task<Orders> SaveOrderAsync(Orders objOrders);
        Task<Orders> GetByIdAsync(string id);
        Task<Orders> UpdateOrderAsync(string id,Orders objUpdateOrder);
    }
}
