using FlightsDb;
using FlightsDb.Models;
using Microsoft.EntityFrameworkCore;

using (FlightsDbContext context = new FlightsDbContext())
{
    await Examples.SelectTripsByAirport(context);
    //await Examples.SelectTicketsByDate(context);
}
