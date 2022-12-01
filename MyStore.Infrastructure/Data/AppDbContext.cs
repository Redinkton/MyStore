using Microsoft.EntityFrameworkCore;
using MyStore.Core.Entities;
using MyStore.Core.Models;

namespace MyStore.Infrastructure.Data
{
    //создаст три таблицы OrderLists, Orders и Postamats
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Postamat> Postamats { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderList>().HasData(new OrderList
            {
                OrderListId = 1,
                List = "Cup",
            });

            modelBuilder.Entity<OrderList>().HasData(new OrderList
            {
                OrderListId = 2,
                List = "Table",
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 1,
                OrderStatus = OrderStatus.received,
                Price = 12,
                PostamatId = 1,
                PhoneNumber = "+79003219900",
                Name = "Jacky Wolf",
                OrderListId = 1,
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 2,
                OrderStatus = OrderStatus.deliveredToCourier,
                Price = 12,
                PostamatId = 2,
                PhoneNumber = "+79003219900",
                Name = "Alex Grey",
                OrderListId = 2,
            });

            modelBuilder.Entity<Postamat>().HasData(new Postamat
            {
                PostamatId = 1,
                Address = "St. Green",
                Number = "128211",
                WorkingStatus = true,
            });

            modelBuilder.Entity<Postamat>().HasData(new Postamat
            {
                PostamatId = 2,
                Address = "Paul St.",
                Number = "233211",
                WorkingStatus = true,
            });
        }

    }
}
