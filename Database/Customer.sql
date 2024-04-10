USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbCustomer', 'U') IS NULL 
BEGIN
	CREATE TABLE tbCustomer (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[Name] NVARCHAR(100),
		Mobile NVARCHAR(10) UNIQUE
	)
END
GO

CREATE OR ALTER PROCEDURE spGetCustomers
AS
BEGIN
	SELECT Id, [Name], Mobile 
	FROM tbCustomer
END
GO

CREATE OR ALTER PROCEDURE spGetCustomerById
	@Id INT
AS
BEGIN
	SELECT Id, [Name], Mobile
	FROM tbCustomer
	WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE spGetCustomerByMobile
	@Mobile NVARCHAR(10)
AS
BEGIN
	SELECT Id, [Name], Mobile
	FROM tbCustomer
	WHERE Mobile = @Mobile
END
GO

CREATE OR ALTER PROCEDURE spSaveCustomer
    @Name NVARCHAR(100),
    @Mobile NVARCHAR(10),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

	IF NOT EXISTS(SELECT 1 FROM tbCustomer WHERE Mobile = @Mobile)
		BEGIN
			INSERT INTO tbCustomer ([Name], Mobile)
			VALUES (@Name, @Mobile);

			SET @Id = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			SELECT @Id = Id FROM tbCustomer WHERE Mobile = @Mobile
			
			UPDATE tbCustomer
			SET Name = @Name
			WHERE Id = @Id;
		END
END
GO

CREATE OR ALTER PROCEDURE spUpdateCustomer
    @Name NVARCHAR(100),
    @Mobile NVARCHAR(10),
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE tbCustomer
	SET 
		[Name] = @Name,
		Mobile = @Mobile
	WHERE Id = @Id;
		
END
GO

CREATE OR ALTER PROCEDURE spDeleteCustomerById
	@Id INT
AS
BEGIN
	DELETE
	FROM tbCustomer
	WHERE Id = @Id
END
GO
