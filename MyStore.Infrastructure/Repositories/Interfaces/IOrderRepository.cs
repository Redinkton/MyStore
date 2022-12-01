using MyStore.Core.Entities;

namespace MyStore.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetById(int orderId);
        Task<Order> Create(Order order);
        Task<Order> Update(Order order);
        Task Delete(Order orderToDelete);
    }
}
