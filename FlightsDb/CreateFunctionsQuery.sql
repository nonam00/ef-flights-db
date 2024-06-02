CREATE FUNCTION [dbo].[GetMaxPricesAirport]()
RETURNS @result TABLE
(
	Id uniqueidentifier,
	Title VARCHAR(MAX),
	Country VARCHAR(MAX),
	City VARCHAR(MAX)
)
AS
BEGIN
	DECLARE @all_tickets TABLE
	(
		airport_id uniqueidentifier,
		ticket_price DECIMAL(8,2)
	)
	INSERT INTO @all_tickets
		SELECT
			a.id,
			AVG(ticket.price)
		FROM Destinations AS a
			
			INNER JOIN Trips AS trip ON a.id = trip.DepartureAirportId
			INNER JOIN Tickets AS ticket ON ticket.TripId = trip.id
			GROUP BY a.id

	INSERT INTO @result
		SELECT *
		FROM Destinations
		
			WHERE id =
			(
				SELECT airport_id
				FROM @all_tickets
					WHERE ticket_price = (SELECT MAX(ticket_price) from @all_tickets)
			)
	RETURN
END
GO

CREATE FUNCTION [dbo].[GetMinPricesAirport]()
RETURNS @result TABLE
(
	Id uniqueidentifier,
	Title VARCHAR(MAX),
	Country VARCHAR(MAX),
	City VARCHAR(MAX)
)
AS
BEGIN
	DECLARE @all_tickets TABLE
	(
		airport_id uniqueidentifier,
		ticket_price DECIMAL(8,2)
	)
	INSERT INTO @all_tickets
		SELECT
			a.id,
			AVG(ticket.price)
		FROM Destinations AS a
			INNER JOIN Trips AS trip ON a.id = trip.DepartureAirportId
			INNER JOIN Tickets AS ticket ON ticket.TripId = trip.id
			GROUP BY a.id

	INSERT INTO @result
		SELECT *
		FROM Destinations
			WHERE id =
			(
				SELECT airport_id
				FROM @all_tickets
					WHERE ticket_price = (SELECT MIN(ticket_price) from @all_tickets)
			)
	RETURN
END
GO