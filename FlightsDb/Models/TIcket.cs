namespace FlightsDb.Models
{
    public enum TicketType
    {
        Economy,
        Normal,
        Business
    };

    public class Ticket
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = null!;
        public Guid? PassengerId { get; set; }
        public virtual Passenger? Passenger { get; set; }
        public Guid TripId { get; set; }
        public virtual Trip Trip { get; set; } = null!;
        public int SeatNumber { get; set; }
        public TicketType Type { get; set; }
    }
}
