CREATE VIEW [vw_ticket_full_info] AS
SElECT
	ticket.Id,
	ticket.Number,
	ticket.Price,
	ticket.SeatNumber,
	ticket.[Type],
	p.FirstName + ' ' + p.LastName AS [Passenger],
	trip.[Time] AS [Time],
	aa.Title AS [ArrivalAirport],
	ad.Title AS [DepartureAirport]
FROM [Tickets] AS ticket
	INNER JOIN [Passengers] AS p ON ticket.[PassengerId] = p.[Id]
	INNER JOIN [Trips] AS trip ON ticket.[TripId] = trip.[Id]
	INNER JOIN [Destinations] AS aa ON trip.ArrivalAirportId = aa.Id 
	INNER JOIN [Destinations] AS ad ON trip.DepartureAirportId = ad.Id
GO