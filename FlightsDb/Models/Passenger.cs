namespace FlightsDb.Models
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string DocumentNumber { get; set; }
    }
}
