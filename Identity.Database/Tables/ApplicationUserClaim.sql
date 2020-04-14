CREATE TABLE [dbo].[ApplicationUserClaim]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[ClaimType] NVARCHAR(MAX) NOT NULL,
	[ClaimValue] NVARCHAR(MAX) NOT NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [PK_ApplicationUserClaim_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ApplicationUserClaim_ApplicationUser] FOREIGN KEY ([UserId]) REFERENCES [ApplicationUser] ([Id]),
)
