using System.Text.Json.Serialization;

namespace FA22.P02.Web.Dtos
{
    public class TrainStationsDto : BaseDto
    {
        [JsonIgnore]
        public new int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
