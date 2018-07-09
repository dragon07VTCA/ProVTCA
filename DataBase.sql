drop database if exists DB;
create database DB;
use DB;

create table Employee(
ID_E int(11) auto_increment , constraint PK_ID_E primary key(ID_E),
full_name varchar(225) not null,
email varchar(225) not null,
Phone_number int(20) not null,
Address varchar(225) not null,
User_name varchar(225) not null,
User_Password varchar(225) not null
);

create table Books(
ID_Book int(11) auto_increment , constraint PK_ID_Book primary key(ID_Book),
book_title varchar(225) not null,
author varchar(225) not null,
amount int(10) not null,
price decimal not null
);

create table Orders(
ID_Order int(11) auto_increment , constraint PK_ID_Order primary key(ID_Order),
ID_E int(11) , constraint FK_ID_E foreign key(ID_E) references Employee(ID_E),
Creation_Time datetime default now(),
Note varchar(225)
);

create table List_order_ID(
ID_order int(11), constraint FK_ID_Order foreign key(ID_Order) references Orders(ID_Order),
ID_Book int(11), constraint FK_ID_Book foreign key (ID_Book) references Books(ID_book),
Amount int(10) not null
);

