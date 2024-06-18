namespace FlightsDb.Models
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; } = null!;
        
        public virtual IList<Ticket> Tickets { get; set; } = new List<Ticket>();

        // For winforms display element
        public string Display => $"{FirstName} {LastName}";
    }
}
