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
	@PaidAmount DECIMAL(18,2),
	@Id INT OUTPUT,
	@BillNo INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
		
	SELECT @BillNo = ISNULL(MAX(BillNo), 0) + 1 FROM tbBill
	INSERT INTO tbBill(BillDate, BillNo, CustomerId, DeliveryDate, ExtraCost, Discount, PaidAmount, TotalAmount, TrialDate)
    VALUES (@BillDate, @BillNo, @CustomerId, @DeliveryDate, @ExtraCost, @Discount, @PaidAmount, @TotalAmount, @TrialDate)

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
	
	EXEC spSaveBill @CustomerId, @BillDate, @DeliveryDate, @TrialDate, @ExtraCost, @Discount, @TotalAmount, @PaidAmount, @BillId OUTPUT, @BillNo OUTPUT;
	
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
END;
