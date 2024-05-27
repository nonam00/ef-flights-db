using FlightsDb;
using FlightsDb.Models;



using (FlightsDbContext context = new FlightsDbContext())
{
    Examples.LoadAllDataFromAirports(context);
}
Console.WriteLine();