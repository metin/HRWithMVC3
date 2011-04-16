drop table if exists divisions;
create table divisions(
 id int NOT NULL AUTO_INCREMENT,
 name varchar(255),
 primary key (id)
) AUTO_INCREMENT = 345;

drop table if exists employees;
create table employees(
 id int NOT NULL AUTO_INCREMENT,
 first_name varchar(255),
 last_name varchar(255),
 primary key (id)
) AUTO_INCREMENT = 123;

drop table if exists buildings;
create table buildings(
 id int NOT NULL AUTO_INCREMENT,
 name varchar(255),
 year varchar(255),
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
 name varchar(255),
 division_no int,
 budget decimal(17,2),
 primary key (name)
);

drop table if exists rooms;
create table rooms(
 id int NOT NULL AUTO_INCREMENT, 
 building_code int,
 primary key (id)
) AUTO_INCREMENT = 712;

drop table if exists offices;
create table offices(
 id int NOT NULL AUTO_INCREMENT, 
 area varchar(255),
 primary key (id)
) AUTO_INCREMENT = 2325;



