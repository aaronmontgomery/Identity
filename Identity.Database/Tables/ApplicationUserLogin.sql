CREATE TABLE [dbo].[ApplicationUserLogin]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[LoginProvider] NVARCHAR(MAX) NOT NULL,
	[ProviderDisplayName] NVARCHAR(MAX) NOT NULL,
	[ProviderKey] NVARCHAR(MAX) NOT NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [PK_ApplicationUserLogin_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ApplicationUserLogin_UserId] FOREIGN KEY ([UserId]) REFERENCES [ApplicationUser] ([Id])
)
