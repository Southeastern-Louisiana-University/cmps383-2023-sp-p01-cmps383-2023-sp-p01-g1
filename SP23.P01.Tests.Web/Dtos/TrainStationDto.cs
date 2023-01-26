using FA22.P02.Web.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SP23.P01.Tests.Web.Dtos;

public class TrainStationDto : BaseDto
{

    public string? Name { get; set; }

    public string? Address { get; set; }
}
