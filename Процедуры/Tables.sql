create database Cinema on
(name = 'Cinema', filename = 'D:\CINEMA\COURSE\Cinema.mdf', size = 10 mb)
log on(name = 'Cinema_log', filename = 'D:\CINEMA\COURSE\Cinema_log.ldf', size = 10 mb) 

EXEC sp_configure filestream_access_level, 2  
RECONFIGURE 

use Cinema;

drop table TICKETS;
drop table PURCHASE;
drop table USERS;
drop table SESSION;
drop table HALL;
drop table CINEMA;
drop table MOVIE;
drop table GENRE;
drop table ACTOR;
drop table DIRECTOR;
drop table COUNTRY;

--Genre
create table GENRE(                 
ID int primary key IDENTITY(1, 1),
NAME nvarchar(30) unique not null);

--Country
create table COUNTRY(
ID varchar(10) primary key not null,
NAME nvarchar(70) unique not null);

--Director
create table DIRECTOR(
ID uniqueidentifier primary key rowguidcol DEFAULT NEWSEQUENTIALID(),
NAME nvarchar(20) not null,
SURNAME nvarchar(20),
COUNTRY_ID varchar(10) foreign key references COUNTRY(ID),
AGE int,
IMAGE varbinary(max));

--Actor
create table ACTOR(
ID uniqueidentifier primary key rowguidcol DEFAULT NEWSEQUENTIALID(),
NAME nvarchar(20) not null,
SURNAME nvarchar(20),
COUNTRY_ID varchar(10) foreign key references Country(ID),
AGE int,
IMAGE varbinary(max));

--Movie
create table MOVIE(
ID uniqueidentifier rowguidcol DEFAULT NEWSEQUENTIALID(),
NAME nvarchar(max) not null,
RELEASE date,
COUNTRY_ID varchar(10) foreign key references COUNTRY(ID),
GENRE_ID int foreign key references GENRE(ID),
RUNNING_TIME int,
DIRECTOR_ID uniqueidentifier foreign key references DIRECTOR(ID),
SCREENPLAY nvarchar(50),
COMPOSER nvarchar(50),
ACTOR_ID uniqueidentifier foreign key references ACTOR(ID),
PLOT nvarchar(max),
IMAGE varbinary(max),
CONSTRAINT PK_Movie PRIMARY KEY CLUSTERED(ID));

--Cinema
create table CINEMA(
ID int primary key IDENTITY(1, 1),
NAME nvarchar(30) not null,
ADDRESS nvarchar(max),
WEBSITE nvarchar(max),
REGION nvarchar(30),
NUMBER_OF_HALLS int,
TICKET_OFFICE nvarchar(30));

--Hall
create table HALL(
ID int primary key IDENTITY(1, 1),
NAME NVARCHAR(30),
CINEMA_ID int foreign key references CINEMA(ID),
ROWS int not null,
SEATS int not null);

--Session
create table SESSION(
ID int primary key IDENTITY(1, 1),
MOVIE_ID uniqueidentifier foreign key references MOVIE(ID),
HALL_ID int foreign key references HALL(ID),
DATE date not null,
TIME time(7) not null,
COST int not null,
FREESEATS int);

--Users
create table USERS(
ID uniqueidentifier primary key rowguidcol DEFAULT NEWSEQUENTIALID(),
LOGIN nvarchar(50) not null,
PASSWORD nvarchar(max) not null,
EMAIL nvarchar(50) not null);

--Purchase
create table PURCHASE(
ID int primary key IDENTITY(1, 1),
USER_ID uniqueidentifier foreign key references USERS(ID),
DATE smalldatetime);
ALTER TABLE PURCHASE ADD PRICE INT;

--Tickets
create table TICKETS(
ID int primary key IDENTITY(1, 1),
SESSION_ID int foreign key references SESSION(ID),
PURCHASE_ID int foreign key references PURCHASE(ID),
ROW int not null,
SEAT int not null);

SELECT * FROM TICKETS;
SELECT * FROM PURCHASE;
SELECT * FROM USERS;

SELECT * FROM SESSION;
SELECT * FROM HALL;
SELECT * FROM CINEMA;
SELECT * FROM MOVIE;

SELECT * FROM GENRE;
SELECT * FROM ACTOR;
SELECT * FROM DIRECTOR;
SELECT * FROM COUNTRY;

delete TICKETS;
delete PURCHASE;
delete USERS;
delete SESSION;
delete HALL;
delete CINEMA WHERE NAME <> 'Центральный' AND NAME <> 'Дом кино';
delete MOVIE;

delete GENRE;
delete ACTOR;
delete DIRECTOR;
delete COUNTRY;

SELECT H.NAME FROM HALL H INNER JOIN CINEMA C ON C.ID = H.CINEMA_ID
