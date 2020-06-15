
-- Make sure we are not using some other db

use master

Go 

--Drop the existing DB if it already exists

Drop database if exists ProjectOrganizer




--Create a new art gallery database
Create Database ProjectOrganizer
GO

Use ProjectOrganizer
GO
Alter Authorization On Database::[ProjectOrganizer] TO [sa]
Go


Create table Employee (
	EmployeeID int Identity Primary Key,
	Last_Name nvarchar(100) not null,
	First_Name nvarchar(100) not null,
	Gender nvarchar(100) not null,
	DateOfBirth datetime not null,
	DateOfHire datetime not null,
	Dept_Name nvarchar(100) not null,

)


Create table Department(
	DepartmentID int Identity Primary Key,
	Name nvarchar(100) not null,


)


Create table Project(
	ProjectID int Identity Primary Key,
	Name nvarchar(100) not null,
	StartDate datetime not null,

)


Create table Employee_Department(
	EmployeeID int,
	DepartmentID int,
	Constraint pk_Employee_Department Primary Key (EmployeeID, DepartmentID),
	Constraint fk_Employee_Department_Employee Foreign Key (EmployeeID) references Employee(EmployeeID),
	Constraint fk_Employee_Department_Department Foreign Key (DepartmentID) references Department(DepartmentID)


)


Create table Department_Project(
	DepartmentID int,
	ProjectID int,
	Constraint pk_Department_Project Primary Key (DepartmentID, ProjectID),
	Constraint fk_Department_Project_Department Foreign Key (DepartmentID) references Department(DepartmentID),
	Constraint fk_Department_Project_Project Foreign Key (ProjectID) references Project(ProjectID)


)


Create table Employee_Project(
	EmployeeID int,
	ProjectID int,
	Constraint pk_Employee_Project Primary Key (EmployeeID, ProjectID),
	Constraint fk_Employee_Project_Project Foreign Key (ProjectID) references Project(ProjectID),
	Constraint fk_Employee_Project_Employee Foreign Key (EmployeeID) references Employee(EmployeeID)


)