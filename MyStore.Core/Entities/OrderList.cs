using System.ComponentModel.DataAnnotations;

namespace MyStore.Core.Entities
{
    public record OrderList
    {
        [Key]
        public int OrderListId { get; set; }
        [Required]
        public string List { get; set; }

    }
}
