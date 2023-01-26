using FA22.P02.Web.Dtos;
using FA22.P02.Web.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace SP23.P01.Web.Controllers
{
    [ApiController]
    [Route("/api/stations")]
    public class TrainStationsController : ControllerBase
    {

        private readonly ITrainStationsRepository repository;

        public TrainStationsController(ITrainStationsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Create(TrainStationsDto dto)
        {
            var insert = await repository.Create(dto);
            return Created($"http://localhost/api/stations/{insert.Id}", insert);
        }
        [HttpGet]
        public async Task<ActionResult<List<TrainStationsDto>>> GetAll()
        {
            return Ok(await repository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var station = await repository.GetById(id);
            return Ok(station);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TrainStationsDto dto) {
            var update = await repository.Update(id,dto);
            return Ok(update);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id ) {
            await repository.Delete(id);
            return Ok();
        }
    }
}
