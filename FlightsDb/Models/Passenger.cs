namespace FlightsDb.Models
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
    }
}
