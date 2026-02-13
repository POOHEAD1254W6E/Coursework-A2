DELETE FROM dbo.Employees;
DELETE FROM dbo.EmploymentStatus;
DBCC CHECKIDENT ('dbo.Employees', RESEED, 0);
DBCC CHECKIDENT ('dbo.EmploymentStatus', RESEED, 0);