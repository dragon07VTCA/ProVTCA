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
select * from employees;
create table Books(
ID_Book int(11) auto_increment , constraint PK_ID_Book primary key(ID_Book),
book_title varchar(225) not null,
author varchar(225) not null,
unit_price decimal(20,0) default 0,
amount int(10) not null
);

create table Orders(
ID_Order int(11) auto_increment , constraint PK_ID_Order primary key(ID_Order),
ID_E int(11) , constraint FK_ID_E foreign key(ID_E) references Employees(ID_E),
Creation_Time datetime default now()
);

create table OrderDetails(
ID_Order int(11),constraint PK_ID_Order_Book primary key(ID_Order,ID_Book), constraint FK_ID_Order foreign key(ID_Order) references Orders(ID_Order),
ID_Book int(11),constraint FK_ID_Book foreign key (ID_Book) references Books(ID_book),
unit_price decimal(20,0) default 0,
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
values ('Lê Trường Giang','0978895541','Ha Noi','GiangVTCA','VTCA'),
      ('Đỗ Xuân Trường' , '0967824628','Ha Noi','1','1');
insert into Books(book_title,author,unit_price,amount)
values ('SLAM DUNK','Takehiko Inoue','20000','100'),
	   ('FAIRY TAIL','Mashima Hiro','25000','100'),
       ('BLEACH','Tite Kubo','30000','100'),
       ('DEATH NOTE','Tsugumi Ohba','35000','100'),
       ('DRAGON BALL','Toriyama Akira','40000','100'),
       ('NARUTO','Kishimoto Masashi','45000','100'),
       ('ONE PIECE','Eiichiro Oda','50000','100');