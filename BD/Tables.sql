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
    [Direccion] NVARCHAR(MAX) NULL,          -- Dirección de la sucursal
    [Telefono] NVARCHAR(15) NULL,            -- Teléfono de contacto
    [Estado] NVARCHAR(50) NULL,              -- Estado o estatus de la sucursal (activo, inactivo, etc.)
    [FechaCreo] DATETIME DEFAULT GETDATE(),  -- Fecha de creación, con valor predeterminado actual
    [FechaActualizo] DATETIME NULL           -- Fecha de última actualización
);
alter table Sucursal add Correo nvarchar(255) 

CREATE TABLE [dbo].[UsuarioSucursal] (
    [IdUsuarioSucursal] INT IDENTITY(1,1) PRIMARY KEY, -- Clave primaria de la tabla de relación
    [IdUsuario] NVARCHAR(50) NOT NULL,                -- Clave foránea del usuario
    [IdSucursal] NVARCHAR(50) NOT NULL,               -- Clave foránea de la sucursal
    [FechaAsignacion] DATETIME DEFAULT GETDATE(),      -- Fecha de asignación de la relación
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
    [AlmacenId] NVARCHAR(50) NOT NULL PRIMARY KEY,                -- Identificador único para el almacén
    [NombreAlmacen] NVARCHAR(255) NOT NULL,             -- Nombre del almacén, obligatorio
    [EsMostrador] BIT NULL,                             -- Indica si es un mostrador (NULL si no especificado)
    [SucursalId] NVARCHAR(50) NULL,   
    [Direccion]	NVARCHAR(mAX) NULL,										-- Identificador de la sucursal, opcional
    [Estatus] NVARCHAR(50) NOT NULL                    -- Estado del almacén (activo, inactivo, etc.)
);

CREATE TABLE ProductosServicios (
    ProductoId nvarchar(50) NOT NULL PRIMARY KEY, -- Identificador único
    NombreProducto NVARCHAR(Max) NOT NULL, -- Nombre del estándar
    ImagenId INT NULL, -- Identificador de la imagen (opcional)
    Descripcion NVARCHAR(MAX) NULL, -- Descripción del estándar
    Estado NVARCHAR(50) NOT NULL, -- Estado (activo/inactivo o similar)
    Precio decimal(18,2) NULL, -- Monto de venta directa (opcional)
    ClasificacionProducto nvarchar(50), -- Clasificación del producto (opcional)
    CategoriaId INT NULL, -- Clasificación del tipo (opcional)
    Codigo NVARCHAR(50) NULL, -- Código único o identificador (opcional)
);

create TABLE RelAlmacenProducto (
    RelAlmacenProductoId decimal(18,0) identity(1,1) NOT NULL PRIMARY KEY, -- Identificador único para la relación
    AlmacenId NVARCHAR(50) NULL, -- Identificador del almacén (opcional)
    ProductoId NVARCHAR(50), -- Identificador del producto (opcional)
    Cantidad decimal(18,1) NULL -- Cantidad de producto en el almacén (opcional)
);

CREATE TABLE Proveedores (
    IdProveedor INT PRIMARY KEY IDENTITY(1,1), -- Llave primaria con autoincremento
    NombreEmpresa NVARCHAR(255) NOT NULL,      -- Nombre de la empresa (string)
    NoTelefono NVARCHAR(50),                   -- Número de teléfono (string)
    NoRuc NVARCHAR(50),                        -- Número de RUC (string)
    Correo NVARCHAR(255),                      -- Correo electrónico (string)
    Direccion NVARCHAR(MAX),                   -- Dirección (string)
    Estatus nvarchar(50) NULL,
	NombreRepresentante nvarchar(255) null,
	NoCelularRepresentante nvarchar(100) null
);

CREATE TABLE Categorizacion (
    CategorizacionId INT IDENTITY(1,1) PRIMARY KEY, -- Clave primaria con incremento automático
    Descripcion NVARCHAR(255) NOT NULL,          -- Campo de texto para la descripción
    Estado NVARCHAR(50) NOT NULL                 -- Campo de texto para el estado
);

CREATE TABLE ConfigFacturacion (
    ConfigFacturacionId Decimal(18,0) identity (1,1) NOT NULL PRIMARY KEY, -- ID principal de la configuración de facturación
    SucursalId nvarchar(50) NULL,                         -- ID de la sucursal (puede ser nulo)
    Serie NVARCHAR(50) NOT NULL,                -- Serie de la factura (ajustable según longitud esperada)
    ConsecutivoFactura Decimal(18,0) NULL,                -- Consecutivo actual de las facturas (puede ser nulo)
    RangoFactura Decimal(18,0)  NULL,                      -- Rango permitido de las facturas (puede ser nulo)
    ConsecutivoOrden Decimal(18,0)  NULL,                  -- Consecutivo actual de las órdenes (puede ser nulo)
    RangoOrden Decimal(18,0)  NULL                         -- Rango permitido de las órdenes (puede ser nulo)
);

CREATE TABLE MotivosCancelacion (
    MotivoCancelacionId INT identity(1,1) NOT NULL PRIMARY KEY, -- ID único para cada motivo de cancelación
    Motivo NVARCHAR(250) NOT NULL,               -- Descripción del motivo de cancelación
    Estado NVARCHAR(50) NOT NULL                 -- Estado del motivo (e.g., Activo, Inactivo)
);

--Nuevas
CREATE TABLE Bancos (
    BancoId INT PRIMARY KEY IDENTITY(1,1), -- Asumí que este es un campo autoincremental
    Banco NVARCHAR(255) NOT NULL,          -- Asumí un tamaño de 255 caracteres para el nombre del banco
    Estado NVARCHAR(50) NOT NULL          -- Asumí un tamaño de 50 caracteres para el estado
);

CREATE TABLE TipoTarjeta (
    TipoTarjetaId INT PRIMARY KEY IDENTITY(1,1), -- Asumí que este es un campo autoincremental
    NombreTipo NVARCHAR(255) NOT NULL,           -- Asumí un tamaño de 255 caracteres para el nombre del tipo de 
    Estado NVARCHAR(50) NOT NULL,                -- Asumí un tamaño de 50 caracteres para el estado
	BancoId Int,
	Porcentaje float
);

CREATE TABLE Salas (
    SalaId INT PRIMARY KEY IDENTITY(1,1),        -- Clave primaria autoincremental
    NombreSala NVARCHAR(255) NOT NULL,          -- Nombre de la sala, asumí un tamaño de 255 caracteres
    NoMesas INT NULL,                           -- Número de mesas, puede ser NULL
    SucursalId nvarchar(50) NULL,                        -- ID de la sucursal, puede ser NULL
    Estado NVARCHAR(50) NOT NULL                -- Estado, asumí un tamaño de 50 caracteres
);

CREATE TABLE Empresa (
    IdEmpresa INT PRIMARY KEY IDENTITY(1,1), -- Llave primaria con incremento automático
    NombreEmpresa NVARCHAR(255) NOT NULL,   -- Campo requerido
    NombreComercial NVARCHAR(255) NOT NULL, -- Campo requerido
    Telefono NVARCHAR(20),                  -- Opcional, admite formato de teléfono
    Ruc NVARCHAR(20),                       -- Opcional, depende del formato del país
    Email NVARCHAR(255),                    -- Opcional, tamaño adecuado para emails
);

CREATE TABLE TasaCambio (
    IdTasaCambio INT PRIMARY KEY IDENTITY(1,1), -- Llave primaria autoincremental
    Tasa FLOAT NOT NULL, -- Representación del campo double
    FechaCambio DATETIME NOT NULL -- Representación del campo DateTime
);


Create table RelProveedoresProducto
(
    RelAlmacenProductoId decimal(18,0) identity(1,1) NOT NULL PRIMARY KEY,
    ProveedorId Integer NULL, 
    ProductoId NVARCHAR(50), 
)

create TABLE Mermas (
    MermaId INT IDENTITY(1,1) PRIMARY KEY,       -- Identificador único de la merma
    Identificador NVARCHAR(50) NULL,           -- Identificador adicional opcional
    Razon NVARCHAR(MAX) NULL,                   -- Razón de la merma
    CantidadMermada Decimal (18,1) NULL,                   -- Cantidad mermada (opcional)
    FechaRealizacion DATETIME NULL,             -- Fecha de realización de la merma
    PrecioVenta DECIMAL(18, 2) NULL ,           -- Precio de venta del producto mermado (opcional)
	[AlmacenId] NVARCHAR(50) NOT NULL,
	Usuario nvarchar(50),
	BoolRevertida bit default 1,
	UsuarioRevirtio nvarchar(50) null,
	ProductoId nvarchar(50) NOT NULL
);

CREATE TABLE Compras (
    CompraId nvarchar(50) PRIMARY KEY,                       -- La propiedad CompraId se usa como clave primaria
    Usuario nvarchar(200),                            -- La propiedad UsuarioId es nullable
    AlmacenId nvarchar(50),                            -- La propiedad AlmacenId es nullable
    SucursalId VARCHAR(50) NULL,                   -- La propiedad SucursalId es nullable y de tipo cadena
    Descripcion VARCHAR(255) NULL,                 -- La propiedad Descripcion es nullable y de tipo cadena
    CostoTotal DECIMAL(18, 2) NULL,                -- La propiedad CostoTotal es nullable y de tipo decimal
    FechaAlta DATETIME NULL                        -- La propiedad FechaAlta es nullable y de tipo datetime
);

CREATE TABLE CompraDetalles(
    LoteId NVARCHAR(50) NOT NULL, -- Asumiendo un tamaño de 50 caracteres, ajustable según tus necesidades.
    ProductoId nvarchar(50),
    CompraId nvarchar(50),
    Cantidad decimal(18,1) NULL,
    FechaCreacion DATETIME NULL,
    AlmacenId nvarchar(50) NULL,
    ProveedorId INT NULL,
    CostoU DECIMAL(18, 2) NULL, 
    SubTotal DECIMAL(18, 2) NULL,
    CONSTRAINT PK_LotesProducto PRIMARY KEY (LoteId) -- Asumiendo que LoteId es único.
);