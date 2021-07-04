CREATE TABLE [dbo].[AssetHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AssetId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Note] NVARCHAR(MAX) NULL, 
    [CreateDate] DATETIME2 NOT NULL, 
    [ModifyDate] DATETIME2 NOT NULL
)
