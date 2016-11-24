-- Create tables and populate with seed data
--    follow naming convention: "Requests" table contains rows that are each "Request" objects

-- ***********  Attach ***********
CREATE DATABASE [460_HW7] ON
PRIMARY (NAME=[460_HW7], FILENAME='$(dbdir)\460_HW7.mdf')
LOG ON (NAME=[460_HW7_log], FILENAME='$(dbdir)\460_HW7_log.ldf');
--FOR ATTACH;
GO

USE [460_HW7];
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.StockRequests','S') IS NOT NULL
	DROP TABLE [dbo].[StockRequests];
GO


-- ########### Users ###########
CREATE TABLE [dbo].[StockRequests]
(
    [ID] INT IDENTITY (1,1) NOT NULL,
	[StockSymbol] NVARCHAR (25) NOT NULL,
	[Date] DATETIME NOT NULL,
	[IP_Address] NVARCHAR (15) NOT NULL,
	[Browser] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

-- ***********  Detach ***********
USE master;
GO

ALTER DATABASE [460_HW7] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

EXEC sp_detach_db '460_HW7', 'true'
