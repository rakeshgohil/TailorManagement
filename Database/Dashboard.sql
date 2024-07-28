USE TailorManagementDB
GO

--EXEC spGetDeliveryDues 2
--EXEC spGetPaymentDues 2

CREATE OR ALTER PROCEDURE spGetDeliveryDues
@DelDueDays INT
AS
BEGIN
	SELECT B.Id BillId, B.BillNo, C.Mobile, C.[Name], B.BillDate, B.DeliveryDate, B.TotalAmount, B.DueAmount,
	B.PaidAmount
	FROM tbBill B
	INNER JOIN tbCustomer C ON C.Id = B.CustomerId 
	WHERE B.DeliveryDate > DATEADD(day, -10, GETDATE()) AND B.DeliveryDate <= DATEADD(day, @DelDueDays, GETDATE())
	ORDER BY B.BillNo
END
GO

CREATE OR ALTER PROCEDURE spGetPaymentDues
@PayDueDays INT
AS
BEGIN
	SELECT B.Id BillId, B.BillNo, C.Mobile, C.[Name], B.BillDate, B.DeliveryDate, B.TotalAmount, B.DueAmount,
	B.PaidAmount
	FROM tbBill B
	INNER JOIN tbCustomer C ON C.Id = B.CustomerId 
	WHERE  B.DeliveryDate <= DATEADD(day, -@PayDueDays, GETDATE()) AND B.TotalAmount > B.PaidAmount
	ORDER BY B.BillNo
END
GO

