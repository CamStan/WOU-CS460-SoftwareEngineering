-- Create tables and populate with seed data
--    follow naming convention: "Requests" table contains rows that are each "Request" objects

-- ***********  Attach ***********
CREATE DATABASE [460_HW5] ON
PRIMARY (NAME=[460_HW5], FILENAME='$(dbdir)\460_HW5.mdf')
LOG ON (NAME=[460_HW5_log], FILENAME='$(dbdir)\460_HW5_log.ldf');
--FOR ATTACH;
GO

USE [460_HW5];
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.Requests','R') IS NOT NULL
	DROP TABLE [dbo].[Requests];
GO


-- ########### Users ###########
CREATE TABLE [dbo].[Requests]
(
    [ID] INT IDENTITY (1,1) NOT NULL,
	[VNo] INT NOT NULL,
	[LastName] NVARCHAR (50) NOT NULL,
	[FirstName] NVARCHAR (50) NOT NULL,
	[Date] DATETIME NOT NULL,
	[PhoneNumber] BIGINT NOT NULL,
	[CatalogYear] NVARCHAR (7) NOT NULL,
	[Email] NVARCHAR (50) NOT NULL,
	[Major] NVARCHAR (50) NOT NULL,
	[Minor] NVARCHAR (50) NOT NULL,
	[Advisor] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

BULK INSERT [dbo].[Requests]
	FROM '$(dbdir)\SeedData\Requests.csv'		-- VNo,LastName,FirstName,Date,PhoneNumber,CatalogYear,Email,Major,Minor,Advisor
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR	= '\n',
		FIRSTROW = 2
	);
GO

-- ***********  Detach ***********
USE master;
GO

ALTER DATABASE [460_HW5] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

EXEC sp_detach_db '460_HW5', 'true'
