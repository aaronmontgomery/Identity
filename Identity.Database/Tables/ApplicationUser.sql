CREATE TABLE [dbo].[ApplicationUser]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AccessFailedCount] INT NOT NULL,
	[ConcurrencyStamp] NVARCHAR(MAX) NOT NULL,
	[Email] NVARCHAR(MAX) NOT NULL,
	[EmailConfirmed] BIT NOT NULL,
	[LockoutEnabled] BIT NOT NULL,
	[LockoutEnd] DATETIMEOFFSET,
	[NormalizedEmail] NVARCHAR(MAX) NOT NULL,
	[NormalizedUserName] NVARCHAR(MAX) NOT NULL,
	[PasswordHash] NVARCHAR(MAX) NOT NULL,
	[PhoneNumber] NVARCHAR(MAX) NOT NULL,
	[PhoneNumberConfirmed] BIT NOT NULL,
	[SecurityStamp] NVARCHAR(MAX) NOT NULL,
	[TwoFactorEnabled] BIT NOT NULL,
	[UserName] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT [PK_ApplicationUser_Id] PRIMARY KEY ([Id])
)
