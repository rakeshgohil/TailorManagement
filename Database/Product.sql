USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbProduct', 'U') IS NULL 
BEGIN
	CREATE TABLE tbProduct (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[Name] NVARCHAR(100) UNIQUE,
		Price DECIMAL(18, 2)
	)
END
GO

CREATE OR ALTER PROCEDURE spGetProducts
AS
BEGIN
	SELECT Id, [Name], Price
	FROM tbProduct
END
GO

CREATE OR ALTER PROCEDURE spGetProductById
	@Id INT
AS
BEGIN
	SELECT Id, [Name], Price
	FROM tbProduct
	WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE spSaveProduct
	@Name NVARCHAR(100), 
	@Price DECIMAL(18,2),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM tbProduct WHERE [Name] = @Name)
		BEGIN			
			INSERT INTO tbProduct([Name], Price)
			VALUES (@Name, @Price);
			
			SET @Id = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			SELECT @Id = Id FROM tbProduct WHERE [Name] = @Name

			UPDATE tbProduct
			SET Price = @Price
			WHERE Id = @Id;
		END
END
GO

CREATE OR ALTER PROCEDURE spUpdateProduct
	@Name NVARCHAR(100), 
	@Price DECIMAL(18,2),
	@Id INT
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE tbProduct
	SET 
		[Name] = @Name,
		Price = @Price
	WHERE Id = @Id;
		
END
GO

CREATE OR ALTER PROCEDURE spDeleteProductById
	@Id INT
AS
BEGIN
	DELETE
	FROM tbProduct
	WHERE Id = @Id
END
GO
