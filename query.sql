use master
go

if exists(select * from sys.databases where name = 'FullExample')
	drop database FullExample
go

create database FullExample
go

use FullExample
go

create table User_Dittopia
(
	ID int identity,
	Email varchar(100) primary key not null, 
	UserName varchar(55) not null, 
	LastName varchar(55) not null,
	DateBirth date not null,
	NickUser varchar(25),
	PasswordUser varchar (55) not null,
	SaldPassword varchar(max) not null
);
go 

create table Forum
(
	ID int identity primary key,
	Creator varchar(100) foreign key references User_Dittopia(Email),
	ForumName varchar(55) not null,
	DescriptionPost varchar(255) not null
);
go

create table Positions
(
	ID int identity primary key,
	PositionName varchar(55),
	Comment bit,
	Likes bit,
	Dislike bit
);
go


create table ParticipantForum
(
	ID int identity primary key,
	Forum int foreign key references Forum(ID), 
	ParticipantForum varchar(100) foreign key references User_Dittopia(Email),
	PositionParticipant int foreign key (PositionParticipant) references Positions,
);
go

create table Post
(
	ID int identity primary key,
	Tittle varchar(100) not null,
	PostText varchar(255) not null,
	Likes int,
	Dislike int,
	Comment int,
	PostDate date not null,
	Forum int foreign key references Forum(ID), 
	PostParticipant varchar(100) foreign key references User_Dittopia(Email)
);
go


create table Comment 
(
	ID int identity primary key,
	ParticipantComment varchar(100) foreign key references User_Dittopia(Email),
	PostComment int foreign key references Post(id),
	CommentText varchar(max) not null,
);
go


create table LikeDislaike 
(
	ID int identity primary key,
	ParticipantLikeDislaike varchar(100) foreign key references User_Dittopia(Email),
	PostLikeDislaike int foreign key references Post(id),
);

create table ImageData(
	ID int identity primary key,
	Photo varbinary(MAX) not null,
);
go

create table LocationPhoto(
	ID int identity primary key,
	Nome varchar(60) not null,
	Photo int foreign key references ImageData(ID),
	PostParticipant varchar(100) foreign key references User_Dittopia(Email),
	PostPhoto int foreign key references Post(id),
);
go



select * from ImageData
select * from LocationPhoto
select * from ParticipantForum
select * from Post
select * from LocationPhoto
select * from LikeDislaike
select * from Forum
select * from Comment
select * from Positions
select * from User_Dittopia
