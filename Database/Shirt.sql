USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbShirt', 'U') IS NULL 
BEGIN
	CREATE TABLE tbShirt (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[CustomerId] INT FOREIGN KEY  REFERENCES tbCustomer(Id),
		[Length1] NVARCHAR(10), [Length2] NVARCHAR(10), [Length3] NVARCHAR(10), [Length4] NVARCHAR(10), [Length5] NVARCHAR(10),
		[Chati1] NVARCHAR(10), [Chati2] NVARCHAR(10), [Chati3] NVARCHAR(10), [Chati4] NVARCHAR(10), [Chati5] NVARCHAR(10),
		[Solder1] NVARCHAR(10), [Solder2] NVARCHAR(10), [Solder3] NVARCHAR(10), [Solder4] NVARCHAR(10), [Solder5] NVARCHAR(10),
		[Bye1] NVARCHAR(10), [Bye2] NVARCHAR(10), [Bye3] NVARCHAR(10), [Bye4] NVARCHAR(10), [Bye5] NVARCHAR(10),
		[Front1] NVARCHAR(10), [Front2] NVARCHAR(10), [Front3] NVARCHAR(10), [Front4] NVARCHAR(10), [Front5] NVARCHAR(10),
		[Kolor1] NVARCHAR(10), [Kolor2] NVARCHAR(10), [Kolor3] NVARCHAR(10), [Kolor4] NVARCHAR(10), [Kolor5] NVARCHAR(10),
		[Cuff1] NVARCHAR(10), [Cuff2] NVARCHAR(10), [Cuff3] NVARCHAR(10), [Cuff4] NVARCHAR(10), [Cuff5] NVARCHAR(10),
		Notes NVARCHAR(MAX)
	)
END
GO

CREATE OR ALTER PROCEDURE spGetShirts
AS
BEGIN
	SELECT Id, CustomerId,
		Length1, Length2, Length3, Length4, Length5, Chati1, Chati2, Chati3, Chati4, Chati5, 
		Solder1, Solder2, Solder3, Solder4, Solder5, Bye1, Bye2, Bye3, Bye4, Bye5,
		Front1, Front2, Front3, Front4, Front5, Kolor1, Kolor2, Kolor3, Kolor4, Kolor5,
		Cuff1, Cuff2, Cuff3, Cuff4, Cuff5, Notes
	FROM tbShirt
END
GO

CREATE OR ALTER PROCEDURE spGetShirtById
	@Id INT
AS
BEGIN
	SELECT Id, CustomerId,
		Length1, Length2, Length3, Length4, Length5, Chati1, Chati2, Chati3, Chati4, Chati5, 
		Solder1, Solder2, Solder3, Solder4, Solder5, Bye1, Bye2, Bye3, Bye4, Bye5,
		Front1, Front2, Front3, Front4, Front5, Kolor1, Kolor2, Kolor3, Kolor4, Kolor5,
		Cuff1, Cuff2, Cuff3, Cuff4, Cuff5, Notes
	FROM tbShirt
	WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE spGetShirtByCustomerId
	@CustomerId INT
AS
BEGIN
	SELECT Id, CustomerId,
		Length1, Length2, Length3, Length4, Length5, Chati1, Chati2, Chati3, Chati4, Chati5, 
		Solder1, Solder2, Solder3, Solder4, Solder5, Bye1, Bye2, Bye3, Bye4, Bye5,
		Front1, Front2, Front3, Front4, Front5, Kolor1, Kolor2, Kolor3, Kolor4, Kolor5,
		Cuff1, Cuff2, Cuff3, Cuff4, Cuff5, Notes
	FROM tbShirt
	WHERE CustomerId = @CustomerId
END
GO

CREATE OR ALTER PROCEDURE spSaveShirt
    @CustomerId INT,
	@Length1 NVARCHAR(10), @Length2 NVARCHAR(10), @Length3 NVARCHAR(10), @Length4 NVARCHAR(10), @Length5 NVARCHAR(10),
	@Chati1 NVARCHAR(10), @Chati2 NVARCHAR(10), @Chati3 NVARCHAR(10), @Chati4 NVARCHAR(10), @Chati5 NVARCHAR(10),
	@Solder1 NVARCHAR(10), @Solder2 NVARCHAR(10), @Solder3 NVARCHAR(10), @Solder4 NVARCHAR(10), @Solder5 NVARCHAR(10),
	@Bye1 NVARCHAR(10), @Bye2 NVARCHAR(10), @Bye3 NVARCHAR(10), @Bye4 NVARCHAR(10), @Bye5 NVARCHAR(10),
	@Front1 NVARCHAR(10), @Front2 NVARCHAR(10), @Front3 NVARCHAR(10), @Front4 NVARCHAR(10), @Front5 NVARCHAR(10),
	@Kolor1 NVARCHAR(10), @Kolor2 NVARCHAR(10), @Kolor3 NVARCHAR(10), @Kolor4 NVARCHAR(10), @Kolor5 NVARCHAR(10),
	@Cuff1 NVARCHAR(10), @Cuff2 NVARCHAR(10), @Cuff3 NVARCHAR(10), @Cuff4 NVARCHAR(10), @Cuff5 NVARCHAR(10),
	@Notes NVARCHAR(MAX),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM tbShirt WHERE CustomerId = @CustomerId)
		BEGIN
			INSERT INTO tbShirt(CustomerId,
				Length1, Length2, Length3, Length4, Length5, Chati1, Chati2, Chati3, Chati4, Chati5, 
				Solder1, Solder2, Solder3, Solder4, Solder5, Bye1, Bye2, Bye3, Bye4, Bye5,
				Front1, Front2, Front3, Front4, Front5, Kolor1, Kolor2, Kolor3, Kolor4, Kolor5,
				Cuff1, Cuff2, Cuff3, Cuff4, Cuff5, Notes)
			VALUES (@CustomerId,
				@Length1, @Length2, @Length3, @Length4, @Length5, @Chati1, @Chati2, @Chati3, @Chati4, @Chati5, 
				@Solder1, @Solder2, @Solder3, @Solder4, @Solder5, @Bye1, @Bye2, @Bye3, @Bye4, @Bye5,
				@Front1, @Front2, @Front3, @Front4, @Front5, @Kolor1, @Kolor2, @Kolor3, @Kolor4, @Kolor5,
				@Cuff1, @Cuff2, @Cuff3, @Cuff4, @Cuff5, @Notes);
			
			SET @Id = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			SELECT @Id = Id FROM tbShirt WHERE CustomerId = @CustomerId

			UPDATE tbShirt
			SET 
				Length1 = @Length1, Length2 = @Length2, Length3 = @Length3, Length4 = @Length4, Length5 = @Length5,
				Chati1 = @Chati1, Chati2 = @Chati2, Chati3 = @Chati3, Chati4 = @Chati4, Chati5 = @Chati5,
				Solder1 = @Solder1, Solder2 = @Solder2, Solder3 = @Solder3, Solder4 = @Solder4, Solder5 = @Solder5,
				Bye1 = @Bye1, Bye2 = @Bye2, Bye3 = @Bye3, Bye4 = @Bye4, Bye5 = @Bye5,
				Front1 = @Front1, Front2 = @Front2, Front3 = @Front3, Front4 = @Front4, Front5 = @Front5,
				Kolor1 = @Kolor1, Kolor2 = @Kolor2, Kolor3 = @Kolor3, Kolor4 = @Kolor4, Kolor5 = @Kolor5,
				Cuff1 = @Cuff1, Cuff2 = @Cuff2, Cuff3 = @Cuff3, Cuff4 = @Cuff4, Cuff5 = @Cuff5,
				Notes = @Notes
			WHERE CustomerId = @CustomerId;
		END
END
GO

CREATE OR ALTER PROCEDURE spUpdateShirt
    @CustomerId INT,
	@Length1 NVARCHAR(10), @Length2 NVARCHAR(10), @Length3 NVARCHAR(10), @Length4 NVARCHAR(10), @Length5 NVARCHAR(10),
	@Chati1 NVARCHAR(10), @Chati2 NVARCHAR(10), @Chati3 NVARCHAR(10), @Chati4 NVARCHAR(10), @Chati5 NVARCHAR(10),
	@Solder1 NVARCHAR(10), @Solder2 NVARCHAR(10), @Solder3 NVARCHAR(10), @Solder4 NVARCHAR(10), @Solder5 NVARCHAR(10),
	@Bye1 NVARCHAR(10), @Bye2 NVARCHAR(10), @Bye3 NVARCHAR(10), @Bye4 NVARCHAR(10), @Bye5 NVARCHAR(10),
	@Front1 NVARCHAR(10), @Front2 NVARCHAR(10), @Front3 NVARCHAR(10), @Front4 NVARCHAR(10), @Front5 NVARCHAR(10),
	@Kolor1 NVARCHAR(10), @Kolor2 NVARCHAR(10), @Kolor3 NVARCHAR(10), @Kolor4 NVARCHAR(10), @Kolor5 NVARCHAR(10),
	@Cuff1 NVARCHAR(10), @Cuff2 NVARCHAR(10), @Cuff3 NVARCHAR(10), @Cuff4 NVARCHAR(10), @Cuff5 NVARCHAR(10),
	@Notes NVARCHAR(MAX),
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE tbShirt
	SET 
		CustomerId = @CustomerId,
		Length1 = @Length1, Length2 = @Length2, Length3 = @Length3, Length4 = @Length4, Length5 = @Length5,
		Chati1 = @Chati1, Chati2 = @Chati2, Chati3 = @Chati3, Chati4 = @Chati4, Chati5 = @Chati5,
		Solder1 = @Solder1, Solder2 = @Solder2, Solder3 = @Solder3, Solder4 = @Solder4, Solder5 = @Solder5,
		Bye1 = @Bye1, Bye2 = @Bye2, Bye3 = @Bye3, Bye4 = @Bye4, Bye5 = @Bye5,
		Front1 = @Front1, Front2 = @Front2, Front3 = @Front3, Front4 = @Front4, Front5 = @Front5,
		Kolor1 = @Kolor1, Kolor2 = @Kolor2, Kolor3 = @Kolor3, Kolor4 = @Kolor4, Kolor5 = @Kolor5,
		Cuff1 = @Cuff1, Cuff2 = @Cuff2, Cuff3 = @Cuff3, Cuff4 = @Cuff4, Cuff5 = @Cuff5,
		Notes = @Notes
	WHERE Id = @Id;
		
END
GO

CREATE OR ALTER PROCEDURE spDeleteShirtById
	@Id INT
AS
BEGIN
	DELETE
	FROM tbShirt
	WHERE Id = @Id
END
GO
