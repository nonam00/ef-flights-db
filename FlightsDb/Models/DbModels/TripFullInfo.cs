namespace FlightsDb.Models.DbModels
{
    public class TripFullInfo
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime Time { get; set; }
        public int SeatsNumber { get; set; }
        public string ArrivalAirport { get; set; }
        public string DepartureAirport { get; set; }
    }
}
