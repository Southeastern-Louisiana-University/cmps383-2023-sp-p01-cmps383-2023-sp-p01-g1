using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FA22.P02.Web.Dtos
{
    public class TrainStationsDto : BaseDto
    {
        [JsonIgnore]
        public new int Id { get; set; }
        [StringLength(120)]
        [MaxLength(120)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
