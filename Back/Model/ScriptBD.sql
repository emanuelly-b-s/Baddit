	USE MASTER
	GO

	IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Baddit')
		DROP DATABASE Baddit
	GO

	CREATE DATABASE Baddit
	GO

	USE Baddit
	GO

	CREATE TABLE User_Baddit
	(
		Id INT PRIMARY KEY IDENTITY,
		Email VARCHAR(100) UNIQUE NOT NULL, 
		UserName VARCHAR(55) NOT NULL, 
		LastName VARCHAR(55) NOT NULL,
		DateBirth DATE NOT NULL,
		NickUser VARCHAR(25) UNIQUE NOT NULL,
		PasswordUser VARCHAR(MAX) NOT NULL,
		SaltPassword VARCHAR(MAX) NOT NULL,
		UserPhoto int
	);
	GO 

	CREATE TABLE Forum
	(
		Id INT IDENTITY PRIMARY KEY,
		Creator INT FOREIGN KEY REFERENCES User_Baddit(ID),
		ForumName VARCHAR(55) UNIQUE NOT NULL,
		DescriptionForum VARCHAR(255) NOT NULL
	);
	GO

	CREATE TABLE Roles
	(
		ID INT IDENTITY PRIMARY KEY,
		RoleName VARCHAR(55),
		Forum INT FOREIGN KEY REFERENCES Forum(ID)
	);
	GO


	CREATE TABLE Permission
	(
		ID INT PRIMARY KEY IDENTITY,
		PermissionName VARCHAR(50)
	);
	GO

	CREATE TABLE RolePermissions 
	(
		ID INT PRIMARY KEY IDENTITY,
		RoleId INT FOREIGN KEY REFERENCES Roles(ID),
		PermissionId INT FOREIGN KEY REFERENCES Permission(ID)
	);
	GO

	CREATE TABLE ListParticipantsForum
	(
		Id INT IDENTITY PRIMARY KEY,
		Forum INT FOREIGN KEY REFERENCES Forum(ID), 
		Participant INT FOREIGN KEY REFERENCES User_Baddit(ID)
	);
	GO

	CREATE TABLE Post
	(
		ID INT IDENTITY PRIMARY KEY,
		Tittle VARCHAR(100) NOT NULL,
		PostText VARCHAR(MAX) NOT NULL,
		PostDate DATE NOT NULL,
		Upvote INT, 
		Downvote INT,
		Forum INT FOREIGN KEY REFERENCES Forum(ID), 
		Participant INT FOREIGN KEY REFERENCES User_Baddit(ID)
	);
	GO


	CREATE TABLE Comment 
	(
		Id INT IDENTITY PRIMARY KEY,
		Participant INT FOREIGN KEY REFERENCES User_Baddit(ID),
		PostComment INT FOREIGN KEY REFERENCES Post(ID),
		CommentText VARCHAR(MAX) NOT NULL
	);
	GO


	CREATE TABLE UpvoteDownvote
	(
		ID INT IDENTITY PRIMARY KEY,
		Participant INT FOREIGN KEY REFERENCES User_Baddit(ID),
		Post INT FOREIGN KEY REFERENCES Post(ID)
	);

	CREATE TABLE ImageData(
		ID INT IDENTITY PRIMARY KEY,
		Photo VARBINARY(MAX) NOT NULL,  
	);
	GO

	CREATE TABLE LocationPhoto(
		ID INT IDENTITY PRIMARY KEY,
		Nome VARCHAR(60) NOT NULL,
		Photo INT FOREIGN KEY REFERENCES ImageData(ID),
		Participant INT FOREIGN KEY REFERENCES User_Baddit(ID)
	);
	GO

	select * from User_Baddit
	select * from Forum
	select * from ListParticipantsForum
	select * from Post

	insert into ListParticipantsForum values (1,2)


	alter table user_baddit drop column UserPhoto

	alter table user_baddit add UserPhoto int foreign key references imageData(ID)

	select u.nickuser, f.ForumName
	from User_Baddit as u 
	join ListParticipantsForum as l
	on u.Id  = l.participant
	join Forum as f on f.ID = l.Forum

	