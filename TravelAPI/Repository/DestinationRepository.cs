using TravelAPI.Contracts;
using TravelAPI.Data;
using TravelAPI.Models.Entities;

namespace TravelAPI.Repository
{
	public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
	{
        public DestinationRepository(TravelPlannerDbContext context) : base(context)
        {
            
        }
    }
}
