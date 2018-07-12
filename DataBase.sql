drop database if exists DB;
create database DB;
use DB;

create table Employees(
ID_E int(11) auto_increment , constraint PK_ID_E primary key(ID_E),
full_name varchar(225) not null,
Phone_number int(20) not null,
Address varchar(225) not null,
User_name varchar(225) not null,
User_Password varchar(225) not null
);

create table Books(
ID_Book int(11) auto_increment , constraint PK_ID_Book primary key(ID_Book),
book_title varchar(225) not null,
author varchar(225) not null,
unit_price decimal(20,2) default 0,
amount int(10) not null
);

create table Orders(
ID_Order int(11) auto_increment , constraint PK_ID_Order primary key(ID_Order),
ID_E int(11) , constraint FK_ID_E foreign key(ID_E) references Employees(ID_E),
ID_Book int(11),
ID_customer int(11), constraint FK_ID_customer foreign key(ID_customer) references customers(ID_customer),
Creation_Time datetime default now(),
Note varchar(225)
);

create table OrderDetails(
ID_order int(11), constraint FK_ID_Order foreign key(ID_Order) references Orders(ID_Order),
ID_Book int(11), constraint FK_ID_Book foreign key (ID_Book) references Books(ID_book),
unit_price decimal(20,2) default 0,
quantity int not null default 1
);

delimiter $$
create trigger tg_before_insert before insert
	on Books for each row
    begin
		if new.amount < 0 then
            signal sqlstate '45001' set message_text = 'tg_before_insert: amount must > 0';
        end if;
    end $$
delimiter ;

delimiter $$
create trigger tg_CheckAmount
	before update on Books
	for each row
	begin
		if new.amount < 0 then
            signal sqlstate '45001' set message_text = 'tg_CheckAmount: amount must > 0';
        end if;
    end $$
delimiter ;

insert into Employees(full_name,Phone_number,Address,User_name,User_Password)
values ('Le Truong Giang','0978895541','Ha Noi','GiangVTCA','VTCA'),
      ('Do Xuan Truong' , '0967824628','Ha Noi','TruongVTCA','VTCA');
insert into Books(book_title,author,unit_price,amount)
values ('Ngu van','A','12000','100'),
	   ('Dai so','A','13000','100'),
       ('Tin hoc','A','11000','100'),
       ('Tieng anh','A','14000','100'),
       ('Hinh hoc','A','12000','100'),
       ('Cong nghe ','A','10000','100'),
       ('Lich su','A','14000','100');
insert into Orders(ID_Book,ID_E,Note)
values(1,1,'khong'),(1,1,'Khong'),(2,2,'Khong');
insert into Orderdetails(ID_order,ID_Book,unit_price,quantity)
values(1,1,12000,2),(1,2,13000,2),
	  (2,3,14000,4),(2,5,12000,1),(2,1,12000,3);