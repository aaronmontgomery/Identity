CREATE TABLE [dbo].[ApplicationUserRole]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[RoleId] INT NOT NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [PK_ApplicationUserRole_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ApplicationUserRole_ApplicationRole] FOREIGN KEY ([RoleId]) REFERENCES [ApplicationRole] ([Id]),
	CONSTRAINT [FK_ApplicationUserRole_ApplicationUser] FOREIGN KEY ([UserId]) REFERENCES [ApplicationUser] ([Id])
)
