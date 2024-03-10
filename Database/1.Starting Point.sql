USE TailorManagementDB
GO

--SQL Script Execution Sequence, dont change the following order
--CreateDB.sql
--Customer.sql
--Menu.sql
--Shirt.sql
--Pant.sql
--Bill.sql

--Below are some userful query 
INSERT INTO tbShirt ([Length], Chest) VALUES ('S', '36');
INSERT INTO tbShirt ([Length], Chest) VALUES ('M', '38');
INSERT INTO tbShirt ([Length], Chest) VALUES ('L', '40');
INSERT INTO tbShirt ([Length], Chest) VALUES ('XL', '42');

select * from tbBill
select * from tbBillDetail
select * from tbCustomer
select * from tbMenu
select * from tbShirt
select * from tbPant
