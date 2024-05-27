namespace FlightsDb.Models
{
    public class Airport
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        
        public virtual IList<Trip> ArrivalTrips { get; set; }
        public virtual IList<Trip> DepartureTrips { get; set; }
    }
}
