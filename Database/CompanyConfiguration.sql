USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbCompanyConfiguration', 'U') IS NULL 
BEGIN
	CREATE TABLE tbCompanyConfiguration (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		ConfigKey VARCHAR(50),
		ConfigValue NVARCHAR(1000)
	)
END
GO

CREATE OR ALTER PROCEDURE spGetCompanyConfigurations
AS
BEGIN
	SELECT Id, ConfigKey, ConfigValue
	FROM tbCompanyConfiguration
END
GO

CREATE OR ALTER PROCEDURE spGetCompanyConfigurationById
	@Id INT
AS
BEGIN
	SELECT Id, ConfigKey, ConfigValue
	FROM tbCompanyConfiguration
	WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE spGetCompanyConfigurationByKey
	@ConfigKey VARCHAR(50)
AS
BEGIN
	SELECT Id, ConfigKey, ConfigValue
	FROM tbCompanyConfiguration
	WHERE ConfigKey = @ConfigKey
END
GO

CREATE OR ALTER PROCEDURE spSaveCompanyConfiguration
	@ConfigKey VARCHAR(50),
	@ConfigValue NVARCHAR(1000),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
	
	IF NOT EXISTS (SELECT 1 FROM tbCompanyConfiguration WHERE ConfigKey = @ConfigKey)
		BEGIN
			INSERT INTO tbCompanyConfiguration(ConfigKey, ConfigValue)
			VALUES (@ConfigKey, @ConfigValue);
			
			SET @Id = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN			
			SELECT @Id = Id FROM tbCompanyConfiguration WHERE ConfigKey = @ConfigKey
			EXEC spUpdateCompanyConfiguration @ConfigKey, @ConfigValue, @Id
		END
END
GO

CREATE OR ALTER PROCEDURE spUpdateCompanyConfiguration
	@ConfigKey VARCHAR(50),
	@ConfigValue NVARCHAR(1000),
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE tbCompanyConfiguration
	SET 
		ConfigKey = @ConfigKey,
		ConfigValue = @ConfigValue
	WHERE Id = @Id;		
END
GO

CREATE OR ALTER PROCEDURE spDeleteCompanyConfigurationById
	@Id INT
AS
BEGIN
	DELETE
	FROM tbCompanyConfiguration
	WHERE Id = @Id
END
GO
