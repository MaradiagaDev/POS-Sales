--BASE DE DATOS
CREATE DATABASE POSIDEVBD
USE POSIDEVBD
GO

--USUARIO DE INICIO DE LA BASE
CREATE LOGIN LoginPos 
WITH PASSWORD = 'facil123$';

CREATE USER LoginUser 
FOR LOGIN LoginPos ;

EXEC sp_addrolemember 'db_owner', 'LoginUser';
--TABLAS TODAS

--TABLA PARA LOS USUARIOS QUE ACCEDEN AL SISTEMA
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] nvarchar(50) primary key,
	[Usuario] [nvarchar](50) NULL,
	ClaveUsuario nvarchar(Max) NULL,
	[Estado] [nvarchar](50) NULL,
	IdEmpleado nvarchar(50) null,
	FechaCreo datetime,
	FechaActualizo datetime
)

CREATE TABLE [dbo].[Sucursal] (
    [IdSucursal] NVARCHAR(50) PRIMARY KEY,   -- Clave primaria de la sucursal
    [NombreSucursal] NVARCHAR(100) NOT NULL, -- Nombre de la sucursal
    [Direccion] NVARCHAR(MAX) NULL,          -- Direcci�n de la sucursal
    [Telefono] NVARCHAR(15) NULL,            -- Tel�fono de contacto
    [Estado] NVARCHAR(50) NULL,              -- Estado o estatus de la sucursal (activo, inactivo, etc.)
    [FechaCreo] DATETIME DEFAULT GETDATE(),  -- Fecha de creaci�n, con valor predeterminado actual
    [FechaActualizo] DATETIME NULL           -- Fecha de �ltima actualizaci�n
);

CREATE TABLE [dbo].[UsuarioSucursal] (
    [IdUsuarioSucursal] INT IDENTITY(1,1) PRIMARY KEY, -- Clave primaria de la tabla de relaci�n
    [IdUsuario] NVARCHAR(50) NOT NULL,                -- Clave for�nea del usuario
    [IdSucursal] NVARCHAR(50) NOT NULL,               -- Clave for�nea de la sucursal
    [FechaAsignacion] DATETIME DEFAULT GETDATE(),      -- Fecha de asignaci�n de la relaci�n
);

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[IdCliente] decimal(18,0) IDENTITY(1,1) NOT NULL,
	[PNombre] [nvarchar](255) NULL,
	[SNombre] [nvarchar](255) NULL,
	[PApellido] [nvarchar](255) NULL,
	[SAPellido] [nvarchar](255) NULL,
	[Estado] [float] NULL,
	[Direccion] [nvarchar](255) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Celular] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Edad] [float] NULL,
	[Estado Civil] [nvarchar](255) NULL,
	[Profesion] [nvarchar](255) NULL,
	[Sexo] [nvarchar](255) NULL,
	[Cedula] [nvarchar](255) NULL,
	[FechaNac] [date] NULL,
	[Email] [nvarchar](60) NULL,
	[Departamento] [nvarchar](100) NULL,
	[pais] [nvarchar](100) NULL,
	[observacion] [nvarchar](400) NULL,
	[NoRuc] [nvarchar](50) NULL,
	IdSucursal nvarchar(50),
 CONSTRAINT [PK__Clientes__D5946642123EB7A3] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Estado]  DEFAULT ((1)) FOR [Estado]
GO



--TABLAS 26/11/2024

CREATE TABLE [dbo].[Almacenes] (
    [AlmacenId] NVARCHAR(50) NOT NULL PRIMARY KEY,                -- Identificador �nico para el almac�n
    [NombreAlmacen] NVARCHAR(255) NOT NULL,             -- Nombre del almac�n, obligatorio
    [EsMostrador] BIT NULL,                             -- Indica si es un mostrador (NULL si no especificado)
    [SucursalId] NVARCHAR(50) NULL,                              -- Identificador de la sucursal, opcional
    [Estatus] NVARCHAR(50) NOT NULL                    -- Estado del almac�n (activo, inactivo, etc.)
);
