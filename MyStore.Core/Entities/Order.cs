using MyStore.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Core.Entities
{
    public record Order
    {
        [Key]
        public int OrderId { get; set; }

        // статус заказа
        public OrderStatus OrderStatus { get; init; }

        [ForeignKey("OrderList")]
        public int OrderListId { get; set; }

        // состав заказа
        public OrderList OrderList { get; init; }

        [Column(TypeName = "decimal(18,5)")]
        // стоимость заказа
        public decimal Price { get; set; }

        [ForeignKey("Postamat")]
        public int PostamatId { get; set; }

        // номер постамата доставки
        public Postamat Postamat { get; set; }

        [Phone]
        [Required]
        // номер телефона получателя
        public string PhoneNumber { get; set; }

        [Required]
        // ФИО получателя
        public string Name { get; set; }
    }
}
