-- ########### Pirates ###########
INSERT INTO [dbo].[Pirates](FirstName,LastName,NickName,ConscriptionDate)VALUES('Elias','Timbers','One-Tooth','06/29/1691');
INSERT INTO [dbo].[Pirates](FirstName,LastName,NickName,ConscriptionDate)VALUES('Polly','Dagger','Saucy Devil','11/21/1695');
INSERT INTO [dbo].[Pirates](FirstName,LastName,NickName,ConscriptionDate)VALUES('Stella','Clegg','Bearded Beast','04/01/1701');
INSERT INTO [dbo].[Pirates](FirstName,LastName,NickName,ConscriptionDate)VALUES('Jonas','Morgan','Albatross Curse','05/17/1691');
INSERT INTO [dbo].[Pirates](FirstName,LastName,NickName,ConscriptionDate)VALUES('Jilly','Jamieson','Knee Biter','08/11/1699');

-- ########### Ships ###########
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Kobayashi Maru','Galleon',213);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Intern Ship','Brigantine',163);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Serenity','Frigate',235);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Piece of Ship','Schooner',97);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('For Sail','Sloop',132);


-- ########### Crews ###########
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(1,1,513.01);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(1,2,77.99);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(1,3,153.12);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(1,4,0.23);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(1,5,13.42);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(2,1,1042.13);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(2,2,99.99);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(2,3,763.21);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(2,4,0.97);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(2,5,7.97);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(3,1,385.67);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(3,2,115.16);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(3,3,221.88);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(3,4,1.17);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(5,1,997.34);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(5,2,67.23);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(5,4,1.01);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(5,5,13.13);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(4,4,0.42);
INSERT INTO [dbo].[Crews](PirateID,ShipID,Booty)VALUES(4,5,4.53);
