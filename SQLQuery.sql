create Database Day7Assignment
use Day7Assignment

create table Books
(BookId int primary key,
Title nvarchar(50),
Author nvarchar(50),
Genere nvarchar(50),
Quantity int)

insert into Books values(1,'Raja Shivchatrapati','Babasaheb Purandare','Novel',150000)
insert into Books values(2,'Ikigai','Francesc Miralles','Fiction',100000)

select * from Books
