create database TPT
go
use TPT
go
create table dbo.Allegiance
(
	ID int identity,
	Name varchar(50),
	constraint PK_Allegiance
		primary key (ID)
)
go
create table dbo.Sentient
(
	ID int identity,
	Name varchar(50),
	AllegianceID int,
	constraint PK_Sentient
		primary key (ID),
	constraint FK_Sentient_AllegianceID
		foreign key (AllegianceID)
		references dbo.Allegiance (ID)
)
go
create table dbo.Jedi
(
	ID int,
	LightsaberColor varchar(50),
	MidichlorianCount int,
	constraint PK_Jedi
		primary key (ID),
	constraint FK_Jedi_Id
		foreign key (ID)
		references dbo.Sentient (ID)
)
go
create table dbo.Droid
(
	ID int,
	DroidType varchar(50),
	constraint PK_Droid
		primary key (ID),
	constraint FK_Droid_Id
		foreign key (ID)
		references dbo.Sentient (ID)
)
go
create table dbo.Other
(
	ID int,
	Title varchar(50),
	IsMale bit,
	constraint PK_Other
		primary key (ID),
	constraint FK_Other_ID
		foreign key (ID)
		references dbo.Sentient(ID)
)
go
insert dbo.Allegiance values
	('Rebel'),
	('Imperial')
	
insert dbo.Sentient (Name, AllegianceID)
values
	('Ben Kenobi', 1),
	('Luke Skywalker', 1),
	('Darth Vader', 2),
	('R2-D2', 1),
	('C-3PO', 1),
	('Han Solo', 1),
	('Leia Organa', 1),
	('Wilhulff Tarkin', 2)

insert dbo.Jedi (ID, LightsaberColor, MidichlorianCount)
values
	(1, 'Blue', 9000),
	(2, 'Green', 9001),
	(3, 'Red', 8999)
	
insert dbo.Droid (ID, DroidType)
values
	(4, 'Utility'),
	(5, 'Protocol')
	
insert dbo.Other (ID, Title, IsMale)
values
	(6, 'Captain', 1),
	(7, 'Princess', 0),
	(8, 'Grand Moff', 1)
go
exec dbo.drop_if_exists 'Sentient_Select_TPT'
go
create procedure dbo.Sentient_Select_TPT
as
set nocount on

select *
from dbo.Sentient

select *
from dbo.Droid

select *
from dbo.Jedi

select *
from dbo.Other
go