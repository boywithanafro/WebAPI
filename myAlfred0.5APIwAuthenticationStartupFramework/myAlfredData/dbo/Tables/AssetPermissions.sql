CREATE TABLE [dbo].[AssetPermissions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AssetId] NCHAR(10) NULL, 
    [TeamId] NCHAR(10) NULL, 
    [UserId] NCHAR(10) NULL
)
