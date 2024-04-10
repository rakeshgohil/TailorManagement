USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbPantConfiguration', 'U') IS NULL 
BEGIN
	CREATE TABLE tbPantConfiguration (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[Description] NVARCHAR(500),
		[LocalDescription] NVARCHAR(500),
	)
END
GO

CREATE OR ALTER PROCEDURE spGetPantConfigurations
AS
BEGIN
	SELECT Id, [Description], LocalDescription
	FROM tbPantConfiguration
END
GO

CREATE OR ALTER PROCEDURE spGetPantConfigurationById
	@Id INT
AS
BEGIN
	SELECT Id, [Description], LocalDescription
	FROM tbPantConfiguration
	WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE spSavePantConfiguration
	@Description NVARCHAR(500), 
	@LocalDescription NVARCHAR(500),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tbPantConfiguration([Description], LocalDescription)
		VALUES (@Description, @LocalDescription);

    SET @Id = SCOPE_IDENTITY();
END
GO

CREATE OR ALTER PROCEDURE spUpdatePantConfiguration
	@Description NVARCHAR(500), 
	@LocalDescription NVARCHAR(500),
	@Id INT
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE tbPantConfiguration
	SET 
		[Description] = @Description,
		LocalDescription = @LocalDescription
	WHERE Id = @Id;
		
END
GO

CREATE OR ALTER PROCEDURE spDeletePantConfigurationById
	@Id INT
AS
BEGIN
	DELETE
	FROM tbPantConfiguration
	WHERE Id = @Id
END
GO
