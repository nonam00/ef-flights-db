using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsDb.Models.DbModels
{
    public class TicketFullInfo
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = null!;
        public decimal Price { get; set; }
        public int SeatNumber { get; set; }
        public TicketType Type { get; set; }
        public string Passenger { get; set; } = null!;
        public DateTime Time { get; set; }
        public string ArrivalAirport { get; set; } = null!;
        public string DepartureAirport { get; set; } = null!;

    }
}
