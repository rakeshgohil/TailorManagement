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

CREATE OR ALTER PROCEDURE spGetShirtConfigurations
AS
BEGIN
	SELECT Id, [Description], LocalDescription
	FROM tbShirtConfiguration
END
GO

CREATE OR ALTER PROCEDURE spGetShirtConfigurationById
	@Id INT
AS
BEGIN
	SELECT Id, [Description], LocalDescription
	FROM tbShirtConfiguration
	WHERE Id = @Id
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
END
GO

CREATE OR ALTER PROCEDURE spUpdateShirtConfiguration
	@Description NVARCHAR(500), 
	@LocalDescription NVARCHAR(500),
	@Id INT
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE tbShirtConfiguration
	SET 
		[Description] = @Description,
		LocalDescription = @LocalDescription
	WHERE Id = @Id;
		
END
GO

CREATE OR ALTER PROCEDURE spDeleteShirtConfigurationById
	@Id INT
AS
BEGIN
	DELETE
	FROM tbShirtConfiguration
	WHERE Id = @Id
END
GO
