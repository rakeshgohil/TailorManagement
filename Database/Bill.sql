USE TailorManagementDB
GO

--DROP TABLE dbo.tbBillDetail
--DROP TABLE dbo.tbBill

IF OBJECT_ID('dbo.tbBill', 'U') IS NULL 
BEGIN
	CREATE TABLE tbBill (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[CustomerId] INT FOREIGN KEY  REFERENCES tbCustomer(Id),
		BillNo INT UNIQUE,
		BillDate DATETIME,
		DeliveryDate DATETIME,
		TrialDate DATETIME,		
		ExtraCost DECIMAL(18,2),
		Discount DECIMAL(18,2),
		TotalAmount DECIMAL(18,2),
		PaidAmount DECIMAL(18,2),
		DueAmount AS (TotalAmount - PaidAmount)
	)
END
GO

IF OBJECT_ID('dbo.tbBillDetail', 'U') IS NULL 
BEGIN
	CREATE TABLE tbBillDetail (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[BillId] INT FOREIGN KEY  REFERENCES tbBill(Id),
		ProductId INT FOREIGN KEY  REFERENCES tbProduct(Id),
		Qty DECIMAL(18,2),
		Price DECIMAL(18,2),
		Total AS (Qty * Price)
	)
END
GO

CREATE OR ALTER PROCEDURE spSaveBillDetail
	@BillId INT,
	@ProductId INT,
	@Qty DECIMAL(18,2),
	@Price DECIMAL(18,2),
	@Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tbBillDetail (BillId, ProductId, Qty, Price)
    VALUES (@BillId, @ProductId, @Qty, @Price);

    SET @Id = SCOPE_IDENTITY();
END
GO

CREATE OR ALTER PROCEDURE spSaveBill
	@CustomerId INT,
	@BillDate DATETIME,
	@DeliveryDate DATETIME,
	@TrialDate DATETIME,		
	@ExtraCost DECIMAL(18,2),		
	@Discount DECIMAL(18,2),
	@TotalAmount DECIMAL(18,2),
	@Id INT OUTPUT,
	@BillNo INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
		
	SELECT @BillNo = ISNULL(MAX(BillNo), 0) + 1 FROM tbBill
	INSERT INTO tbBill(BillDate, BillNo, CustomerId, DeliveryDate, ExtraCost, Discount, TotalAmount, PaidAmount, TrialDate)
    VALUES (@BillDate, @BillNo, @CustomerId, @DeliveryDate, @ExtraCost, @Discount, @TotalAmount, 0, @TrialDate)

    SET @Id = SCOPE_IDENTITY();
END
GO

CREATE OR ALTER PROCEDURE spSaveBillFromUI
	@Name NVARCHAR(100),
	@Mobile NVARCHAR(10),
	@PantLength1 NVARCHAR(10), @PantLength2 NVARCHAR(10), @PantLength3 NVARCHAR(10), @PantLength4 NVARCHAR(10), @PantLength5 NVARCHAR(10),
	@Kamar1 NVARCHAR(10), @Kamar2 NVARCHAR(10), @Kamar3 NVARCHAR(10), @Kamar4 NVARCHAR(10), @Kamar5 NVARCHAR(10),
	@Seat1 NVARCHAR(10), @Seat2 NVARCHAR(10), @Seat3 NVARCHAR(10), @Seat4 NVARCHAR(10), @Seat5 NVARCHAR(10),
	@Jangh1 NVARCHAR(10), @Jangh2 NVARCHAR(10), @Jangh3 NVARCHAR(10), @Jangh4 NVARCHAR(10), @Jangh5 NVARCHAR(10),
	@Gothan1 NVARCHAR(10), @Gothan2 NVARCHAR(10), @Gothan3 NVARCHAR(10), @Gothan4 NVARCHAR(10), @Gothan5 NVARCHAR(10),
	@Jolo1 NVARCHAR(10), @Jolo2 NVARCHAR(10), @Jolo3 NVARCHAR(10), @Jolo4 NVARCHAR(10), @Jolo5 NVARCHAR(10),
	@Moli1 NVARCHAR(10), @Moli2 NVARCHAR(10), @Moli3 NVARCHAR(10), @Moli4 NVARCHAR(10), @Moli5 NVARCHAR(10),
	@PantNotes NVARCHAR(MAX),
	@ShirtLength1 NVARCHAR(10), @ShirtLength2 NVARCHAR(10), @ShirtLength3 NVARCHAR(10), @ShirtLength4 NVARCHAR(10), @ShirtLength5 NVARCHAR(10),
	@Chati1 NVARCHAR(10), @Chati2 NVARCHAR(10), @Chati3 NVARCHAR(10), @Chati4 NVARCHAR(10), @Chati5 NVARCHAR(10),
	@Solder1 NVARCHAR(10), @Solder2 NVARCHAR(10), @Solder3 NVARCHAR(10), @Solder4 NVARCHAR(10), @Solder5 NVARCHAR(10),
	@Bye1 NVARCHAR(10), @Bye2 NVARCHAR(10), @Bye3 NVARCHAR(10), @Bye4 NVARCHAR(10), @Bye5 NVARCHAR(10),
	@Front1 NVARCHAR(10), @Front2 NVARCHAR(10), @Front3 NVARCHAR(10), @Front4 NVARCHAR(10), @Front5 NVARCHAR(10),
	@Kolor1 NVARCHAR(10), @Kolor2 NVARCHAR(10), @Kolor3 NVARCHAR(10), @Kolor4 NVARCHAR(10), @Kolor5 NVARCHAR(10),
	@Cuff1 NVARCHAR(10), @Cuff2 NVARCHAR(10), @Cuff3 NVARCHAR(10), @Cuff4 NVARCHAR(10), @Cuff5 NVARCHAR(10),
	@ShirtNotes NVARCHAR(MAX),
	@BillDate DATETIME,
	@DeliveryDate DATETIME,
	@TrialDate DATETIME,
	@PantQty DECIMAL(18,2),
	@ShirtQty DECIMAL(18,2),
	@ExtraCost DECIMAL(18,2),
	@Discount DECIMAL(18,2),
	@PaidAmount DECIMAL(18,2),
	@TotalAmount DECIMAL(18,2),
	@BillId INT OUTPUT,
	@BillNo INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @CustomerId INT;
	DECLARE @PantId INT;
	DECLARE @ShirtId INT;	
	DECLARE @ShirtProductID INT;
	DECLARE @ShirtPrice DECIMAL(18,2);
	DECLARE @BillDetailID INT;	
	DECLARE @BillPaymentDetailID INT;	
	DECLARE @PantProductID INT;
	DECLARE @PantPrice DECIMAL(18,2);

	EXEC spSaveCustomer @Name, @Mobile, @CustomerId OUTPUT;
	EXEC spSavePant @CustomerId, @PantLength1, @PantLength2, @PantLength3, @PantLength4, @PantLength5, @Kamar1, @Kamar2, @Kamar3, @Kamar4, @Kamar5,
		@Seat1, @Seat2, @Seat3, @Seat4, @Seat5, @Jangh1, @Jangh2, @Jangh3, @Jangh4, @Jangh5,
		@Gothan1, @Gothan2, @Gothan3, @Gothan4, @Gothan5, @Jolo1, @Jolo2, @Jolo3, @Jolo4, @Jolo5,
		@Moli1, @Moli2, @Moli3, @Moli4, @Moli5, @PantNotes,	@PantId OUTPUT;
	EXEC spSaveShirt @CustomerId,
		@ShirtLength1, @ShirtLength2, @ShirtLength3, @ShirtLength4, @ShirtLength5, @Chati1, @Chati2, @Chati3, @Chati4, @Chati5, 
		@Solder1, @Solder2, @Solder3, @Solder4, @Solder5, @Bye1, @Bye2, @Bye3, @Bye4, @Bye5,
		@Front1, @Front2, @Front3, @Front4, @Front5, @Kolor1, @Kolor2, @Kolor3, @Kolor4, @Kolor5,
		@Cuff1, @Cuff2, @Cuff3, @Cuff4, @Cuff5, @ShirtNotes, @ShirtId OUTPUT;
	
	EXEC spSaveBill @CustomerId, @BillDate, @DeliveryDate, @TrialDate, @ExtraCost, @Discount, @TotalAmount, @BillId OUTPUT, @BillNo OUTPUT;
	
	IF @ShirtQty > 0
	BEGIN
		SELECT @ShirtProductID = ID, @ShirtPrice = Price FROM tbProduct WHERE [Name] = 'Shirt';
		EXEC spSaveBillDetail @BillId, @ShirtProductId, @ShirtQty, @ShirtPrice, @BillDetailID OUTPUT  	
	END
	
	IF @PantQty > 0
	BEGIN
		SELECT @PantProductID = ID, @PantPrice = Price FROM tbProduct WHERE [Name] = 'Pant';
		EXEC spSaveBillDetail @BillId, @PantProductId, @PantQty, @PantPrice, @BillDetailID OUTPUT  	
	END

	IF @PaidAmount > 0
	BEGIN
		EXEC spSaveBillPaymentDetail @BillId, @PaidAmount, @BillPaymentDetailID OUTPUT 
	END
END;
GO

CREATE OR ALTER PROCEDURE spGetBillById
	@Id INT
AS
BEGIN
	SELECT B.Id, B.BillDate, B.BillNo, B.DeliveryDate, B.ExtraCost, B.Discount, B.PaidAmount,
	B.TotalAmount, B.TrialDate, B.CustomerId, C.Mobile, C.[Name], P.Id PantId, 
	P.Length1 PantLength1, P.Length2 PantLength2, P.Length3 PantLength3, P.Length4 PantLength4, P.Length5 PantLength5,
	P.Gothan1, P.Gothan2, P.Gothan3, P.Gothan4, P.Gothan5, P.Jangh1, P.Jangh2, P.Jangh3, P.Jangh4, P.Jangh5,
	P.Jolo1, P.Jolo2, P.Jolo3, P.Jolo4, P.Jolo5, P.Kamar1, P.Kamar2, P.Kamar3, P.Kamar4, P.Kamar5,
	P.Moli1, P.Moli2, P.Moli3, P.Moli4, P.Moli5, P.Seat1, P.Seat2, P.Seat3, P.Seat4, P.Seat5, P.Notes PantNotes,
	S.Id ShirtId, S.Length1 ShirtLength1, S.Length2 ShirtLength2, S.Length3 ShirtLength3, S.Length4 ShirtLength4, S.Length5 ShirtLength5,
	S.Chati1, S.Chati2, S.Chati3, S.Chati4, S.Chati5, S.Solder1, S.Solder2, S.Solder3, S.Solder4, S.Solder5, 
	S.Bye1, S.Bye2, S.Bye3, S.Bye4, S.Bye5, S.Front1, S.Front2, S.Front3, S.Front4, S.Front5, 
	S.Kolor1, S.Kolor2, S.Kolor3, S.Kolor4, S.Kolor5, S.Cuff1, S.Cuff2, S.Cuff3, S.Cuff4, S.Cuff5, S.Notes ShirtNotes
	FROM tbBill B
	INNER JOIN tbCustomer C on C.Id = B.CustomerId
	LEFT JOIN tbPant P ON P.CustomerId = B.CustomerId
	LEFT JOIN tbShirt S ON S.CustomerId = B.CustomerId
	WHERE B.Id = @Id
END
GO

CREATE OR ALTER PROCEDURE spGetBillDetailsByBillId
	@BillId INT
AS
BEGIN
	SELECT BD.BillId, BD.Id, BD.Price, BD.Qty, P.Id ProductId, P.[Name] ProductName, P.Price ProductPrice
	FROM tbBillDetail BD
	INNER JOIN tbProduct P ON P.Id = BD.ProductId
	WHERE BillId = @BillId
END
GO