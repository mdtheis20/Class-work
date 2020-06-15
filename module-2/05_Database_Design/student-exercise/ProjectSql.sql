
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
	Values ('Clean Water', 9-9-99), ('Collect Garbage', 9-9-99), ('Wash Trucks', 9-9-99), ('Test for Covid', 9-9-99)



Insert into Department (Name)
	Values ('Water'), ('Trash'), ('Fire'), ('Health')




Insert into Employee (Last_Name, First_Name, Gender, DateOfBirth, DateOfHire, Dept_Name)
	Values ('Bob', 'Miller', 'Male', 09/09/1991, 10/10/2010, 'Water'), ('Susan', 'Soft', 'Female', 09/11/1989, 10/14/2011, 'Water'), ('Tom', 'Tucker', 'Male', 07/07/1973, 10/10/1994, 'Trash'), ('Tracy', 'Times', 'Female', 07/24/1978, 10/10/1998, 'Trash'), ('Dale', 'Downer', 'Male', 08/08/1988, 10/10/2018, 'Fire'), ('Debby', 'Downer', 'Female', 06/14/1988, 10/10/2016, 'Fire'), ('Jerry', 'Jones', 'Male', 05/08/1963, 10/10/2001, 'Health'), ('Judy', 'Baker', 'Female', 05/17/1983, 03/10/2001, 'Health')