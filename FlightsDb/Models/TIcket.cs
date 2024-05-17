namespace FlightsDb.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; }
        public Guid TripId { get; set; }
        public Trip Trip { get; }
        public int SeatNumber { get; set; }
    }
}
