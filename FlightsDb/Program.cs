using FlightsDb;
using Microsoft.EntityFrameworkCore;

using (FlightsDbContext context = new FlightsDbContext())
{
    var ticketsFullInfo = await context.TicketsFullInfo.ToListAsync();

    Console.WriteLine("Tickets:\n");
    foreach(var item in ticketsFullInfo)
    {
        Console.WriteLine($"ID: {item.Id}\n" +
            $"Number: {item.Number}\n" +
            $"Type: {item.Type.ToString()}\n" +
            $"Passenger: {item.Passenger}\n" +
            $"Time: {item.Time}\n" +
            $"Arrival Airport: {item.ArrivalAirport}\n" +
            $"Departure Airport: {item.DepartureAirport}\n");
    }

    var tripsFullInfo = await context.TripsFullInfo.ToListAsync();

    Console.WriteLine("\nTrips:\n");
    foreach(var item in tripsFullInfo)
    {
        Console.WriteLine($"ID: {item.Id}\n" +
            $"Number: {item.Number}\n" +
            $"Seats Number: {item.SeatsNumber}\n" +
            $"Time: {item.Time}\n" +
            $"Arrival Airport: {item.ArrivalAirport}\n" +
            $"Departure Airport: {item.DepartureAirport}\n");
    }
}
