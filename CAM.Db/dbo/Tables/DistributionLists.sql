﻿CREATE TABLE [dbo].[DistributionLists]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1
)
