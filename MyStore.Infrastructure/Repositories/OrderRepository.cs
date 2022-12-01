using Microsoft.EntityFrameworkCore;
using MyStore.Infrastructure.Repositories.Interfaces;
using MyStore.Core.Entities;
using MyStore.Infrastructure.Data;

namespace MyStore.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> GetById(int id)
        {
            return await _appDbContext.Orders.Include(postamat => postamat.Postamat)
                                             .Include(orderList => orderList.OrderList)
                                             .FirstOrDefaultAsync(orderId => orderId.OrderId == id);
        }

        public async Task<Order> Create(Order order)
        {
            //если идет попытка создать заказ на закрытый постамат -
            //запрещать регистрировать заказ с кодом ошибки "запрещено"
            if (_appDbContext.Postamats.Find(order.PostamatId).WorkingStatus == true)
            {
                await _appDbContext.Orders.AddAsync(order);
                await _appDbContext.SaveChangesAsync();

                return order;
            }
            else if(_appDbContext.Postamats.Find(order.PostamatId).WorkingStatus == false)
            {
                order.OrderId = 0;
                return order;
            }
            else
            {
                throw new InvalidOperationException("Forbidden");
            }
        }

        public async Task<Order> Update(Order order)
        {
            if (order != null)
            {
                await _appDbContext.SaveChangesAsync();
                return order;
            }
            return null;
        }

        public async Task Delete(Order orderToDelete)
        {
            _appDbContext.Orders.Remove(orderToDelete);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
