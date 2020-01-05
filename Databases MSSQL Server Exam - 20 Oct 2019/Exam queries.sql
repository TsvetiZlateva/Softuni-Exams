-- 1. DDL

CREATE DATABASE SERVICE

GO 

CREATE TABLE Users
(
	Id INTEGER PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INTEGER, CHECK(Age >= 14 AND Age <= 110),
	Email VARCHAR(50) NOT NULL  
)

CREATE TABLE Departments
(
	Id INTEGER PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INTEGER PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INTEGER, CHECK(Age >= 18 AND Age <= 110),
	DepartmentId INTEGER FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INTEGER PRIMARY KEY IDENTITY,
	[Name]VARCHAR(50) NOT NULL,
	DepartmentId INTEGER FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	Id INTEGER PRIMARY KEY IDENTITY,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INTEGER PRIMARY KEY IDENTITY,
	CategoryId INTEGER FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INTEGER FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INTEGER FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INTEGER FOREIGN KEY REFERENCES Employees(Id)
)

-- 2. INSERT

INSERT INTO Employees (FirstName, LastName,	Birthdate, DepartmentId)
VALUES
('Marlo',	'O Malley',	'1958-9-21', 1),
('Niki',	'Stanaghan', '1969-11-26', 4),
('Ayrton',	'Senna',	'1960-03-21',	9),
('Ronnie',	'Peterson',	'1944-02-14',	9),
('Giovanna',	'Amati',	'1959-07-20',	5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate,	[Description], UserId, EmployeeId)
VALUES
(1,	1,	'2017-04-13',	'Stuck Road on Str.133',	6,	2)
INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate,	[Description], UserId, EmployeeId)
VALUES
(6,	3,	'2015-09-05',	'2015-12-06',	'Charity trail running',	3,	5)
INSERT INTO Reports (CategoryId, StatusId, OpenDate,	[Description], UserId, EmployeeId)
VALUES
(14,	2,	'2015-09-07',		'Falling bricks on Str.58',	5,	2)
INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate,	[Description], UserId, EmployeeId)
VALUES
(4,	3,	'2017-07-03',	'2017-07-06',	'Cut off streetlight on Str.11',	1,	1)

-- 3. UPDATE

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

-- 4. DELETE

DELETE FROM Reports
WHERE StatusId = 4

-- 5. Unassigned Reports

SELECT Description, FORMAT(OpenDate, 'dd-MM-yyyy') FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]

-- 6. Reports & Categories

SELECT r.[Description], c.[Name] AS CategoryName FROM Reports r
JOIN Categories c
ON c.Id = r.CategoryId
ORDER BY r.[Description], CategoryName

-- 7. Birthday Report

SELECT u.Username, c.Name as CategoryName FROM Users u
JOIN Reports r
ON r.UserId = u.Id
JOIN Categories c
ON c.Id = r.CategoryId
WHERE FORMAT(r.OpenDate, 'dd-MM') = FORMAT(u.Birthdate, 'dd-MM')
ORDER BY u.Username, CategoryName