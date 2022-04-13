create database AviaDB;
GO
USE AviaDB;

create table Roles(
	ID int not null identity(1,1) primary key,
	Title nvarchar(15) not null,
);

USE AviaDB;
INSERT INTO Roles (Title) values (N'Администратор');
USE AviaDB;
INSERT INTO Roles (Title) values (N'Кассир');

create table Users(
	ID_User int not null identity(1,1) primary key,
	Firstname nvarchar(30) not null,
	Lastname nvarchar(30) not null,
	Patronymic nvarchar(30),
	Login nvarchar(15) not null unique,
	Password nvarchar(32) not null,
	Role_ID int not null,
	foreign key (Role_ID) references Roles(ID)
);

insert into Users (Firstname, Lastname, Patronymic, Login, Password, Role_ID)
values (N'Гришин', N'Павел', N'Сергеевич', N'admin', N'Admin_5', 1);

insert into Users (Firstname, Lastname, Patronymic, Login, Password, Role_ID)
values (N'Привалов', N'Иван', N'Владимирович', N'Cashier_1', N'nk-g.G', 2);


create table PassportType(
	ID_Type int not null identity(1,1) primary key,
	Title nvarchar(20) not null unique
);

insert into PassportType (Title)
values (N'Паспорт РФ'), (N'Заграничный паспорт');

create table PlaneType(
	ID_Type int not null identity(1,1) primary key,
	Title nvarchar(20) not null unique
);

insert into PlaneType (Title)
values (N'Пассажирский'),(N'Грузовой');

create table FlightType(
	ID_Type int not null identity(1,1) primary key,
	Title nvarchar(20) not null unique
);

insert into FlightType (Title)
values (N'Внутренний'),(N'Международный'),(N'Чартерный'),(N'Грузовой'),(N'Специальные');

create table Status(
	ID_Status int not null identity(1,1) primary key,
	Title nvarchar(15) not null unique
);


insert into Status (Title)
values (N'По расписанию'),(N'Отменён'),(N'Задержан'),(N'Улетел');

create table Flight (
	ID_Flight int not null identity(1,1) primary key,
	Ticket_Cost decimal(38,2),
	Departure_Date date not null,
	Arrival_Date date not null,
	Departure_Time nvarchar(5) not null,
	Arrival_Time nvarchar(5) not null,
	Departure_Point nvarchar(20) not null,
	Transfer_Point nvarchar(20),
	Arrival_Point nvarchar(20) not null,
	Places_Left int,
	Status_ID int not null,
	Plane_Type_ID int not null,
	Flight_Type_ID int not null,

	foreign key (Status_ID) references Status(ID_Status),
	foreign key (Plane_Type_ID) references PlaneType(ID_Type),
	foreign key (Flight_Type_ID) references FlightType(ID_Type)
);
USE AviaDB;
insert into Flight (Ticket_Cost, Departure_Date, Arrival_Date, Departure_Time, Arrival_Time, Departure_Point, Arrival_Point, Places_Left, Status_ID, Plane_Type_ID, Flight_Type_ID)
values (2500.0, N'2022-03-12', N'2022-03-12', N'12:00', N'17:00', N'Москва',N'Волгоград', 100, 1, 1, 1);


create table Passenger(
	ID_Passenger int not null identity(1,1) primary key,
	Firstname nvarchar(30) not null,
	Lastname nvarchar(30) not null,
	Patronymic nvarchar(30),
	Passport_Series nvarchar(4) not null,
	Passport_Number nvarchar(7) not null,
	Passport_Type_ID int not null,
	Flight_ID int not null,

	foreign key (Passport_Type_ID) references PassportType(ID_Type),
	foreign key (Flight_ID) references Flight(ID_Flight)
);
