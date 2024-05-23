using FlightsDb;
using FlightsDb.Models;

Passenger passenger1 = new Passenger()
{
    Id = Guid.NewGuid(),
    FirstName = "Pavel",
    LastName = "Klein",
    BirthDate = new DateTime(2000, 1, 20),
    PassportNumber = "7020"
};
Passenger passenger2 = new Passenger()
{
    Id = Guid.NewGuid(),
    FirstName = "Max",
    LastName = "Smith",
    BirthDate = new DateTime(1990, 2, 20),
    PassportNumber = "4021"
};
Passenger passenger3 = new Passenger()
{
    Id = Guid.NewGuid(),
    FirstName = "Anna",
    LastName = "Lenshina",
    BirthDate = new DateTime(2000, 3, 10),
    PassportNumber = "6002"
};

Airport airport1 = new Airport()
{
    Id = Guid.NewGuid(),
    Title = "Chicago Airport",
    Country = "USA",
    City = "Chicago"
};
Airport airport2 = new Airport()
{
    Id = Guid.NewGuid(),
    Title = "Paris Airport",
    Country = "France",
    City = "Paris"
};
Airport airport3 = new Airport()
{
    Id = Guid.NewGuid(),
    Title = "Prague Airport",
    Country = "Czech Republic",
    City = "Prague"
};
Airport airport4 = new Airport()
{
    Id = Guid.NewGuid(),
    Title = "Domodedovo",
    Country = "Russia",
    City = "Moscow"
};

Trip trip1 = new Trip()
{
    Id = Guid.NewGuid(),
    Number = "910",
    Time = new DateTime(2003, 10, 1, 12, 3, 0),
    SeatsNumber = 120,
    DepartureAirportId = airport3.Id,
    ArrivalAirportId = airport1.Id

};
Trip trip2 = new Trip()
{
    Id = Guid.NewGuid(),
    Number = "820",
    Time = new DateTime(2012, 5, 2, 18, 24, 0),
    SeatsNumber = 150,
    DepartureAirportId = airport2.Id,
    ArrivalAirportId = airport4.Id
};

Ticket ticket1 = new Ticket()
{
    Id = Guid.NewGuid(),
    Number = "101",
    TripId = trip1.Id,
    PassengerId = passenger1.Id,
    SeatNumber = 20
};
Ticket ticket2 = new Ticket()
{
    Id = Guid.NewGuid(),
    Number = "802",
    TripId = trip2.Id,
    PassengerId = passenger2.Id,
    SeatNumber = 40
};

using (FlightsDbContext context = new FlightsDbContext())
{
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();

    await context.Passengers.AddRangeAsync(passenger1, passenger2, passenger3);
    await context.SaveChangesAsync();

    Console.WriteLine("Passengers created");

    await context.Airports.AddRangeAsync(airport1, airport2, airport3, airport4);
    await context.SaveChangesAsync();

    Console.WriteLine("Airports created");

    await context.Trips.AddRangeAsync(trip1, trip2);
    await context.SaveChangesAsync();

    Console.WriteLine("Trips created");

    await context.Tickets.AddRangeAsync(ticket1, ticket2);
    await context.SaveChangesAsync();

    Console.WriteLine("Tickets created");
}
