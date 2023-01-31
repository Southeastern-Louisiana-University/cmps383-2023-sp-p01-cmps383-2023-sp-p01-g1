using FA22.P02.Web.Data;
using FA22.P02.Web.Dtos;
using FA22.P02.Web.Entities;

namespace FA22.P02.Web.Respositories
{
    public class TrainStationsRepository : GenericRepository<TrainStationsDto, TrainStation>, ITrainStationsRepository
    {
        public TrainStationsRepository(DataContext context) : base(context)
        {

        }
    }
}
