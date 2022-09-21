 --IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'testDB')
 -- BEGIN
 --   CREATE DATABASE testDB
 -- END
 --   GO
 --      USE testDB
 --   GO

CREATE DATABASE testDB
GO
USE testDB
GO

--IF OBJECT_ID('[dbo].Personas', 'U') IS NOT NULL 
--  DROP TABLE dbo.Personas;  
--GO

GO
IF NOT EXISTS (SELECT 1 FROM sysobjects where name='Personas' and xtype='U')
begin
	CREATE TABLE dbo.Personas
		(
		Identificacion varchar(13) NOT NULL,
		Nombres varchar(200) NOT NULL,
		Genero int NOT NULL,
		FechaNacimiento date NOT NULL,
		Direccion varchar(150) NULL,
		Telefono varchar(13) NULL
		)  ON [PRIMARY]

	ALTER TABLE dbo.Personas ADD CONSTRAINT
		PK_Personas PRIMARY KEY CLUSTERED 
		(
		Identificacion
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
----INSERTS
INSERT [dbo].[Personas] ([Identificacion], [Nombres], [Genero], [FechaNacimiento], [Direccion], [Telefono]) VALUES (N'0104027040', N'Jose Lema Benavides', 0, CAST(N'1997-04-23' AS Date), N'Otavalo sn y principal', N'098254785 ')
INSERT [dbo].[Personas] ([Identificacion], [Nombres], [Genero], [FechaNacimiento], [Direccion], [Telefono]) VALUES (N'0105020341', N'Marianela Montalvo', 1, CAST(N'1990-04-23' AS Date), N'Amazonas y NNUU', N'097548965 ')
INSERT [dbo].[Personas] ([Identificacion], [Nombres], [Genero], [FechaNacimiento], [Direccion], [Telefono]) VALUES (N'0132420341', N'Juan Osorio', 0, CAST(N'1986-04-23' AS Date), N'13 junio y Equinoccial', N'098874587')

end
GO


--IF OBJECT_ID('[dbo].Clientes', 'U') IS NOT NULL 
--  DROP TABLE dbo.Clientes;  
--GO

--GO
IF NOT EXISTS (SELECT 1 FROM sysobjects where name='Clientes' and xtype='U')
BEGIN
	CREATE TABLE dbo.Clientes
		(
		Id int NOT NULL IDENTITY (1, 1),
		Contrasena varchar(100) NOT NULL,
		Estado bit NOT NULL,
		Identificacion varchar(13) NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Clientes ADD CONSTRAINT
		PK_Clientes PRIMARY KEY CLUSTERED 
		(
		Id
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_Personas FOREIGN KEY
	(
	Identificacion
	) REFERENCES dbo.Personas
	(
	Identificacion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

	 ----INSERTS
	 SET IDENTITY_INSERT [dbo].[Clientes] ON 
	 INSERT [dbo].[Clientes] ([Id], [Contrasena], [Estado], [Identificacion]) VALUES (5, N'4321', 1, N'0104027040')
	 INSERT [dbo].[Clientes] ([Id], [Contrasena], [Estado], [Identificacion]) VALUES (6, N'5678', 1, N'0105020341')
	 INSERT [dbo].[Clientes] ([Id], [Contrasena], [Estado], [Identificacion]) VALUES (7, N'1245', 1, N'0132420341')
	 SET IDENTITY_INSERT [dbo].[Clientes] OFF

END
	
GO

--IF OBJECT_ID('[dbo].Cuentas', 'U') IS NOT NULL 
--  DROP TABLE dbo.Cuentas;  
--GO
IF NOT EXISTS (SELECT 1 FROM sysobjects where name='Cuentas' and xtype='U')
BEGIN

	CREATE TABLE dbo.Cuentas
		(
		NumeroCuenta varchar(15) NOT NULL,
		TipoCuenta int NOT NULL,
		SaldoInicial decimal(10, 2) NOT NULL,
		SaldoDisponible decimal(10, 2) NOT NULL,
		Estado bit NOT NULL,
		ClienteId int NOT NULL
		)  ON [PRIMARY]

	ALTER TABLE dbo.Cuentas ADD CONSTRAINT
		PK_Cuentas_1 PRIMARY KEY CLUSTERED 
		(
		NumeroCuenta
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.Cuentas ADD CONSTRAINT
		FK_Cuentas_Clientes FOREIGN KEY
		(
		ClienteId
		) REFERENCES dbo.Clientes
		(
		Id
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
----INSERTS
INSERT [dbo].[Cuentas] ([NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [ClienteId]) VALUES (N'225487', 2, CAST(100.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 1, 6)
INSERT [dbo].[Cuentas] ([NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [ClienteId]) VALUES (N'478758', 1, CAST(2000.00 AS Decimal(10, 2)), CAST(1425.00 AS Decimal(10, 2)), 1, 5)
INSERT [dbo].[Cuentas] ([NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [ClienteId]) VALUES (N'495878', 1, CAST(0.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), 1, 7)
INSERT [dbo].[Cuentas] ([NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [ClienteId]) VALUES (N'496825', 1, CAST(540.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 1, 6)
INSERT [dbo].[Cuentas] ([NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [ClienteId]) VALUES (N'585545', 2, CAST(1000.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), 1, 6)

END
GO

--IF OBJECT_ID('[dbo].Movimientos', 'U') IS NOT NULL 
--  DROP TABLE dbo.Movimientos;  
--GO

IF NOT EXISTS (SELECT 1 FROM sysobjects where name='Movimientos' and xtype='U')
BEGIN

	CREATE TABLE dbo.Movimientos
		(
		Id int NOT NULL IDENTITY (1, 1),
		Fecha datetime NOT NULL,
		TipoMovimiento int NOT NULL,
		Valor decimal(10, 2) NOT NULL,
		Saldo decimal(10, 2) NOT NULL,
		NumeroCuenta varchar(15) NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Movimientos ADD CONSTRAINT
		PK_Movimientos PRIMARY KEY CLUSTERED 
		(
		Id
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.Movimientos ADD CONSTRAINT
		FK_Movimientos_Cuentas FOREIGN KEY
		(
		NumeroCuenta
		) REFERENCES dbo.Cuentas
		(
		NumeroCuenta
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
----INSERTS
SET IDENTITY_INSERT [dbo].[Movimientos] ON 
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [NumeroCuenta]) VALUES (1, CAST(N'2022-01-13T00:00:00.000' AS DateTime), 0, CAST(575.00 AS Decimal(10, 2)), CAST(1425.00 AS Decimal(10, 2)), N'478758')
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [NumeroCuenta]) VALUES (2, CAST(N'2022-02-10T13:00:00.000' AS DateTime), 1, CAST(600.00 AS Decimal(10, 2)), CAST(700.00 AS Decimal(10, 2)), N'225487')
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [NumeroCuenta]) VALUES (3, CAST(N'2022-02-08T13:00:00.000' AS DateTime), 1, CAST(150.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), N'495878')
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [NumeroCuenta]) VALUES (4, CAST(N'2022-02-08T13:00:00.000' AS DateTime), 0, CAST(540.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), N'496825')
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
END 

GO

IF OBJECT_ID('[dbo].EstadoCuenta', 'V') IS NOT NULL 
  DROP TABLE dbo.EstadoCuenta;  
GO

IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trgInsertMovimiento]'))
DROP TRIGGER [dbo].trgInsertMovimiento
GO
CREATE TRIGGER dbo.trgInsertMovimiento 
   ON dbo.Movimientos
   AFTER INSERT, UPDATE
AS   
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Cuentas SET SaldoDisponible = inserted.Saldo
	FROM inserted
	WHERE dbo.Cuentas.NumeroCuenta = inserted.NumeroCuenta;
END;
GO

IF OBJECT_ID('dbo.EstadoCuenta', 'V') IS NOT NULL
    DROP VIEW dbo.test_abc_def
GO
CREATE VIEW EstadoCuenta--(Fecha, Cliente, NumeroCuenta, Tipo, SaldoInicial, Estado, Valor, SaldoDisponible, Identificacion)
AS 
   SELECT Fecha,Nombres as Cliente, Movimientos.NumeroCuenta as NumeroCuenta, TipoMovimiento as Tipo, 
		IIF(TipoMovimiento=0,Saldo - Valor, Saldo + Valor) as SaldoInicial, Cuentas.Estado as Estado, 
		Valor, SaldoDisponible, Clientes.Identificacion as Identificacion
   FROM Movimientos INNER JOIN Cuentas ON Movimientos.NumeroCuenta = Cuentas.NumeroCuenta
   INNER JOIN Clientes ON Clientes.Id = Cuentas.ClienteId
   INNER JOIN Personas ON Personas.Identificacion = Clientes.Identificacion
GO
