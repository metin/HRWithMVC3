SET foreign_key_checks = 0;
drop table if exists DIVISIONS;
create table DIVISIONS(
 DivID int NOT NULL AUTO_INCREMENT,
 DivName varchar(255),
 DivHead int NULL,
 DivHeadDept int NULL,
 primary key (DivID),
 KEY (DivHead),
 CONSTRAINT FOREIGN KEY (DivHead) REFERENCES Employees(EmpID)
) AUTO_INCREMENT = 472;

drop table if exists DEPARTMENTS;
create table DEPARTMENTS(
 DeptID int NOT NULL AUTO_INCREMENT, 
 DeptName varchar(255),
 DeptHead  int NULL,
 DeptBudget decimal(17,2),
 DivID int,
 primary key (DeptID),
 KEY (DeptHead),
 KEY (DivID),
 CONSTRAINT FOREIGN KEY (DeptHead) REFERENCES Employees(EmpID),
 CONSTRAINT FOREIGN KEY (DivID) REFERENCES Divisions(DivID)

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
 primary key (ProjID),
 CONSTRAINT FOREIGN KEY (ProjManager) REFERENCES Employees(EmpID),
 CONSTRAINT FOREIGN KEY (ProjDept) REFERENCES Departments(DeptID)
) AUTO_INCREMENT = 23928;

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
) AUTO_INCREMENT = 1242;

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
 EmpType varchar(10),
 HourRate decimal(14,2),
 primary key (EmpID)
) AUTO_INCREMENT = 13412;


drop table if exists EMPPROJECTS;
create table EMPPROJECTS(
 EmpProj int NOT NULL AUTO_INCREMENT,
 ProjID int,
 EmpID int,
 Role varchar(30),
 TotalHours decimal(17,2),
 StartDate datetime,
 EndDate datetime,
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
) AUTO_INCREMENT = 10000;

drop table if exists OFFICES;
create table OFFICES(
 OfficeID int NOT NULL AUTO_INCREMENT,
 BuildingID int,
 OfficeNumber varchar(10), 
 Area decimal(7,2),
 RoomType varchar(10),
 DeptID int,
  primary key (OfficeID)
) AUTO_INCREMENT = 1000;

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
 MonthHours int,
 MonthSalary decimal(17,2),
 FedTax decimal(17,2),
 StateTax decimal(17,2),
 OtherTax decimal(17,2),
 NetPay decimal(17,2),
 primary key (HistoryID)
) AUTO_INCREMENT = 1;

drop table if exists PROJBUGS;
create table PROJBUGS(
 BugID int NOT NULL AUTO_INCREMENT,
 ProjID int,
 Details varchar(500),
 DateReported date,
 DateClosed date,
 Status varchar(255),
 Type varchar(255),
 EmpID int,
 primary key(BugID)
) AUTO_INCREMENT = 10000;

SET foreign_key_checks = 1;