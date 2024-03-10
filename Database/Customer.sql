USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbCustomer', 'U') IS NULL 
BEGIN
	CREATE TABLE tbCustomer (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[Name] NVARCHAR(100),
		Mobile NVARCHAR(10)
	)
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
		END
END
GO