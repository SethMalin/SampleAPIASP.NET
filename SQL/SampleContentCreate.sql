USE master
GO


IF EXISTS (SELECT * FROM sysdatabases WHERE name='ContentSample')
		ALTER DATABASE ContentSample SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
		DROP DATABASE ContentSample
go

CREATE DATABASE ContentSample;
GO

ALTER DATABASE ContentSample
SET MULTI_USER

USE ContentSample
GO

IF (exists (select *
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_NAME = 'Content'))

DROP TABLE Content
GO

CREATE TABLE Content
(
    ID INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    ContentType NVARCHAR(128) NULL,
	ScreenSpace NVARCHAR(128) NULL,
	[Name] NVARCHAR(128) NULL,
	Shape NVARCHAR(128) NULL
)

IF (exists (select *
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_NAME = 'XYZ'))

DROP TABLE XYZ
GO

CREATE TABLE XYZ
(
    X DECIMAL(20,10),
	Y DECIMAL(20,10),
	Z DECIMAL(20,10),
	PRIMARY KEY (X, Y, Z)
)

IF (exists (select *
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_NAME = 'Position'))

DROP TABLE Position
GO

CREATE TABLE Position
(
    X DECIMAL (20,10) ,Y DECIMAL (20,10) , Z DECIMAL (20,10) REFERENCES XYZ(X,Y,Z)
)