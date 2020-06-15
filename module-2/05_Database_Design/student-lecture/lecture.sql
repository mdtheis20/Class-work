
-- Make sure we are not using some other db

use master

Go 

--Drop the existing DB if it already exists

Drop database if exists ArtGalleryDB




--Create a new art gallery database
Create Database ArtGalleryDB
GO

Use ArtGalleryDB
GO
Alter Authorization On Database::[ArtGalleryDB] TO [sa]
Go
Create Table Person (
	PersonID int Identity,
	Name nvarchar(100) not null,
	Address nvarchar(200),
	Phone nvarchar(20),
	Constraint pk_Person Primary Key (PersonID)
)


Create table Art(
	ArtId int Identity Primary Key,
	Title nvarchar(100) not null,
)

Create Table PersonArt(
	PersonID int,
	ArtId int,
	Constraint pk_PersonArt Primary Key (PersonID, ArtId),
	Constraint fk_PersonArt_Person Foreign Key (PersonID) references Person(PersonID),
	Constraint fk_PersonArt_Art Foreign Key (ArtId) references Art(ArtId)
)


Create Table Purchase(
	PurchaseId int Identity Primary Key,
	ArtId int not null,
	PersonId int not null,
	PurchaseDate datetime not null,
	Price money not null,
	Constraint fk_Purchase_Person Foreign Key (PersonID) References Person(PersonID),
	Constraint fk_Purchase_Art Foreign Key (ArtId) references Art(ArtId)
)



