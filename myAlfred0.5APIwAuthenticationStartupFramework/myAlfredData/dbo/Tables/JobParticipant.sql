CREATE TABLE [dbo].[JobParticipant]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [JobId] INT NOT NULL, 
    [TeamId] INT NULL, 
    [UserId] INT NULL, 
    [CreateDate] DATETIME2 NOT NULL, 
    [ModifyDate] DATETIME2 NOT NULL
)
