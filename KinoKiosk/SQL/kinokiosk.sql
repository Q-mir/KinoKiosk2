create database [kinokiosk];
use [kinokiosk];



create table [Movie]
(
	[Id] int not null identity(1,1) primary key,
	[Title]nvarchar(100),
	[GenreFK] int foreign key references Genre(ID),
	[ActorFK] int foreign key references Actor(ID),
);


create table [Genre]
(
	[Id] int not null identity(1,1) primary key,
	[Name] nvarchar(50) not null,
);

create table [Actor]
(
	[Id] int not null identity(1,1) primary key,
	[Name] nvarchar(50) not null,
	
);

insert into [Genre]
values
('Fantastic'),
('Horor'),
('Blockbaster');

insert into [Actor]
values
('Ivan '),
('Petr'),
('Yuriy');

insert into [Movie]
values
('Garry Potter', 1, 1),
('Uneseniye Vetrom', 2, 2),
('Menty10', 1, 2);


SELECT * FROM [Movie] 
WHERE title LIKE '%search_text_title%';

SELECT * FROM [Movie] 
WHERE title LIKE '%search_text_title%';


