namespace FlightsDb.Models
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime Time { get; set; }
        public int SeatsNumber { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public Airport ArrivalAirport { get; }
        public Guid DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; }
    }
}
