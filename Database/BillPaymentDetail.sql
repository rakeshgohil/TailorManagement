USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbBillPaymentDetail', 'U') IS NULL 
BEGIN
	CREATE TABLE tbBillPaymentDetail (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[BillId] INT FOREIGN KEY  REFERENCES tbBill(Id),
		PaidAmount DECIMAL(18,2),
		PaidDate DATETIME DEFAULT GETDATE()
	)
END
GO

CREATE OR ALTER PROCEDURE spGetBillPaymentDetails
AS
BEGIN
	SELECT Id, [BillId], PaidAmount
	FROM tbBillPaymentDetail
END
GO

CREATE OR ALTER PROCEDURE spGetBillPaymentDetailById
	@Id INT
AS
BEGIN
	SELECT Id, [BillId], PaidAmount
	FROM tbBillPaymentDetail
	WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE spSaveBillPaymentDetail
	@BillId INT, 
	@PaidAmount DECIMAL(18,2),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
	
	INSERT INTO tbBillPaymentDetail([BillId], PaidAmount)
	VALUES (@BillId, @PaidAmount);
			
	SET @Id = SCOPE_IDENTITY();
END
GO

CREATE OR ALTER PROCEDURE spUpdateBillPaymentDetail
	@BillId INT, 
	@PaidAmount DECIMAL(18,2),
	@Id INT
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE tbBillPaymentDetail
	SET 
		[BillId] = @BillId,
		PaidAmount = @PaidAmount
	WHERE Id = @Id;		
END
GO

CREATE OR ALTER TRIGGER tr_InsertPaidAmountOnBill
ON tbBillPaymentDetail
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tbBill
    SET PaidAmount = b.PaidAmount + i.PaidAmount
    FROM tbBill b
    INNER JOIN inserted i ON b.Id = i.BillId;
END
GO

CREATE OR ALTER TRIGGER tr_DeletePaidAmountOnBill
ON tbBillPaymentDetail
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tbBill
    SET PaidAmount = b.PaidAmount - d.PaidAmount
    FROM tbBill b
    INNER JOIN deleted d ON b.Id = d.BillId;
END
GO


CREATE OR ALTER PROCEDURE spDeleteBillPaymentDetailById
	@Id INT
AS
BEGIN
	DELETE
	FROM tbBillPaymentDetail
	WHERE Id = @Id
END
GO
