CREATE TABLE [dbo].[ApplicationRole]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[ConcurrencyStamp] NVARCHAR(MAX) NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	[NormalizedName] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT [PK_ApplicationRole_Id] PRIMARY KEY ([Id])
)
