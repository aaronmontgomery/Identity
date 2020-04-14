CREATE TABLE [dbo].[ApplicationRoleClaim]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[ClaimType] NVARCHAR(MAX) NOT NULL,
	[ClaimValue] NVARCHAR(MAX) NOT NULL,
	[RoleId] INT NOT NULL,
	CONSTRAINT [PK_ApplicationRoleClaim_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ApplicationRoleClaim_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [ApplicationRole] ([Id])
)
