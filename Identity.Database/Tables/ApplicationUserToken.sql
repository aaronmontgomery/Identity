CREATE TABLE [dbo].[ApplicationUserToken]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[LoginProvider] NVARCHAR(MAX) NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	[UserId] INT NOT NULL,
	[Value] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_ApplicationUserToken_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ApplicationUserToken_UserId] FOREIGN KEY ([UserId]) REFERENCES [ApplicationUser] ([Id])
)
