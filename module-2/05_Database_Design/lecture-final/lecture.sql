-- Make sure we are not using some other db
use master
Go


-- Drop the existing db isf it already exists
Drop database if exists ArtGalleryDB

-- Create the new Art Gallery database
Create Database ArtGalleryDB
GO 

Use ArtGalleryDB
GO

ALTER AUTHORIZATION ON DATABASE::[ArtGalleryDB] TO [sa]
GO

Create Table Person (
	PersonId int Identity,
	Name nvarchar(100) not null,
	Address nvarchar(200),
	Phone nvarchar(20),
	Constraint pk_Person Primary Key (PersonId)
)

Create table Art(
	ArtId int Identity Primary Key,
	Title nvarchar(100) not null
)

Create Table PersonArt(
	PersonId int,
	ArtId int,
	Constraint pk_PersonArt Primary Key (PersonId, ArtId),
	Constraint fk_PersonArt_Person Foreign Key (PersonId) References Person(PersonId),
	Constraint fk_PersonArt_Art Foreign Key (ArtId) References Art(ArtId)
)

Create Table Purchase (
	PurchaseId int Identity Primary Key,
	ArtId int not null,
	PersonId int not null,
	PurchaseDate datetime not null,
	Price money not null,
	Constraint fk_Purchase_Person Foreign Key (PersonId) References Person(PersonId),
	Constraint fk_Purshase_Art Foreign Key (ArtId) references Art(ArtId)
)

