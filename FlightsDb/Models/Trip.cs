namespace FlightsDb.Models
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Time { get; set; }
        public int SeatsNumber { get; set; }
        
        public Guid? ArrivalAirportId { get; set; }
        public virtual Airport? ArrivalAirport { get; set; }
        public Guid? DepartureAirportId { get; set; }
        public virtual Airport? DepartureAirport { get; set; }

        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
