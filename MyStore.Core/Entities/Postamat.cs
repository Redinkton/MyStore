using System.ComponentModel.DataAnnotations;

namespace MyStore.Core.Entities
{
    public record Postamat
    {
        [Key]
        public int PostamatId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}\-[0-9]{3}$")]
        // номер постамата
        public string Number { get; set; }

        [Required]
        // адрес 
        public string Address { get; set; }

        [Required]
        // статус(true - рабочий, иначе закрыт)
        public bool WorkingStatus { get; set; }
    }
}
