drop table if exists DIVISIONS;
create table DIVISIONS(
 	 int NOT NULL AUTO_INCREMENT,
 DivName varchar(255),
 DivHead int,
 DivHeadDept int,
 primary key (DivID)
) AUTO_INCREMENT = 145;

drop table if exists DEPARTMENTS;
create table DEPARTMENTS(
 DeptID int NOT NULL AUTO_INCREMENT, 
 DeptName varchar(255),
 DeptHead int,
 DeptBudget decimal(17,2),
 DivID int,
 primary key (DeptID)
) AUTO_INCREMENT = 341;

drop table if exists PROJECTS;
create table PROJECTS(
 ProjID int NOT NULL AUTO_INCREMENT,
 ProjName varchar(255),
 ProjBudget decimal(15, 2),
 ProjManager int,
 StartDate date,
 EndDate date,
 ProjDept int,
  primary key (ProjID)
) AUTO_INCREMENT = 238;

drop table if exists PROJMILESTONES;
create table PROJMILESTONES(
 MilestoneID int NOT NULL AUTO_INCREMENT,
 ProjID int,
 MilestonePlannedDate date,
 MilestoneDeliverable varchar(255),
 MilestoneDeliveryDate date,
 Delivered varchar(255),
 ToBeDelivered varchar(255),
 primary key(MilestoneID)
) AUTO_INCREMENT = 1;

drop table if exists EMPLOYEES;
create table EMPLOYEES(
 EmpID int NOT NULL AUTO_INCREMENT,
 EmpLName varchar(50),
 EmpFName varchar(50),
 EmpMI varchar(1),
 EmpTitle varchar(50),
 EmpBuilding int,
 EmpOffice int,
 EmpPhone int,
 EmpDept int,
 EmpDiv int,
 EmpProj int,
 EmpType varchar(1),
 HourRate decimal(4,2),
 primary key (EmpID)
) AUTO_INCREMENT = 1;


drop table if exists EMPPROJECTS;
create table EMPPROJECTS(
 EmpProj int,
 EmpID int,
 Role varchar(30),
 TotalHours decimal(3,2),
 primary key (EmpProj,EmpID)
) AUTO_INCREMENT = 1;

drop table if exists BUILDINGS;
create table BUILDINGS(
 BuildingID int NOT NULL AUTO_INCREMENT,
 BuildingCode varchar(10) NOT NULL,
 BuildingName varchar(255),
 YearAcquired int,
 BuildingCost decimal(15,2),
 AcqType varchar(1),
 primary key (BuildingID)
) AUTO_INCREMENT = 1;

drop table if exists OFFICES;
create table OFFICES(
 OfficeID int NOT NULL AUTO_INCREMENT,
 BuildingID int,
 OfficeNumber varchar(10), 
 Area decimal(7,2),
 RoomType varchar(10),
 DeptID int,
  primary key (OfficeID)
) AUTO_INCREMENT = 1;

drop table if exists PHONES;
create table PHONES(
 PhoneID int NOT NULL AUTO_INCREMENT,
 PhoneNo int(10) NOT NULL, 
 BuildingID int,
 OfficeID int, 
 primary key (PhoneID)
)AUTO_INCREMENT = 1;

drop table if exists JOBS;
create table JOBS(
 JobID int, 
 JobTitle varchar(255),
 primary key (JobID)
) AUTO_INCREMENT = 1;

drop table if exists EMPJOBS;
create table EMPJOBS(
 EmpID int,
 JobID int, 
 JobStartDate date,
 primary key (EmpID,JobID)
) AUTO_INCREMENT = 1;

drop table if exists EMPSALARIES;
create table EMPSALARIES(
 EmpID int NOT NULL AUTO_INCREMENT,
 SalaryStartDate date,
 AnnualSalary decimal(8,2),
 primary key (EmpID,SalaryStartDate)
) AUTO_INCREMENT = 1;

drop table if exists PAYROLLHISTORY;
create table PAYROLLHISTORY(
 HistoryID int NOT NULL AUTO_INCREMENT,
 EmpID int,
 PayDate date NOT NULL,
 MonthHours decimal(3,2),
 MonthSalary decimal(7,2),
 FedTax decimal(7,2),
 StateTax decimal(7,2),
 OtherTax decimal(7,2),
 NetPay decimal(7,2),
 primary key (HistoryID)
) AUTO_INCREMENT = 1;
