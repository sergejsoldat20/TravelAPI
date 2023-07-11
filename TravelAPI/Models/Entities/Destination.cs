namespace TravelAPI.Models.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; } = String.Empty;
        public virtual Location Location { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
