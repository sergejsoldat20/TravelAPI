namespace TravelAPI.Models.Entities
{
	public class DestinationTrip
	{
		public int DestionationId { get; set; }
		public int TripId { get; set; }
		public DateTime ArrivalDate { get; set; }
		public DateTime DepartureDate { get; set; }
	}
}
