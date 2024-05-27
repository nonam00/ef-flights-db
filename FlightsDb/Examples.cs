using FlightsDb.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightsDb
{
    public static class Examples
    {
        public static async Task CreateDb(FlightsDbContext context)
        {
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
        public static void LoadTripsFromAirports(FlightsDbContext context)
        {
            var airports = context.Airports.Include(a => a.ArrivalTrips)
                                           .Include(a => a.DepartureTrips)
                                           .ToList();

            foreach (var a in airports)
            {
                Console.WriteLine(a.Title);
                Console.WriteLine("\nArrivals:");
                foreach(var trip in a.ArrivalTrips)
                {
                    Console.WriteLine($"Number: {trip.Number} Time: {trip.Time} Seats: {trip.SeatsNumber}");
                }
                Console.WriteLine("\nDepartures:");
                foreach (var trip in a.DepartureTrips)
                {
                    Console.WriteLine($"Number: {trip.Number} Time: {trip.Time} Seats: {trip.SeatsNumber}");
                }
                Console.WriteLine();
            }
        }

        public static void LoadAllDataFromPassengers(FlightsDbContext context)
        {
            var passengers = context.Passengers.Include(p => p.Tickets)
                                                    .ThenInclude(ticket => ticket.Trip)
                                                        .ThenInclude(trip => trip.ArrivalAirport)
                                               .Include(p => p.Tickets)
                                                    .ThenInclude(ticket => ticket.Trip)
                                                        .ThenInclude(trip => trip.DepartureAirport)
                                               .ToList();

            foreach (var p in passengers)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName}\nTickets:");
                foreach (var ticket in p.Tickets)
                {
                    Console.WriteLine($"\tTicket number: {ticket.Number}");
                    Console.WriteLine($"\tArrival: {ticket.Trip.ArrivalAirport.Title}");
                    Console.WriteLine($"\tDeparture: {ticket.Trip.DepartureAirport.Title}");
                }
                Console.WriteLine();
            }
        }

        public static void LoadAllDataFromAirports(FlightsDbContext context)
        {
            var airports = context.Airports.Include(a => a.ArrivalTrips)
                                               .ThenInclude(trip => trip.Tickets)
                                                   .ThenInclude(ticket => ticket.Passenger)
                                           .Include(a => a.DepartureTrips)
                                               .ThenInclude(trip => trip.Tickets)
                                                   .ThenInclude(ticket => ticket.Passenger)
                                           .ToList();

            foreach (var a in airports)
            {
                Console.WriteLine(a.Title);
                Console.WriteLine("Arrivals:");
                foreach (var trip in a.ArrivalTrips)
                {
                    Console.WriteLine($"Trip number: {trip.Number} Time: {trip.Time} Seats: {trip.SeatsNumber}\n" +
                        $"Tickets:");
                    foreach (var ticket in trip.Tickets)
                    {
                        Console.WriteLine($"\tNumber: {ticket.Number} " +
                            $"Passenger: {ticket.Passenger!.FirstName} {ticket.Passenger.LastName}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\nDepartures:");
                foreach (var trip in a.DepartureTrips)
                {
                    Console.WriteLine($"Trip number: {trip.Number} Time: {trip.Time} Seats: {trip.SeatsNumber}\n" +
                        $"Tickets:");
                    foreach (var ticket in trip.Tickets)
                    {
                        Console.WriteLine($"\tNumber: {ticket.Number} " +
                            $"Passenger: {ticket.Passenger!.FirstName} {ticket.Passenger.LastName}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
