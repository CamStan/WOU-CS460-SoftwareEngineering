-- *********** Drop Tables ***********
-- DONT RUN THIS SECTION WHEN RUNNING SCRIPT THE FIRST TIME
ALTER TABLE [dbo].[ArtWorks]
	DROP CONSTRAINT [FK_dbo.Artworks_dbo.ArtistID];

ALTER TABLE [dbo].[Classifications]
	DROP CONSTRAINT [FK_dbo.Classifications_dbo.ArtWorkID];

ALTER TABLE [dbo].[Classifications]
DROP CONSTRAINT [FK_dbo.Classifications_dbo.GenreID];

IF OBJECT_ID('dbo.Artists','U') IS NOT NULL
	DROP TABLE [dbo].[Artists];
GO

IF OBJECT_ID('dbo.Genres','U') IS NOT NULL
	DROP TABLE [dbo].[Genres];
GO

IF OBJECT_ID('dbo.ArtWorks','U') IS NOT NULL
	DROP TABLE [dbo].[ArtWorks];
GO

IF OBJECT_ID('dbo.Classifications','U') IS NOT NULL
	DROP TABLE [dbo].[Classifications];
GO

-- ########### Artists ###########
CREATE TABLE [dbo].[Artists]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FirstName] NVARCHAR (50) NOT NULL,
	[LastName] NVARCHAR (50) NOT NULL,
	[BirthDate] DATETIME2 NOT NULL,	
	[BirthCity] NVARCHAR (50) NOT NULL,
	[BirthCountry] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### Genres ###########
CREATE TABLE [dbo].[Genres]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### ArtWorks ###########
CREATE TABLE [dbo].[ArtWorks]
(
	[ID] INT IDENTITY (1,1) NOT NULL,	
	[Title] NVARCHAR (100) NOT NULL,
	[ArtistID] INT NOT NULL,
	CONSTRAINT [PK_dbo.Artworks] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Artworks_dbo.ArtistID] FOREIGN KEY ([ArtistID]) REFERENCES [dbo].[Artists] ([ID])
);

-- ########### Classifications ###########
CREATE TABLE [dbo].[Classifications]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[ArtWorkID] INT NOT NULL,
	[GenreID] INT NOT NULL,
	CONSTRAINT [PK_dbo.Classifications] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Classifications_dbo.ArtWorkID] FOREIGN KEY ([ArtWorkID]) REFERENCES [dbo].[ArtWorks] ([ID]),
	CONSTRAINT [FK_dbo.Classifications_dbo.GenreID] FOREIGN KEY ([GenreID]) REFERENCES [dbo].[Genres] ([ID])
);