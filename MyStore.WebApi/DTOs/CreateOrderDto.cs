using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyStore.Core.Entities;

namespace MyStore.WebApi.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        [Range(1, 6)]
        public int OrderStatus { get; init; }

        [Required(ErrorMessage = "The field {0} is required")]
        public OrderList OrderList { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Column(TypeName = "decimal(18,5)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int PostamatId { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(4, ErrorMessage = "Name must contains at least 4 characters")]
        public string Name { get; set; }
    }
}
