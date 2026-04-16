using SravaniWebAPI.Models;

namespace SravaniWebAPI.Services
{
    public interface IMongoOrderServicecs
    {
        Task<Orders> SaveOrdersAsync(Orders objOrders);
        Task<Orders> UpdateOrdersAsync(string id,Orders objUpdateOrder);
    }
}
