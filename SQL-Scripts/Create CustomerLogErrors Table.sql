/*
   lunes, 26 de junio de 202312:36:54 a. m.
   User: 
   Server: DESKTOP-PVBSGPE\MSSQLSERVER02
   Database: AltaBancaTest
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.CustomerLogErrors
	(
	CustomerLogErrorId int NOT NULL IDENTITY (1, 1),
	Description nvarchar(200) NOT NULL,
	EventType int NOT NULL,
	Logged datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.CustomerLogErrors ADD CONSTRAINT
	PK_Table_1 PRIMARY KEY CLUSTERED 
	(
	CustomerLogErrorId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CustomerLogErrors SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
