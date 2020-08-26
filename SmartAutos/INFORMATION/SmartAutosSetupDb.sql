IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = 'SmartAutos' OR name = 'SmartAutos')))
BEGIN
	DROP DATABASE [SmartAutos]
END;
GO

CREATE DATABASE[SmartAutos];
GO

CREATE TABLE [SmartAutos].dbo.Manufacturer (
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	Name VARCHAR(250) NOT NULL
);

CREATE TABLE [SmartAutos].dbo.Model (
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	Name VARCHAR(250) NOT NULL,
	ManufacturerId int FOREIGN KEY REFERENCES [SmartAutos].dbo.Manufacturer(Id)
);

CREATE TABLE [SmartAutos].dbo.Colour (
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	Name VARCHAR(250) NOT NULL
);

CREATE TABLE [SmartAutos].dbo.Vehicle (
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	Model INT FOREIGN KEY REFERENCES [SmartAutos].dbo.Model(Id),
	EngineSize INT NOT NULL,
	Colour INT FOREIGN KEY REFERENCES [SmartAutos].dbo.Colour(Id),
	Registration VARCHAR(8) NOT NULL,
	Mileage INT NOT NULL
);
GO

-- Seed some basic data
SET IDENTITY_INSERT [SmartAutos].dbo.Manufacturer ON;
GO

INSERT [SmartAutos].dbo.Manufacturer (Id, Name) VALUES (1, 'Audi');
INSERT [SmartAutos].dbo.Manufacturer (Id, Name) VALUES (2, 'SAAB');
INSERT [SmartAutos].dbo.Manufacturer (Id, Name) VALUES (3, 'Honda');
INSERT [SmartAutos].dbo.Manufacturer (Id, Name) VALUES (4, 'Renault');
INSERT [SmartAutos].dbo.Manufacturer (Id, Name) VALUES (5, 'BMW');
INSERT [SmartAutos].dbo.Manufacturer (Id, Name) VALUES (6, 'Mazda');
GO

SET IDENTITY_INSERT [SmartAutos].dbo.Manufacturer OFF;
GO

INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('R8', 1);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('A3', 1);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('900', 2);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('Civic', 3);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('Jazz', 3);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('Megane', 4);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('Clio', 4);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('3 Series', 5);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('5 Series', 5);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('MX 5', 6);
INSERT [SmartAutos].dbo.Model (Name, ManufacturerId) VALUES ('3', 6);
GO 

INSERT [SmartAutos].dbo.Colour (Name) VALUES ('Black');
INSERT [SmartAutos].dbo.Colour (Name) VALUES ('Red');
INSERT [SmartAutos].dbo.Colour (Name) VALUES ('Green');
INSERT [SmartAutos].dbo.Colour (Name) VALUES ('Yellow');
INSERT [SmartAutos].dbo.Colour (Name) VALUES ('Blue');
GO
