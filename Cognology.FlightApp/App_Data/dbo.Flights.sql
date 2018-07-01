CREATE TABLE [dbo].[Flights]
(
	[Id] INT primary key not null IDENTITY, 
    [FlightNumber] NCHAR(10) NOT NULL, 
    [StartTime] DATETIME NOT NULL, 
    [EndTime] DATETIME NOT NULL, 
    [PassengerCapacity] INT NOT NULL, 
    [DepartureCity] NVARCHAR(50) NOT NULL, 
    [ArrivalCity] NVARCHAR(50) NOT NULL,

)
