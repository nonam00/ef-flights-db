using FlightsDb;
using FlightsDb.Models;
using Microsoft.EntityFrameworkCore;

using (FlightsDbContext context = new FlightsDbContext())
{
    //await Examples.TicketsPriceSumByAirport(context);
    //await Examples.CreateDb(context);
    // await Examples.SelectCheapAndExpensiveAirports(context);
    await Examples.SelectCheapAndExpensiveAirportsFromSql(context);
}
