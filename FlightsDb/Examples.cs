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
            Beneficiary beneficiary = new Beneficiary()
            {
                Id = Guid.NewGuid(),
                FirstName = "Bobby",
                LastName = "Ross",
                BirthDate = new DateTime(1980, 2, 12),
                PassportNumber = "7018"
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
                SeatNumber = 20,
                Price = 15000m
            };
            Ticket ticket2 = new Ticket()
            {
                Id = Guid.NewGuid(),
                Number = "802",
                TripId = trip2.Id,
                PassengerId = passenger2.Id,
                SeatNumber = 40,
                Price = 17000m
            };
            Ticket ticket3 = new Ticket()
            {
                Id = Guid.NewGuid(),
                Number = "123",
                TripId = trip1.Id,
                PassengerId = passenger3.Id,
                SeatNumber = 42,
                Price = 13000m
            };

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            context.Tickets.ExecuteDelete(); 
            context.Trips.ExecuteDelete(); 
            context.Airports.ExecuteDelete();
            context.Passengers.ExecuteDelete();
            context.Beneficiaries.ExecuteDelete();

            await context.Passengers.AddRangeAsync(passenger1, passenger2, passenger3);
            await context.Beneficiaries.AddAsync(beneficiary);

            await context.SaveChangesAsync();

            Console.WriteLine("Passengers created");


            await context.Airports.AddRangeAsync(airport1, airport2, airport3, airport4);
            await context.SaveChangesAsync();

            Console.WriteLine("Airports created");


            await context.Trips.AddRangeAsync(trip1, trip2);
            await context.SaveChangesAsync();

            Console.WriteLine("Trips created");


            await context.Tickets.AddRangeAsync(ticket1, ticket2, ticket3);
            await context.SaveChangesAsync();

            Console.WriteLine("Tickets created");
        }

        public static async Task LoadTripsFromAirports(FlightsDbContext context)
        {
            var airports = await context.Airports
                .Include(a => a.ArrivalTrips)
                .Include(a => a.DepartureTrips)
                .ToListAsync();

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

        public static async Task LoadAllDataFromPassengers(FlightsDbContext context)
        {
            var passengers = await context.Passengers
                .Include(p => p.Tickets)
                    .ThenInclude(ticket => ticket.Trip)
                        .ThenInclude(trip => trip.ArrivalAirport)
                .Include(p => p.Tickets)
                    .ThenInclude(ticket => ticket.Trip)
                        .ThenInclude(trip => trip.DepartureAirport)
                .ToListAsync();

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

        public static async Task LoadAllDataFromAirports(FlightsDbContext context)
        {
            var airports = await context.Airports
                .Include(a => a.ArrivalTrips)
                    .ThenInclude(trip => trip.Tickets)
                        .ThenInclude(ticket => ticket.Passenger)
                .Include(a => a.DepartureTrips)
                    .ThenInclude(trip => trip.Tickets)
                        .ThenInclude(ticket => ticket.Passenger)
                .ToListAsync();

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
        
        public static async Task SelectTripsByAirport(FlightsDbContext context)
        {
            var airports = await context.Airports.ToListAsync();
            for(int i = 0; i < airports.Count(); i++)
            {
                Console.WriteLine($"{i} - {airports[i].Title}");
            }
            Console.WriteLine("\nSelect the airport to see data about trips");
            int input = int.Parse(Console.ReadLine());
            var airportId = airports[input].Id;

            var trips = await context.Trips
                .Include(t => t.DepartureAirport)
                .Include(t => t.ArrivalAirport)
                .Where(t => t.ArrivalAirportId == airportId ||
                              t.DepartureAirportId == airportId)
                .ToListAsync();

            foreach (var t in trips)
            {
                Console.WriteLine($"\nTrip num: {t.Number}\n" +
                    $"Arrival airport: {t.ArrivalAirport.Title}\n" +
                    $"Departure airport: {t.DepartureAirport.Title}\n");
            }
        }

        public static async Task SelectTicketsByDate(FlightsDbContext context)
        {
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            DateTime secondDate = DateTime.Parse(Console.ReadLine());

            var tickets = await context.Tickets
                .Include(t => t.Passenger)
                .Include(t => t.Trip)
                .Where(ticket => DateTime.Compare(ticket.Trip.Time, firstDate) >= 0 &&
                                 DateTime.Compare(ticket.Trip.Time, secondDate) <=0)
                .ToListAsync();

            foreach (var ticket in tickets)
            {
                Console.WriteLine("\nTicket owner: " +
                    $"{ticket.Passenger.FirstName} {ticket.Passenger.LastName}\n" +
                    $"Trip date: {ticket.Trip.Time.ToString()}");
            }
        }

        public static async Task TicketsPriceSumByAirport(FlightsDbContext context)
        {
            var airports = await context.Airports.ToListAsync();
            for(int i = 0; i < airports.Count(); i++)
            {
                Console.WriteLine($"{i} - {airports[i].Title}");
            }
            Console.WriteLine("\nSelect the airport to see data about trips");
            int input = int.Parse(Console.ReadLine());
            var airportId = airports[input].Id;

            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            DateTime secondDate = DateTime.Parse(Console.ReadLine());
            
            var trips = await context.Trips
                .Include(t => t.DepartureAirport)
                .Include(t => t.ArrivalAirport)
                .Where(t => t.ArrivalAirportId == airportId ||
                              t.DepartureAirportId == airportId)
                .ToListAsync();

            var airportSum = await context.Tickets
                .Where(ticket => DateTime.Compare(ticket.Trip.Time, firstDate) >= 0 &&
                                 DateTime.Compare(ticket.Trip.Time, secondDate) <= 0 &&
                                 (ticket.Trip.ArrivalAirportId == airportId ||
                                     ticket.Trip.DepartureAirportId == airportId))
                .SumAsync(t => t.Price) / 2;

            Console.WriteLine($"Tickets sum price: {airportSum}");
        }

        public static async Task SelectCheapAndExpensiveAirports(FlightsDbContext context)
        {
            var allTickets = context.Airports
                .SelectMany(a => a.DepartureTrips
                    .SelectMany(t => t.Tickets))
                .GroupBy(t => t.Trip.DepartureAirport)
                .Select(g => new
                {
                    Airport = g.Key,
                    TicketsAvgPrice = g.Average(t => t.Price)
                });

            var minPrices = await allTickets
                .Select(g => g.TicketsAvgPrice)
                .MinAsync();
            var minAirport = await allTickets
                .FirstOrDefaultAsync(g => g.TicketsAvgPrice == minPrices);

            var maxPrices = await allTickets
                .Select(g => g.TicketsAvgPrice)
                .MaxAsync();
            var maxAirport = await allTickets
                .FirstOrDefaultAsync(g => g.TicketsAvgPrice == maxPrices);

            Console.WriteLine($"Airport with minimal prices: {minAirport?.Airport?.Title}\n" +
                $"Airport with maximum prices: {maxAirport?.Airport?.Title}\n");
        }

        public static async Task SelectCheapAndExpensiveAirportsFromSql(FlightsDbContext context)
        {

            var min = await context.GetMinPricesAirport()
                                   .FirstOrDefaultAsync();       

            var max = await context.GetMaxPricesAirport()
                                   .FirstOrDefaultAsync();

            Console.WriteLine($"Airport with minimal prices: {min?.Title}\n" +
                $"Airport with maximum prices: {max?.Title}\n");
        }

    }
}
