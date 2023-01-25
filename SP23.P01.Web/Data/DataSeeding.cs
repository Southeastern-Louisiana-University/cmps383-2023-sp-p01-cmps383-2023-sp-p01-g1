using FA22.P02.Web.Data;
using FA22.P02.Web.Entities;

namespace SP23.P01.Web.Data
{
    public class DataSeeding
    {

        private readonly DataContext context;

        public DataSeeding(DataContext context)
        {
            this.context = context;
        }

        public void SeedData()
        {
            List<TrainStations> trainStations = new()
            {
                new TrainStations
                {
                    Name = "Hammond Station",
                    Address = "Hammond"
                },
                new TrainStations
                {
                    Name = "Amite Station",
                    Address = "Amite"
                },
                new TrainStations
                {
                    Name = "New Orleans Station",
                    Address = "New Orleans"
                }
            };

            if (context.TrainStations.Count() <= 0)
            {
                context.AddRange(trainStations);
                context.SaveChanges();
            }

            
        }
    }
}
