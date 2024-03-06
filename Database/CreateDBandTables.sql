-- Drop the database if it exists
--IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'TailorManagement') DROP DATABASE TailorManagement;
CREATE DATABASE TailorManagement;

-- Use the TailorManagement database
USE TailorManagement
GO

-- Drop the tbShirt table if it exists
--IF OBJECT_ID('dbo.tbShirt', 'U') IS NOT NULL DROP TABLE dbo.tbShirt;
CREATE TABLE tbShirt (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Length] VARCHAR(10),
    Chest VARCHAR(10)
);

