﻿CREATE TABLE [dbo].[Job]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AssetId] INT NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL, 
    [ModifyDate] DATETIME2 NOT NULL,
    [JobStartTime] DATETIME2 NOT NULL, 
    [JobEndTime] DATETIME2 NOT NULL
)