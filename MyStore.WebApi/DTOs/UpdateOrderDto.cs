using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.WebApi.DTOs
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Column(TypeName = "decimal(18,5)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int PostamatId { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(4, ErrorMessage = "Name must contains at least 4 characters")]
        public string Name { get; set; }
    }
}
