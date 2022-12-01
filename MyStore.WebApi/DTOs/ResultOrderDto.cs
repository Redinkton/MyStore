using MyStore.Core.Entities;

namespace MyStore.WebApi.DTOs
{
    public class ResultOrderDto
    {
        public int OrderId { get; set; }
        public int OrderStatus { get; init; }
        public OrderList OrderList { get; set; }
        public decimal Price { get; set; }
        public Postamat Postamat { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
