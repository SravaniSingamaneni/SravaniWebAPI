using SravaniWebAPI.Models;

namespace SravaniWebAPI.Repository
{
    public interface IMongoOrderRepository
    {
        Task<Orders> SaveOrderAsync(Orders objOrders);
    }
}
