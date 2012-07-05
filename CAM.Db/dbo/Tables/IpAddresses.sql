CREATE TABLE [dbo].[IpAddresses]
(
	[Id] CHAR(15) NOT NULL PRIMARY KEY, 
    [Host] VARCHAR(100) NULL, 
    [RangeId] CHAR(11) NOT NULL, 
    [SortOrder] INT NOT NULL
)
