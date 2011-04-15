
drop table if exists employees;
create table employees(
 id int NOT NULL AUTO_INCREMENT, 
 first_name varchar(255),
 last_name varchar(255),
 primary key (id)
);

drop table if exists projects;
create table projects(
 id int NOT NULL AUTO_INCREMENT, 
 manager_id int,
 name varchar(255),
 primary key (id)
);

drop table if exists departments;
create table departments(
 id int NOT NULL AUTO_INCREMENT, 
 name varchar(255),
 budget decimal(17,2),

 primary key (id)
);

drop table if exists divisions;
create table divisions(
 id int NOT NULL AUTO_INCREMENT, 
 name varchar(255),
 primary key (id)
);

drop table if exists rooms;
create table rooms(
 id int NOT NULL AUTO_INCREMENT, 
 name varchar(255),
 primary key (id)
);

drop table if exists buildings;
create table buildings(
 id int NOT NULL AUTO_INCREMENT, 
 name varchar(255),
 primary key (id)
);

drop table if exists offices;
create table offices(
 id int NOT NULL AUTO_INCREMENT, 
 name varchar(255),
 primary key (id)
);



