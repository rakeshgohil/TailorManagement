USE TailorManagementDB
GO

IF OBJECT_ID('dbo.tbPant', 'U') IS NULL 
BEGIN
	CREATE TABLE tbPant (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		[CustomerId] INT FOREIGN KEY  REFERENCES tbCustomer(Id),
		[Length1] NVARCHAR(10), [Length2] NVARCHAR(10), [Length3] NVARCHAR(10), [Length4] NVARCHAR(10), [Length5] NVARCHAR(10),
		[Kamar1] NVARCHAR(10), [Kamar2] NVARCHAR(10), [Kamar3] NVARCHAR(10), [Kamar4] NVARCHAR(10), [Kamar5] NVARCHAR(10),
		[Seat1] NVARCHAR(10), [Seat2] NVARCHAR(10), [Seat3] NVARCHAR(10), [Seat4] NVARCHAR(10), [Seat5] NVARCHAR(10),
		[Jangh1] NVARCHAR(10), [Jangh2] NVARCHAR(10), [Jangh3] NVARCHAR(10), [Jangh4] NVARCHAR(10), [Jangh5] NVARCHAR(10),
		[Gothan1] NVARCHAR(10), [Gothan2] NVARCHAR(10), [Gothan3] NVARCHAR(10), [Gothan4] NVARCHAR(10), [Gothan5] NVARCHAR(10),
		[Jolo1] NVARCHAR(10), [Jolo2] NVARCHAR(10), [Jolo3] NVARCHAR(10), [Jolo4] NVARCHAR(10), [Jolo5] NVARCHAR(10),
		[Moli1] NVARCHAR(10), [Moli2] NVARCHAR(10), [Moli3] NVARCHAR(10), [Moli4] NVARCHAR(10), [Moli5] NVARCHAR(10),
		Notes NVARCHAR(MAX)
	)
END
GO

CREATE OR ALTER PROCEDURE spSavePant
		@CustomerId INT,
		@Length1 NVARCHAR(10), @Length2 NVARCHAR(10), @Length3 NVARCHAR(10), @Length4 NVARCHAR(10), @Length5 NVARCHAR(10),
		@Kamar1 NVARCHAR(10), @Kamar2 NVARCHAR(10), @Kamar3 NVARCHAR(10), @Kamar4 NVARCHAR(10), @Kamar5 NVARCHAR(10),
		@Seat1 NVARCHAR(10), @Seat2 NVARCHAR(10), @Seat3 NVARCHAR(10), @Seat4 NVARCHAR(10), @Seat5 NVARCHAR(10),
		@Jangh1 NVARCHAR(10), @Jangh2 NVARCHAR(10), @Jangh3 NVARCHAR(10), @Jangh4 NVARCHAR(10), @Jangh5 NVARCHAR(10),
		@Gothan1 NVARCHAR(10), @Gothan2 NVARCHAR(10), @Gothan3 NVARCHAR(10), @Gothan4 NVARCHAR(10), @Gothan5 NVARCHAR(10),
		@Jolo1 NVARCHAR(10), @Jolo2 NVARCHAR(10), @Jolo3 NVARCHAR(10), @Jolo4 NVARCHAR(10), @Jolo5 NVARCHAR(10),
		@Moli1 NVARCHAR(10), @Moli2 NVARCHAR(10), @Moli3 NVARCHAR(10), @Moli4 NVARCHAR(10), @Moli5 NVARCHAR(10),
		@Notes NVARCHAR(MAX),
		@Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tbPant (CustomerId, 
		Length1, Length2, Length3, Length4, Length5, Kamar1, Kamar2, Kamar3, Kamar4, Kamar5,
		Seat1, Seat2, Seat3, Seat4, Seat5, Jangh1, Jangh2, Jangh3, Jangh4, Jangh5,
		Gothan1, Gothan2, Gothan3, Gothan4, Gothan5, Jolo1, Jolo2, Jolo3, Jolo4, Jolo5,
		Moli1, Moli2, Moli3, Moli4, Moli5, Notes)
    VALUES (@CustomerId, 
		@Length1, @Length2, @Length3, @Length4, @Length5, @Kamar1, @Kamar2, @Kamar3, @Kamar4, @Kamar5,
		@Seat1, @Seat2, @Seat3, @Seat4, @Seat5, @Jangh1, @Jangh2, @Jangh3, @Jangh4, @Jangh5,
		@Gothan1, @Gothan2, @Gothan3, @Gothan4, @Gothan5, @Jolo1, @Jolo2, @Jolo3, @Jolo4, @Jolo5,
		@Moli1, @Moli2, @Moli3, @Moli4, @Moli5, @Notes);

    SET @Id = SCOPE_IDENTITY();
END;