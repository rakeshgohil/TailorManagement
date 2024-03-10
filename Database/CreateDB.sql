-- DROP DATABASE TailorManagementDB
USE master
GO

--ALTER DATABASE TailorManagementDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--DROP DATABASE TailorManagementDB;

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'TailorManagementDB')
BEGIN
	CREATE DATABASE TailorManagementDB;
END
GO

