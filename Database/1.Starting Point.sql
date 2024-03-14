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
INSERT INTO tbProduct([Name], Price) VALUES ('Shirt', 300)
INSERT INTO tbProduct([Name], Price) VALUES ('Pant', 300)

select * from tbBill
select * from tbBillDetail
select * from tbCustomer
select * from tbMenu
select * from tbShirt
select * from tbPant
