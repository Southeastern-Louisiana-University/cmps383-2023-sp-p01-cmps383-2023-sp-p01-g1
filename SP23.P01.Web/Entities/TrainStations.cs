using System.ComponentModel.DataAnnotations;

namespace FA22.P02.Web.Entities
{
    public class TrainStations : BaseEntity
    {
        [MaxLength(120)]
        [StringLength(120)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
