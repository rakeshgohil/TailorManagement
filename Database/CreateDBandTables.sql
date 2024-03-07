-- Drop the database if it exists
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'TailorManagementDB') 
CREATE DATABASE TailorManagementDB;
GO

-- Use the TailorManagementDB database
USE TailorManagementDB
GO

-- Drop the tbShirt table if it exists
--IF OBJECT_ID('dbo.tbShirt', 'U') IS NOT NULL DROP TABLE dbo.tbShirt;
CREATE TABLE tbShirt (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Length] VARCHAR(10),
    Chest VARCHAR(10)
);

