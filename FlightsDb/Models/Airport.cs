namespace FlightsDb.Models
{
    public class Airport
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
