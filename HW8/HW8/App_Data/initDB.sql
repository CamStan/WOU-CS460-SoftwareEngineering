-- *********** Drop Tables ***********
-- DONT RUN THIS SECTION WHEN RUNNING SCRIPT THE FIRST TIME
ALTER TABLE [dbo].[Crews]
	DROP CONSTRAINT [FK_dbo.Crews_dbo.PirateID];

ALTER TABLE [dbo].[Crews]
	DROP CONSTRAINT [FK_dbo.Crews_dbo.ShipID];

IF OBJECT_ID('dbo.Pirates','U') IS NOT NULL
	DROP TABLE [dbo].[Pirates];
GO

IF OBJECT_ID('dbo.Ships','U') IS NOT NULL
	DROP TABLE [dbo].[Ships];
GO

IF OBJECT_ID('dbo.Crews','U') IS NOT NULL
	DROP TABLE [dbo].[Crews];
GO

-- ########### Pirates ###########
CREATE TABLE [dbo].[Pirates]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FirstName] NVARCHAR (50) NOT NULL,
	[LastName] NVARCHAR (50) NOT NULL,
	[NickName] NVARCHAR (50) NOT NULL,
	[ConscriptionDate] DATETIME2 NOT NULL,
	CONSTRAINT [PK_dbo.Pirates] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### Ships ###########
CREATE TABLE [dbo].[Ships]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Type] NVARCHAR (50) NOT NULL,
	[Tonnage] INT NOT NULL,
	CONSTRAINT [PK_dbo.Ships] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### Crews ###########
CREATE TABLE [dbo].[Crews]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[PirateID] INT NOT NULL,
	[ShipID] INT NOT NULL,
	[Booty] DECIMAL(19,2) NOT NULL,
	CONSTRAINT [PK_dbo.Crews] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Crews_dbo.PirateID] FOREIGN KEY ([PirateID]) REFERENCES [dbo].[Pirates] ([ID]),
	CONSTRAINT [FK_dbo.Crews_dbo.ShipID] FOREIGN KEY ([ShipID]) REFERENCES [dbo].[Ships] ([ID])
);