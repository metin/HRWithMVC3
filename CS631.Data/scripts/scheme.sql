drop table if exists divisions;
create table divisions(
 DivID int NOT NULL AUTO_INCREMENT,
 DivName varchar(255),
 DivHead int  default 0,
 DivHeadDept int,
 primary key (DivID)
) AUTO_INCREMENT = 345;

drop table if exists employees;
create table employees(
 EmpID int NOT NULL AUTO_INCREMENT,
 EmpLName varchar(255),
 EmpFName varchar(255),
 EmpMI varchar(3),
 EmpTitle varchar(255),
 EmpBuilding int,
 EmpOffice int,
 EmpPhone int,
 EmpDept int,
 EmpDiv int,
 EmpProj int,
 EmpType varchar(255),
 HourRate decimal(10,2),
 MonthHours int,
 primary key (EmpID)
) AUTO_INCREMENT = 123;

drop table if exists buildings;
create table buildings(
 id int NOT NULL AUTO_INCREMENT,
 name varchar(255),
 code varchar(255),
 year int,
 cost decimal(15, 2),
 primary key (id)
) AUTO_INCREMENT = 234;

drop table if exists projects;
create table projects(
 ProjID int NOT NULL AUTO_INCREMENT,
 ProjName varchar(255),
 ProjBudget decimal(15, 2),
 ProjManager int,
 StartDate date,
 EndDate date,
 ProjDept int,
 primary key (ProjID)
) AUTO_INCREMENT = 567;

drop table if exists departments;
create table departments(
 DeptID int NOT NULL AUTO_INCREMENT, 
 DeptName varchar(255),
 DeptHead int default 0,
 DeptBudget decimal(17,2),
 DivID int  default 0,
 primary key (id)
);

drop table if exists rooms;
create table rooms(
 id int NOT NULL AUTO_INCREMENT, 
 building_id int,
 code varchar(255),
 primary key (id)
) AUTO_INCREMENT = 712;

drop table if exists offices;
create table offices(
 id int NOT NULL AUTO_INCREMENT, 
 area varchar(255),
 primary key (id)
) AUTO_INCREMENT = 2325;



