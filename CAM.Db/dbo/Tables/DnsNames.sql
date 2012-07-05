CREATE TABLE [dbo].[DnsNames]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(100) NOT NULL, 
    [IpAddress] CHAR(15) NOT NULL, 
    CONSTRAINT [FK_DnsNames_IpAddresses] FOREIGN KEY ([IpAddress]) REFERENCES [IpAddresses]([Id])
)
