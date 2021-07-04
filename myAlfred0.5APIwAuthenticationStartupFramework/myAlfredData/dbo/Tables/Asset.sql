CREATE TABLE [dbo].[Asset]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AssetName] NVARCHAR(50) NOT NULL, 
    [CompanyId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ModifyDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
