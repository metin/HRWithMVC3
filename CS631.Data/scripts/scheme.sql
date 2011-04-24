drop table if exists divisions;
create table divisions(
 id int NOT NULL AUTO_INCREMENT,
 name varchar(255),
 DivHead int  default 0,
 primary key (id)
) AUTO_INCREMENT = 345;

drop table if exists employees;
create table employees(
 id int NOT NULL AUTO_INCREMENT,
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
 primary key (id)
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
 id int NOT NULL AUTO_INCREMENT,
 name varchar(255),
 manager_id int,
 budget decimal(15, 2),
 date_started date,
 date_ended date,
 primary key (id)
) AUTO_INCREMENT = 567;

drop table if exists departments;
create table departments(
 id int NOT NULL AUTO_INCREMENT, 
 name varchar(255),
 division_no int,
 DeptHead int default 0,
 DivID int  default 0,
 budget decimal(17,2),
 primary key (id),
 unique(name)

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



