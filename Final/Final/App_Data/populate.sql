-- ########### Artists ###########
INSERT INTO [dbo].[Artists](FirstName,LastName,BirthDate,BirthCity,BirthCountry)VALUES('M.C.','Escher','06/17/1898','Leeuwarden','Netherlands');
INSERT INTO [dbo].[Artists](FirstName,LastName,BirthDate,BirthCity,BirthCountry)VALUES('Leonardo','Da Vinci','05/02/1519','Vinci','Italy');
INSERT INTO [dbo].[Artists](FirstName,LastName,BirthDate,BirthCity,BirthCountry)VALUES('Hatip Mehmed','Efendi','11/19/1680','Unknown','Unknown');
INSERT INTO [dbo].[Artists](FirstName,LastName,BirthDate,BirthCity,BirthCountry)VALUES('Salvador','Dali','05/11/1904','Figueres','Spain');

-- ########### Genres ###########
INSERT INTO [dbo].[Genres](Name)VALUES('Tesselation');
INSERT INTO [dbo].[Genres](Name)VALUES('Surrealism');
INSERT INTO [dbo].[Genres](Name)VALUES('Portrait');
INSERT INTO [dbo].[Genres](Name)VALUES('Renaissance');

-- ########### ArtWorks ###########
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Circle Limit III',1);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Twon Tree',1);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Mona Lisa',2);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('The Vitruvian Man',2);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Ebru',3);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Honey Is Sweeter Than Blood',4);

-- ########### Classifications ###########
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(1,1);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(2,1);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(2,2);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(3,3);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(3,4);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(4,4);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(5,1);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(6,2);
