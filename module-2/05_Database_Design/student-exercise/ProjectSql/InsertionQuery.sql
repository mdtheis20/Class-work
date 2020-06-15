
select * from employee 

Select * from Employee Where Dept_Name = 'Water'
Select * from Employee Where Dept_Name = 'Trash'
Select * from Employee Where Dept_Name = 'Fire'
Select * from Employee Where Dept_Name = 'Health'
Select * from Department
Select * from Project
Select * from Employee


Insert into Department_Project(DepartmentID, ProjectID)
	Values (1,1), (2,2), (3,3), (4,4)


Insert into Employee_Department (EmployeeID, DepartmentID)
	Values (1,1), (2,1), (3,2), (4,2), (5,3), (6,3), (7,4), (8,4)

	Select * from Employee
	join Employee_Department on Employee.EmployeeID = Employee_Department.EmployeeID
	join Department on Employee_Department.DepartmentID = Department.DepartmentID
	where Department.DepartmentID = 2

Insert into Employee_Project (EmployeeID, ProjectID)
	Values (1,1), (2,1), (3,2), (4,2), (5,3), (6,3), (7,4), (8,4)



Insert into Project (Name, StartDate)
	Values ('Clean Water', '2020-02-15'), ('Collect Garbage', '2020-03-15'), ('Wash Trucks','2020-01-15'), ('Test for Covid', '2020-02-15')



Insert into Department (Name)
	Values ('Water'), ('Trash'), ('Fire'), ('Health')




Insert into Employee (Last_Name, First_Name, Gender, DateOfBirth, DateOfHire, Dept_Name)
	Values ('Bob', 'Miller', 'Male','1972-06-15', '1999-07-15', 'Water'), ('Susan', 'Soft', 'Female', '1989-04-16', '2008-08-15', 'Water'), ('Tom', 'Tucker', 'Male', '1965-09-09', '2003-09-15', 'Trash'), ('Tracy', 'Times', 'Female', '1992-10-17', '2011-02-15', 'Trash'), ('Dale', 'Downer', 'Male', '1970-03-06', '2014-05-15', 'Fire'), ('Debby', 'Downer', 'Female', '1984-05-20', '2000-07-15', 'Fire'), ('Jerry', 'Jones', 'Male', '1977-06-19', '2013-10-15', 'Health'), ('Judy', 'Baker', 'Female', '1985-04-12', '2018-09-15', 'Health')