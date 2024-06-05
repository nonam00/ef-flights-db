CREATE VIEW [vw_trip_full_info] AS
SELECT
	t.Id,
	t.Number,
	t.Time,
	t.SeatsNumber,
	aa.Title AS [ArrivalAirport],
	ad.Title AS [DepartureAirport]
FROM [Trips] AS t
	INNER JOIN [Destinations] AS aa ON t.ArrivalAirportId = aa.Id
	INNER JOIN [Destinations] AS ad ON t.DepartureAirportId = ad.Id