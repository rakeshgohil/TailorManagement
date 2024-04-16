USE TailorManagementDB
GO

--SQL Script Execution Sequence, dont change the following order
--CreateDB.sql
--Customer.sql
--Product.sql
--Shirt.sql
--Pant.sql
--Bill.sql
--ShirtConfiguration.sql
--PantConfiguration.sql
--InsertData.sql
--BillPaymentDetail.sql
--CompanyConfiguration.sql

DECLARE @BillNo AS INT = 4
DECLARE @BillId AS INT

SELECT @BillId = a.Id FROM tbBill a WHERE BillNo = @BillNo 
SELECT * FROM tbBill WHERE Id = @BillId
SELECT * FROM tbBillDetail WHERE BillId = @BillId
SELECT * FROM tbBillPaymentDetail WHERE BillId = @BillId
SELECT * FROM tbCustomer WHERE Id in (SELECT CustomerId from tbBill WHERE Id = @BillId)
SELECT * FROM tbShirt WHERE CustomerId in (SELECT CustomerId from tbBill WHERE Id = @BillId)
SELECT * FROM tbPant WHERE CustomerId in (SELECT CustomerId from tbBill WHERE Id = @BillId)

SELECT * FROM tbProduct
--SELECT * FROM tbShirtConfiguration
--SELECT * FROM tbPantConfiguration

--EXEC spGetPantByCustomerId 1
--EXEC spGetShirtByCustomerId 1

