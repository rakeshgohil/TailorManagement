USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbShirtConfiguration', 'U') IS NULL 
BEGIN
	CREATE TABLE tbShirtConfiguration (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[Description] NVARCHAR(500),
		[LocalDescription] NVARCHAR(500),
	)
END
GO

CREATE OR ALTER PROCEDURE spSaveShirtConfiguration
	@Description NVARCHAR(500), 
	@LocalDescription NVARCHAR(500),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tbShirtConfiguration([Description], LocalDescription)
		VALUES (@Description, @LocalDescription);

    SET @Id = SCOPE_IDENTITY();
END;