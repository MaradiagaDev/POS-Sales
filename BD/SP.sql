--PROCEDIMIENTOS ALMACENADOS
cREATE PROCEDURE SP_LoginUser
    @UserName NVARCHAR(50),
    @Password NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    -- Generar el hash de la contraseña ingresada
    DECLARE @ClaveHash VARBINARY(MAX);
	Declare @userId nvarchar(50)
    SET @ClaveHash = HASHBYTES('SHA2_256', @Password);

    -- Verificar si el usuario y contraseña son válidos
    IF NOT EXISTS (
        SELECT 1 
        FROM Usuario 
        WHERE Usuario = @UserName AND ClaveUsuario = @ClaveHash
    )
    BEGIN
        SELECT 'Usuario o contraseña incorrectos.' AS Mensaje;
        RETURN;
    END

    -- Verificar si el usuario está habilitado (Estado = 'Activo')
    DECLARE @Estado NVARCHAR(50);
    SELECT @Estado = Estado,
	@userId = IdUsuario
    FROM Usuario
    WHERE Usuario = @UserName;

    IF @Estado <> 'Activo'
    BEGIN
        SELECT 'El usuario está inactivo.' AS Mensaje;
        RETURN;
    END

    -- Validar si el usuario tiene sucursales asignadas
    IF NOT EXISTS (
        SELECT 1 
        FROM UsuarioSucursal US
        INNER JOIN Usuario U ON US.IdUsuario = U.IdUsuario
        WHERE U.Usuario = @UserName
    )
    BEGIN
        SELECT 'El usuario no tiene sucursales asignadas.' AS Mensaje;
        RETURN;
    END

    -- Si todo es correcto, devolver mensaje de éxito
    SELECT 'Correcto',@userId AS Mensaje;
END;


cREATE PROCEDURE SP_SaveOrUpdateUser
    @IdUsuario NVARCHAR(50),
    @Usuario NVARCHAR(50),
    @ClaveUsuario NVARCHAR(MAX),
    @Estado NVARCHAR(50),
    @IdEmpleado NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Generar un hash de la contraseña con un algoritmo SHA2_256
    DECLARE @ClaveHash VARBINARY(MAX);
    SET @ClaveHash = HASHBYTES('SHA2_256', @ClaveUsuario);

    -- Verificar si el usuario ya existe
    IF EXISTS (SELECT 1 FROM Usuario WHERE IdUsuario = @IdUsuario)
    BEGIN
        -- Actualizar usuario existente
        UPDATE Usuario
        SET 
            Usuario = @Usuario,
            ClaveUsuario = @ClaveHash,
            Estado = @Estado,
            IdEmpleado = @IdEmpleado,
            FechaActualizo = GETDATE()
        WHERE IdUsuario = @IdUsuario;

        PRINT 'Usuario actualizado correctamente.';
    END
    ELSE
    BEGIN

        -- Crear nuevo usuario
        INSERT INTO Usuario (IdUsuario, Usuario, ClaveUsuario, Estado, IdEmpleado, FechaCreo)
        VALUES ( CONVERT(NVARCHAR(50), NEWID()), @Usuario, @ClaveHash, @Estado, @IdEmpleado, GETDATE());

        PRINT 'Usuario creado correctamente.';
    END
END;



CREATE PROCEDURE SP_OBTENERSUCURSALESUSUARIO
@IdUsuario as nvarchar(50)
as
begin
	select 
	s.*
	from Usuario u
	inner join UsuarioSucursal us
	on us.IdUsuario = u.IdUsuario
	inner join Sucursal s
	on s.IdSucursal = us.IdSucursal
	where u.IdUsuario = @IdUsuario 
end

exec SP_OBTENERSUCURSALESUSUARIO '972F3360-1C03-4897-8F23-E1FBAEA1D273'

CREATE PROCEDURE SP_CrearActualizarCliente
    @IdCliente decimal(18,0) = NULL,
    @PNombre NVARCHAR(255),
    @SNombre NVARCHAR(255),
    @PApellido NVARCHAR(255),
    @SAPellido NVARCHAR(255),
    @Estado FLOAT = 1,
    @Direccion NVARCHAR(255),
    @Telefono NVARCHAR(50),
    @Celular NVARCHAR(50),
    @Fax NVARCHAR(50) = NULL,
    @Edad FLOAT,
    @EstadoCivil NVARCHAR(255),
    @Profesion NVARCHAR(255) = NULL,
    @Sexo NVARCHAR(255),
    @Cedula NVARCHAR(255),
    @FechaNac DATE,
    @Email NVARCHAR(60),
    @Departamento NVARCHAR(100),
    @Pais NVARCHAR(100),
    @Observacion NVARCHAR(400) = NULL,
    @NoRuc NVARCHAR(50) = NULL,
    @IdSucursal NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Si el IdCliente es NULL, significa que es una creación
    IF @IdCliente IS NULL
    BEGIN
        -- Crear nuevo cliente
        INSERT INTO [dbo].[Clientes] (
            [PNombre], [SNombre], [PApellido], [SAPellido], [Estado], [Direccion], 
            [Telefono], [Celular], [Fax], [Edad], [Estado Civil], [Profesion], 
            [Sexo], [Cedula], [FechaNac], [Email], [Departamento], [pais], 
            [observacion], [NoRuc], [IdSucursal]
        )
        VALUES (
            @PNombre, @SNombre, @PApellido, @SAPellido, @Estado, @Direccion,
            @Telefono, @Celular, @Fax, @Edad, @EstadoCivil, @Profesion,
            @Sexo, @Cedula, @FechaNac, @Email, @Departamento, @Pais,
            @Observacion, @NoRuc, @IdSucursal
        );

        SELECT 'Cliente creado correctamente' AS Mensaje;
    END
    ELSE
    BEGIN
        -- Si el IdCliente existe, actualizamos los datos del cliente
        UPDATE [dbo].[Clientes]
        SET 
            [PNombre] = @PNombre,
            [SNombre] = @SNombre,
            [PApellido] = @PApellido,
            [SAPellido] = @SAPellido,
            [Estado] = @Estado,
            [Direccion] = @Direccion,
            [Telefono] = @Telefono,
            [Celular] = @Celular,
            [Fax] = @Fax,
            [Edad] = @Edad,
            [Estado Civil] = @EstadoCivil,
            [Profesion] = @Profesion,
            [Sexo] = @Sexo,
            [Cedula] = @Cedula,
            [FechaNac] = @FechaNac,
            [Email] = @Email,
            [Departamento] = @Departamento,
            [pais] = @Pais,
            [observacion] = @Observacion,
            [NoRuc] = @NoRuc,
            [IdSucursal] = @IdSucursal
        WHERE [IdCliente] = @IdCliente;

        SELECT 'Cliente actualizado correctamente' AS Mensaje;
    END
END


alter PROCEDURE [dbo].[sp_ObtenerClientesFiltrados]
    @FiltroPor INT, -- 0 = ID, 1 = Nombre completo, 2 = Cédula
    @FiltroValor NVARCHAR(255), -- Valor a filtrar
    @IdSucursal NVARCHAR(50), -- ID de la sucursal para filtrar
    @PageNumber INT = 1, -- Página actual
    @PageSize INT = 10 -- Número de registros por página
AS
BEGIN
    SET NOCOUNT ON;

    -- Variables para el cálculo de paginación
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
    DECLARE @TotalRows INT;

    -- Filtrado de clientes según el filtro seleccionado
    IF @FiltroPor = 0
    BEGIN
        SELECT @TotalRows = COUNT(*) 
        FROM [dbo].[Clientes]
        WHERE CAST(IdCliente AS NVARCHAR) = @FiltroValor 
        AND (@IdSucursal = '0' OR IdSucursal = @IdSucursal);

        SELECT * 
        FROM [dbo].[Clientes]
        WHERE CAST(IdCliente AS NVARCHAR) = @FiltroValor 
        AND (@IdSucursal = '0' OR IdSucursal = @IdSucursal)
        ORDER BY IdCliente DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END
    ELSE IF @FiltroPor = 1
    BEGIN
        SELECT @TotalRows = COUNT(*) 
        FROM [dbo].[Clientes]
        WHERE (PNombre + ' ' + SNombre + ' ' + PApellido + ' ' + SAPellido) LIKE '%' + @FiltroValor + '%'
        AND (@IdSucursal = '0' OR IdSucursal = @IdSucursal);

        SELECT * 
        FROM [dbo].[Clientes]
        WHERE (PNombre + ' ' + SNombre + ' ' + PApellido + ' ' + SAPellido) LIKE '%' + @FiltroValor + '%'
        AND (@IdSucursal = '0' OR IdSucursal = @IdSucursal)
        ORDER BY IdCliente DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END
    ELSE IF @FiltroPor = 2
    BEGIN
        SELECT @TotalRows = COUNT(*) 
        FROM [dbo].[Clientes]
        WHERE Cedula LIKE '%' + @FiltroValor + '%'
        AND (@IdSucursal = '0' OR IdSucursal = @IdSucursal);

        SELECT * 
        FROM [dbo].[Clientes]
        WHERE Cedula LIKE '%' + @FiltroValor + '%'
        AND (@IdSucursal = '0' OR IdSucursal = @IdSucursal)
        ORDER BY IdCliente DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END
END


CREATE PROCEDURE CambiarEstadoCliente
    @IdCliente INT
AS
BEGIN
    DECLARE @EstadoActual INT;

    -- Obtener el estado actual del cliente
    SELECT @EstadoActual = Estado
    FROM Clientes
    WHERE IdCliente = @IdCliente;

    -- Cambiar el estado (si es 0 lo pone en 1, si es 1 lo pone en 0)
    IF @EstadoActual = 0
    BEGIN
        UPDATE Clientes
        SET Estado = 1
        WHERE IdCliente = @IdCliente;
    END
    ELSE
    BEGIN
        UPDATE Clientes
        SET Estado = 0
        WHERE IdCliente = @IdCliente;
    END
END


--SP 26/11/2024

exec sp_ObtenerCantidadProductoPorSucursalYCategoria '0',0

create PROCEDURE sp_ObtenerCantidadProductoPorSucursalYCategoria
    @IdSucursal NVARCHAR(50), -- Parámetro para filtrar por sucursal
    @CategoriaId INT ,         -- Parámetro para filtrar por categoría,
	@Filtro nvarchar(Max)
AS
BEGIN
    SET NOCOUNT ON;

    -- Selección de datos considerando los filtros proporcionados
    SELECT 
        P.ProductoId as [ID],                -- ID del producto
        P.NombreProducto as [PRODUCTO],           -- Nombre del producto
        P.Precio AS [PRECIO (NIO)],                   -- Precio del producto
        SUM(R.Cantidad)  AS [EXISTENCIA]-- Suma de cantidades
    FROM RelAlmacenProducto R
    INNER JOIN Almacenes A ON R.AlmacenId = A.AlmacenId
    INNER JOIN ProductosServicios P ON R.ProductoId = P.ProductoId
    WHERE (@IdSucursal = '0' OR A.SucursalId = @IdSucursal) -- Filtro por sucursal
      AND (@CategoriaId = 0 OR P.CategoriaId = @CategoriaId) -- Filtro por categoría
	  And p.ClasificacionProducto = 'Productos' and p.Estado = 'Activo' and p.NombreProducto like '%'+@Filtro+'%'  
    GROUP BY 
        P.ProductoId, 
        P.NombreProducto, 
        P.Precio;
END;
GO

alter PROCEDURE sp_ObtenerCantidadProductoPorAlmacen
    @AlmacenId NVARCHAR(50), -- Parámetro para filtrar por almacén
    @CategoriaId INT,        -- Parámetro para filtrar por categoría
	@Filtro nvarchar(Max)
AS
BEGIN
    SET NOCOUNT ON;

    -- Selección de datos considerando los filtros proporcionados
    SELECT 
		P.ProductoId AS [ID],
        p.NombreProducto as PRODUCTO,  
		p.Precio as [PRECIO (NIO)],
        SUM(R.Cantidad) AS  [EXISTENCIA]
    FROM RelAlmacenProducto R
    INNER JOIN Almacenes A ON R.AlmacenId = A.AlmacenId
    INNER JOIN ProductosServicios P ON R.ProductoId = P.ProductoId
    WHERE (@AlmacenId = '0' OR A.AlmacenId = @AlmacenId) -- Filtro por almacén
      AND (@CategoriaId = 0 OR P.CategoriaId = @CategoriaId) -- Filtro por categoría
	  And p.ClasificacionProducto = 'Productos' and p.Estado = 'Activo' and p.NombreProducto like '%'+@Filtro+'%' 
    GROUP BY 
        P.ProductoId, 
        p.NombreProducto,
		p.Precio;
END;
GO

alter PROCEDURE sp_GetComprasPorSucursal
    @IdSucursal NVARCHAR(50) -- Parámetro para filtrar por sucursal (acepta "0" para todas)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.CompraId ,
        c.CostoTotal AS Total,
        c.FechaAlta AS Fecha,
        c.Usuario,
        a.NombreAlmacen,
        s.NombreSucursal,
        c.Descripcion,
		c.UsuarioRevirtio
    FROM 
        Compras c
    INNER JOIN 
        Almacenes a ON c.AlmacenId = a.AlmacenId
    INNER JOIN
        Sucursal s ON c.SucursalId = s.IdSucursal -- Relación entre Almacenes y Sucursal
    WHERE 
        (@IdSucursal = '0' OR s.IdSucursal = @IdSucursal)
    ORDER BY 
        c.FechaAlta DESC; -- Ordena las compras por fecha en orden descendente
END;
GO

exec sp_GetComprasPorSucursal 'S001'


create PROCEDURE sp_ObtenerCantidadProductoPorAlmacenYProveedor
    @AlmacenId NVARCHAR(50), -- Parámetro para filtrar por almacén
    @CategoriaId INT,        -- Parámetro para filtrar por categoría
    @ProveedorId NVARCHAR(50), -- Parámetro para filtrar por proveedor
    @Filtro NVARCHAR(MAX)    -- Parámetro para filtrar por nombre del producto
AS
BEGIN
    SET NOCOUNT ON;

    -- Selección de datos considerando los filtros proporcionados
    SELECT 
        P.ProductoId ,
        P.NombreProducto ,  
        P.Precio ,
        SUM(R.Cantidad) as cantidad
    FROM 
        RelAlmacenProducto R
    INNER JOIN 
        Almacenes A ON R.AlmacenId = A.AlmacenId
    INNER JOIN 
        ProductosServicios P ON R.ProductoId = P.ProductoId
    INNER JOIN 
        RelProveedoresProducto PP ON P.ProductoId = PP.ProductoId -- Relación con proveedores
    WHERE 
        (@AlmacenId = '0' OR A.AlmacenId = @AlmacenId) -- Filtro por almacén
        AND (@CategoriaId = 0 OR P.CategoriaId = @CategoriaId) -- Filtro por categoría
        AND (@ProveedorId = '0' OR PP.ProveedorId = @ProveedorId) -- Filtro por proveedor
        AND P.ClasificacionProducto = 'Productos'
        AND P.Estado = 'Activo'
        AND P.NombreProducto LIKE '%' + @Filtro + '%' -- Filtro por nombre
    GROUP BY 
        P.ProductoId, 
        P.NombreProducto,
        P.Precio;
END;
GO

create VIEW vw_ProveedoresActivos AS
SELECT 
    IdProveedor,
    NombreEmpresa,
    NoTelefono,
    Correo,
    Direccion,
	NoRuc
FROM 
    Proveedores
WHERE 
    Estatus = 'Activo'; -- Asegúrate de que el estado activo se almacene con esta denomin


create PROCEDURE sp_GetProveedoresActivos
    @NombreProveedor NVARCHAR(100) -- Parámetro para filtrar por nombre del proveedor (cadena vacía para todos)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdProveedor,
        NombreEmpresa,
        NoTelefono,
        Correo,
        Direccion,
		NoRuc
    FROM 
        Proveedores
    WHERE 
        Estatus = 'Activo' -- Solo incluye proveedores activos
        AND (@NombreProveedor = '' OR NombreEmpresa LIKE '%' + @NombreProveedor + '%')
    ORDER BY 
        NombreEmpresa ASC; -- Ordena por nombre del proveedor
END;
GO

exec RevertirCompra '3c10eb0a-012d-42c3-aadc-a8fae782832d','rmaradiaga'
alter PROCEDURE RevertirCompra
    @CompraId NVARCHAR(50),
	@Usuario nvarchar(200)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Variables para manejar los resultados
    DECLARE @ProductoId NVARCHAR(50), @CantidadNecesaria DECIMAL(18, 1), @AlmacenId NVARCHAR(50);
    DECLARE @NombreProducto NVARCHAR(MAX), @CantidadDisponible DECIMAL(18, 1);
    DECLARE @ErrorMensaje NVARCHAR(MAX);

    -- Cursor para recorrer los detalles de la compra
    DECLARE CursorDetalles CURSOR FOR
    SELECT 
        cd.ProductoId, 
        cd.Cantidad, 
        cd.AlmacenId,
        ps.NombreProducto
    FROM CompraDetalles cd
    INNER JOIN ProductosServicios ps ON cd.ProductoId = ps.ProductoId
    WHERE cd.CompraId = @CompraId;

    OPEN CursorDetalles;

    FETCH NEXT FROM CursorDetalles INTO @ProductoId, @CantidadNecesaria, @AlmacenId, @NombreProducto;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Verificar la cantidad disponible en el almacén
        SELECT @CantidadDisponible = ISNULL(ra.Cantidad, 0)
        FROM RelAlmacenProducto ra
        WHERE ra.ProductoId = @ProductoId AND ra.AlmacenId = @AlmacenId;

        -- Si no hay suficiente inventario
        IF @CantidadDisponible < @CantidadNecesaria
        BEGIN
            SET @ErrorMensaje = CONCAT('No hay inventario suficiente del producto: ', @NombreProducto);
            select @ErrorMensaje;
            CLOSE CursorDetalles;
            DEALLOCATE CursorDetalles;
            RETURN;
        END

        FETCH NEXT FROM CursorDetalles INTO @ProductoId, @CantidadNecesaria, @AlmacenId, @NombreProducto;
    END

    CLOSE CursorDetalles;
    DEALLOCATE CursorDetalles;

    -- Revertir la compra
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Actualizar la cantidad en el almacén
     UPDATE RelAlmacenProducto
SET Cantidad = RelAlmacenProducto.Cantidad - cd.Cantidad
FROM CompraDetalles cd
WHERE RelAlmacenProducto.ProductoId = cd.ProductoId
  AND RelAlmacenProducto.AlmacenId = cd.AlmacenId
  AND cd.CompraId = @CompraId;


        -- Eliminar la compra
        update Compras
		set UsuarioRevirtio = @Usuario
        WHERE CompraId = @CompraId;

        COMMIT TRANSACTION;
        select 'La compra ha sido revertida exitosamente.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;

CREATE PROCEDURE Sp_CrearTrasladoInventario
    @TrasladoId NVARCHAR(50),
    @FechaTraslado NVARCHAR(100),
    @Usuario NVARCHAR(200),
    @SucursalId NVARCHAR(50),
    @AlmacenIdEntrada NVARCHAR(50),
    @AlmacenIdSalida NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que ambos almacenes existan
    IF NOT EXISTS (SELECT 1 FROM Almacenes WHERE AlmacenId = @AlmacenIdEntrada)
    BEGIN
        RAISERROR('El almacén de entrada no existe.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Almacenes WHERE AlmacenId = @AlmacenIdSalida)
    BEGIN
        RAISERROR('El almacén de salida no existe.', 16, 1);
        RETURN;
    END

    -- Crear el registro de traslado
    INSERT INTO TrasladosInventario (TrasladoId, FechaTraslado, Usuario, SucursalId, AlmacenIdEntrada, AlmacenIdSalida)
    VALUES (@TrasladoId, @FechaTraslado, @Usuario, @SucursalId, @AlmacenIdEntrada, @AlmacenIdSalida);
END;
GO

CREATE PROCEDURE Sp_CrearTrasladoDetalle
    @TrasladoId NVARCHAR(50),
    @ProductoId NVARCHAR(50),
    @Cantidad DECIMAL(18, 1)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que exista el encabezado del traslado
    IF NOT EXISTS (SELECT 1 FROM TrasladosInventario WHERE TrasladoId = @TrasladoId)
    BEGIN
        RAISERROR('El traslado especificado no existe.', 16, 1);
        RETURN;
    END

    -- Validar que exista suficiente inventario en el almacén de salida
    DECLARE @AlmacenIdSalida NVARCHAR(50);
    SELECT @AlmacenIdSalida = AlmacenIdSalida 
    FROM TrasladosInventario
    WHERE TrasladoId = @TrasladoId;

    IF NOT EXISTS (SELECT 1 
                   FROM RelAlmacenProducto
                   WHERE AlmacenId = @AlmacenIdSalida AND ProductoId = @ProductoId AND Cantidad >= @Cantidad)
    BEGIN
        RAISERROR('Inventario insuficiente en el almacén de salida.', 16, 1);
        RETURN;
    END

    -- Registrar el detalle del traslado
    INSERT INTO TrasladoDetalles (TrasladoId, ProductoId, Cantidad)
    VALUES (@TrasladoId, @ProductoId, @Cantidad);

    -- Actualizar el inventario:
    -- 1. Restar del almacén de salida
    UPDATE RelAlmacenProducto
    SET Cantidad = Cantidad - @Cantidad
    WHERE AlmacenId = @AlmacenIdSalida AND ProductoId = @ProductoId;

    -- 2. Sumar al almacén de entrada
    DECLARE @AlmacenIdEntrada NVARCHAR(50);
    SELECT @AlmacenIdEntrada = AlmacenIdEntrada 
    FROM TrasladosInventario
    WHERE TrasladoId = @TrasladoId;

    IF EXISTS (SELECT 1 FROM RelAlmacenProducto WHERE AlmacenId = @AlmacenIdEntrada AND ProductoId = @ProductoId)
    BEGIN
        UPDATE RelAlmacenProducto
        SET Cantidad = Cantidad + @Cantidad
        WHERE AlmacenId = @AlmacenIdEntrada AND ProductoId = @ProductoId;
    END
    ELSE
    BEGIN
        INSERT INTO RelAlmacenProducto (AlmacenId, ProductoId, Cantidad)
        VALUES (@AlmacenIdEntrada, @ProductoId, @Cantidad);
    END
END;
GO


alter PROCEDURE sp_ListarProductosConAlertas
    @FiltroNombre NVARCHAR(100) = NULL,
    @FiltroAlmacenId NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar y completar datos faltantes en AlertasInventario
    INSERT INTO AlertasInventario (ProductoId, AlmacenId, CantidadMinima, CantidadMaxima)
    SELECT p.ProductoId, a.AlmacenId, 0, 0
    FROM ProductosServicios p
    CROSS JOIN Almacenes a
    LEFT JOIN AlertasInventario ai
        ON p.ProductoId = ai.ProductoId AND a.AlmacenId = ai.AlmacenId
    WHERE ai.AlertaId IS NULL  and p.ClasificacionProducto = 'Productos';

    -- Consultar productos y alertas con filtros
    SELECT 
		ai.AlertaId,
        p.ProductoId,
        p.NombreProducto,
        ai.AlmacenId,
        ISNULL(ai.CantidadMinima, 0) AS CantidadMinima,
        ISNULL(ai.CantidadMaxima, 0) AS CantidadMaxima
    FROM ProductosServicios p
    LEFT JOIN AlertasInventario ai
        ON p.ProductoId = ai.ProductoId
    LEFT JOIN Almacenes a
        ON ai.AlmacenId = a.AlmacenId
    WHERE (@FiltroNombre IS NULL OR p.NombreProducto LIKE '%' + @FiltroNombre + '%')
      AND (@FiltroAlmacenId IS NULL OR ai.AlmacenId = @FiltroAlmacenId) and p.ClasificacionProducto = 'Productos'
    ORDER BY p.NombreProducto, ai.AlmacenId;
END;

ALTER PROCEDURE Sp_KardexPromedio
    @ProductoId NVARCHAR(50),
    @AlmacenId NVARCHAR(50),
    @FechaInicial DATE,
    @FechaFinal DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Tabla temporal para almacenar resultados del kardex
    CREATE TABLE #Kardex
    (
        Fecha DATETIME,
        TipoMovimiento NVARCHAR(50),
        AlmacenMovimiento NVARCHAR(100),
        Cantidad DECIMAL(18,1),
        CostoUnitario DECIMAL(18,2),
        CostoTotal DECIMAL(18,2)
    );

    -- Obtener compras relacionadas al producto y almacén entre las fechas
    INSERT INTO #Kardex (Fecha, TipoMovimiento, AlmacenMovimiento, Cantidad, CostoUnitario, CostoTotal)
    SELECT 
        FechaAlta AS Fecha,
        CASE 
            WHEN UsuarioRevirtio IS NOT NULL THEN 'Compra Revertida'
            ELSE 'Compra'
        END AS TipoMovimiento,
        NULL AS AlmacenMovimiento,
        CASE 
            WHEN UsuarioRevirtio IS NOT NULL THEN -Cantidad
            ELSE Cantidad
        END AS Cantidad,
        CostoU AS CostoUnitario,
        CASE 
            WHEN UsuarioRevirtio IS NOT NULL THEN -(Cantidad * CostoU)
            ELSE (Cantidad * CostoU)
        END AS CostoTotal
    FROM CompraDetalles CD
    INNER JOIN Compras C ON CD.CompraId = C.CompraId
    WHERE 
        CD.ProductoId = @ProductoId AND 
        C.AlmacenId = @AlmacenId AND 
        C.FechaAlta BETWEEN @FechaInicial AND @FechaFinal;

    -- Obtener traslados relacionados al producto y almacén entre las fechas
    INSERT INTO #Kardex (Fecha, TipoMovimiento, AlmacenMovimiento, Cantidad, CostoUnitario, CostoTotal)
    SELECT 
        TI.FechaTraslado AS Fecha,
        CASE 
            WHEN TI.AlmacenIdEntrada = @AlmacenId THEN 'Entrada por Traslado'
            WHEN TI.AlmacenIdSalida = @AlmacenId THEN 'Salida por Traslado'
        END AS TipoMovimiento,
        CASE 
            WHEN TI.AlmacenIdEntrada = @AlmacenId THEN ASalida.NombreAlmacen
            WHEN TI.AlmacenIdSalida = @AlmacenId THEN  AEntrada.NombreAlmacen
        END AS AlmacenMovimiento,
        CASE 
            WHEN TI.AlmacenIdEntrada = @AlmacenId THEN TD.Cantidad
            WHEN TI.AlmacenIdSalida = @AlmacenId THEN -TD.Cantidad
        END AS Cantidad,
        0 AS CostoUnitario,
        0 AS CostoTotal
    FROM TrasladoDetalles TD
    INNER JOIN TrasladosInventario TI
        ON TD.TrasladoId = TI.TrasladoId
    LEFT JOIN Almacenes AEntrada
        ON TI.AlmacenIdEntrada = AEntrada.AlmacenId
    LEFT JOIN Almacenes ASalida
        ON TI.AlmacenIdSalida = ASalida.AlmacenId
    WHERE 
        TD.ProductoId = @ProductoId AND 
        (TI.AlmacenIdEntrada = @AlmacenId OR TI.AlmacenIdSalida = @AlmacenId) AND 
        TI.FechaTraslado BETWEEN @FechaInicial AND @FechaFinal;

    -- Obtener mermas relacionadas al producto y almacén entre las fechas
    INSERT INTO #Kardex (Fecha, TipoMovimiento, AlmacenMovimiento, Cantidad, CostoUnitario, CostoTotal)
    SELECT 
        TRY_CONVERT(DATETIME, FechaRealizacion) AS Fecha,
        CASE 
            WHEN UsuarioRevirtio IS NULL THEN 'Merma'
            ELSE 'Merma Revertida'
        END AS TipoMovimiento,
        NULL AS AlmacenMovimiento,
        CASE 
            WHEN UsuarioRevirtio IS NULL THEN -CantidadMermada
            ELSE 0
        END AS Cantidad,
        PrecioVenta AS CostoUnitario, -- Si hay un costo asociado a la merma
        CASE 
            WHEN UsuarioRevirtio IS NULL THEN -(CantidadMermada * PrecioVenta)
            ELSE (CantidadMermada * PrecioVenta)
        END AS CostoTotal
    FROM Mermas
    WHERE 
        ProductoId = @ProductoId AND 
        AlmacenId = @AlmacenId AND 
        TRY_CONVERT(DATETIME, FechaRealizacion) BETWEEN @FechaInicial AND @FechaFinal;

    -- Calcular el inventario promedio
    DECLARE @CantidadTotal DECIMAL(18,1) = 0;
    DECLARE @CostoTotalProducto DECIMAL(18,2) = 0;

    SELECT 
        @CantidadTotal = SUM(Cantidad),
        @CostoTotalProducto = SUM(CostoTotal)
    FROM #Kardex;

    DECLARE @CostoPromedio DECIMAL(18,2) = 0;

    -- Cálculo del costo promedio
    IF @CantidadTotal > 0
        SET @CostoPromedio = @CostoTotalProducto / @CantidadTotal;

    -- Devolver resultados
    SELECT 
        Fecha,
        TipoMovimiento,
        AlmacenMovimiento,
        Cantidad,
        CostoUnitario,
        CostoTotal,
        @CostoPromedio AS CostoPromedioProducto
    FROM #Kardex
    ORDER BY Fecha;

    DROP TABLE #Kardex;
END;

exec sp_ObtenerServicios 0,''

alter PROCEDURE sp_ObtenerServicios
    @CategoriaId INT,        -- Parámetro para filtrar por categoría
	@Filtro nvarchar(Max)
AS
BEGIN
    SET NOCOUNT ON;

    -- Selección de datos considerando los filtros proporcionados
    SELECT 
		P.ProductoId AS [ID],
        p.NombreProducto as SERVICIO,  
		p.Precio as [PRECIO (NIO)]
    FROM ProductosServicios P 
    WHERE 
         (@CategoriaId = 0 OR P.CategoriaId = @CategoriaId) -- Filtro por categoría
	  And p.ClasificacionProducto = 'Servicios' and p.Estado = 'Activo' and p.NombreProducto like '%'+@Filtro+'%' 
    GROUP BY 
        P.ProductoId, 
        p.NombreProducto,
		p.Precio;
END;
GO

create view vwSalas
as
Select * from Salas where Estado ='Activo'

create view vwMotivosCancelacion
as
Select * from MotivosCancelacion where Estado ='Activo'

alter PROCEDURE sp_ObtenerOrdenesPorSucursal 
    @idSucursal nvarchar(50),
	@filtro nvarchar(255)
AS
BEGIN
    -- Seleccionar solo las órdenes abiertas y que cumplan con las condiciones dadas
    SELECT 
        o.OrdenId,
        o.ClienteId,
        CASE 
            WHEN o.ClienteId = '0' THEN 'CLIENTE MOSTRADOR'
            ELSE c.PNombre+' '+Isnull(c.SNombre,'')+' '+Isnull(c.PApellido,'')+' '+isnull(c.SAPellido,'')
        END AS NombreCliente,
        o.FechaRealizacion,
        o.OrdenProceso,
        o.PagoProceso,
        o.TotalOrden,
        o.Pagado
    FROM 
        Ordenes o
    LEFT JOIN 
        Clientes c ON o.ClienteId = c.IdCliente
    WHERE 
        o.SucursalId = @idSucursal
        AND o.OrdenProceso = 'Orden Abierta'
        AND o.SalaMesa = '-'and
		o.BitEsCredito = 0
		 AND (
            @filtro IS NULL OR
            o.OrdenId LIKE '%' + @filtro + '%' OR
            c.PNombre + ' ' + ISNULL(c.SNombre, '') + ' ' + ISNULL(c.PApellido, '') + ' ' + ISNULL(c.SAPellido, '') LIKE '%' + @filtro + '%'
        )
END

exec sp_ObtenerOrdenesPorSucursal 'S002'

create proc spSalas
@idSucursal nvarchar(50)
as
begin
Select * from Salas where Estado ='Activo' and SucursalId = @idSucursal
end

--SP CANTIDADES
-- Procedimiento almacenado para manejar el detalle de la orden
alter PROCEDURE sp_ManageOrderDetail
    @OrderId decimal,
    @ProductId NVARCHAR(50),
    @Quantity decimal(18,1),
    @Action NVARCHAR(20), -- 'Increase' o 'Decrease'
    @WarehouseId nvarchar(50),
    @Discount DECIMAL(10, 2), -- Descuento en monto
    @Total DECIMAL(18, 2) OUTPUT,
    @Subtotal DECIMAL(18, 2) OUTPUT,
    @IVA DECIMAL(18, 2) OUTPUT-- Impuesto sobre ventas calculado
AS
BEGIN
    SET NOCOUNT ON;

    -- Variables locales
    DECLARE @CurrentStock INT;
    DECLARE @Price DECIMAL(10, 2);
    DECLARE @CurrentQuantity INT;
    DECLARE @DetailId INT;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Verificar si hay inventario suficiente para el producto en el almacén
        SELECT @CurrentStock = Cantidad
        FROM RelAlmacenProducto
        WHERE ProductoId = @ProductId AND AlmacenId = @WarehouseId;

        -- Obtener el precio del producto
        SELECT @Price = Precio
        FROM ProductosServicios
        WHERE ProductoId = @ProductId;

        -- Verificar si el producto ya está en el detalle de la orden
        SELECT @DetailId = OrdenDetalleId, @CurrentQuantity = Cantidad
        FROM OrdenDetalle
        WHERE OrdenId = @OrderId AND ProductoId = @ProductId;

        IF @DetailId IS NULL AND @Action = 'Increase'
        BEGIN
            -- Insertar nuevo detalle si no existe
            INSERT INTO OrdenDetalle (OrdenId, ProductoId, Cantidad, PrecioUnitario,Subtotal)
            VALUES (@OrderId, @ProductId, @Quantity, @Price,(@Price*@Quantity));
        END
        ELSE
        BEGIN
            -- Actualizar la cantidad existente
            IF @Action = 'Increase'
                SET @CurrentQuantity = @CurrentQuantity + @Quantity;
            ELSE
                SET @CurrentQuantity = @CurrentQuantity - @Quantity;

            IF @CurrentQuantity <= 0
            BEGIN
                -- Eliminar el detalle si la cantidad es 0 o menor
                DELETE FROM OrdenDetalle WHERE OrdenDetalleId = @DetailId;
            END
            ELSE
            BEGIN
                -- Actualizar la cantidad
                UPDATE OrdenDetalle
                SET Cantidad = @CurrentQuantity,
				Subtotal = @CurrentQuantity * @Price
                WHERE OrdenDetalleId = @DetailId;
            END
        END

        -- Actualizar el inventario en RelAlmacenProducto
        IF @Action = 'Increase'
            SET @CurrentStock = @CurrentStock - @Quantity;
        ELSE
            SET @CurrentStock = @CurrentStock + @Quantity;

        UPDATE RelAlmacenProducto
        SET Cantidad = @CurrentStock
        WHERE ProductoId = @ProductId AND AlmacenId = @WarehouseId;

        -- Calcular subtotal, IVA y total de la orden
        SELECT @Subtotal = SUM(PrecioUnitario * Cantidad)
        FROM OrdenDetalle
        WHERE OrdenId = @OrderId;

        SET @IVA = @Subtotal * 0.15; -- Asumiendo un IVA del 15%
        SET @Total = @Subtotal + @IVA - @Discount;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Procedimiento almacenado para verificar inventario suficiente
alter PROCEDURE sp_CheckInventory
    @ProductId nvarchar(50),
    @WarehouseId nvarchar(50),
    @Quantity decimal(18,1)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentStock INT;

    SELECT @CurrentStock = Cantidad
    FROM RelAlmacenProducto
    WHERE ProductoId = @ProductId AND AlmacenId = @WarehouseId;

    IF @CurrentStock < @Quantity
    BEGIN
        select '1';
    END
    ELSE
    BEGIN
        select '0';
    END
END
GO


select * from ProductosServicios where 
ProductoId = '09ef755e-6143-4604-a1f2-f2dcf9241dc6'

exec sp_CheckInventory '09ef755e-6143-4604-a1f2-f2dcf9241dc6','A001',1

CREATE PROCEDURE sp_ManageOrderServiceDetail
    @OrderId DECIMAL,
    @ServiceId NVARCHAR(50),
    @Quantity DECIMAL(18,1),
    @Action NVARCHAR(20), -- 'Increase' o 'Decrease'
    @Discount DECIMAL(10, 2), -- Descuento en monto
    @Total DECIMAL(18, 2) OUTPUT,
    @Subtotal DECIMAL(18, 2) OUTPUT,
    @IVA DECIMAL(18, 2) OUTPUT -- Impuesto sobre ventas calculado
AS
BEGIN
    SET NOCOUNT ON;

    -- Variables locales
    DECLARE @Price DECIMAL(10, 2);
    DECLARE @CurrentQuantity DECIMAL(18,1);
    DECLARE @DetailId INT;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Obtener el precio del servicio
        SELECT @Price = Precio
        FROM ProductosServicios
        WHERE ProductoId = @ServiceId;

        -- Verificar si el servicio ya está en el detalle de la orden
        SELECT @DetailId = OrdenDetalleId, @CurrentQuantity = Cantidad
        FROM OrdenDetalle
        WHERE OrdenId = @OrderId AND ProductoId = @ServiceId;

        IF @DetailId IS NULL AND @Action = 'Increase'
        BEGIN
            -- Insertar nuevo detalle si no existe
            INSERT INTO OrdenDetalle (OrdenId, ProductoId, Cantidad, PrecioUnitario, Subtotal)
            VALUES (@OrderId, @ServiceId, @Quantity, @Price, (@Price * @Quantity));
        END
        ELSE
        BEGIN
            -- Actualizar la cantidad existente
            IF @Action = 'Increase'
                SET @CurrentQuantity = @CurrentQuantity + @Quantity;
            ELSE
                SET @CurrentQuantity = @CurrentQuantity - @Quantity;

            IF @CurrentQuantity <= 0
            BEGIN
                -- Eliminar el detalle si la cantidad es 0 o menor
                DELETE FROM OrdenDetalle WHERE OrdenDetalleId = @DetailId;
            END
            ELSE
            BEGIN
                -- Actualizar la cantidad
                UPDATE OrdenDetalle
                SET Cantidad = @CurrentQuantity, Subtotal = @CurrentQuantity * @Price
                WHERE OrdenDetalleId = @DetailId;
            END
        END

        -- Calcular subtotal, IVA y total de la orden
        SELECT @Subtotal = SUM(PrecioUnitario * Cantidad)
        FROM OrdenDetalle
        WHERE OrdenId = @OrderId;

        SET @IVA = @Subtotal * 0.15; -- Asumiendo un IVA del 15%
        SET @Total = @Subtotal + @IVA - @Discount;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END


alter PROCEDURE Sp_CalcularTotalesOrden
    @IdOrden decimal,
    @AplicaRetencionDgi BIT,
    @AplicaRetencionAlcaldia BIT,
    @DescuentoAdicional DECIMAL(18, 2),
    @CalcularIVA BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declaración de variables
    DECLARE @Subtotal DECIMAL(18, 2),
            @IVA DECIMAL(18, 2),
            @Descuento DECIMAL(18, 2),
            @RetencionDgi DECIMAL(18, 2),
            @RetencionAlcaldia DECIMAL(18, 2),
            @TotalCordoba DECIMAL(18, 2),
            @TotalDolar DECIMAL(18, 2),
            @TipoCambio DECIMAL(18, 2),
			@bitEsCredito bit,
			@montoCredito decimal(18,2)



    -- Obtener el subtotal de los detalles de la orden
    SELECT @Subtotal = SUM(Cantidad * PrecioUnitario)
    FROM OrdenDetalle
    WHERE OrdenId = @IdOrden;

	select 
	@bitEsCredito = IsNull(BitEsCredito,0), @montoCredito = IsNull(MontoCredito,0)
	from Ordenes
	 WHERE OrdenId = @IdOrden;

	if @bitEsCredito = 1 
	begin
	set @Subtotal = (@Subtotal + @montoCredito)
	end

	set @Subtotal = @Subtotal - @DescuentoAdicional

    -- Calcular IVA solo si se especifica
    IF @CalcularIVA = 1
        SET @IVA = @Subtotal-(@Subtotal/1.15); -- IVA incluido en el precio
    ELSE
        SET @IVA = 0;
		set @SubTotal = (@SubTotal -@IVA) 

    -- Total tras descuento
    SET @TotalCordoba = ((@Subtotal) + @IVA);

    -- Aplicar retenciones si corresponden
    IF @AplicaRetencionDgi = 1
        SET @RetencionDgi = @TotalCordoba * 0.02; -- 2% DGI
    ELSE
        SET @RetencionDgi = 0;

    IF @AplicaRetencionAlcaldia = 1
        SET @RetencionAlcaldia = @TotalCordoba * 0.01; -- 1% Alcaldía
    ELSE
        SET @RetencionAlcaldia = 0;

    -- Total tras retenciones
    SET @TotalCordoba = @TotalCordoba - (@RetencionDgi + @RetencionAlcaldia);

    -- Obtener tipo de cambio (asumimos que está en la tabla Ordenes o parametrizado)
    SELECT @TipoCambio = CambioDolar
    FROM Ordenes
    WHERE OrdenId = @IdOrden;

    -- Calcular total en dólares
    SET @TotalDolar = @TotalCordoba / @TipoCambio;

    -- Actualizar la tabla Ordenes con los totales calculados
    UPDATE Ordenes
    SET Subtotal = Isnull(@Subtotal,0),
        IVA = Isnull(@IVA,0),
        Descuento = Isnull(@DescuentoAdicional,0),
        RetencionDgi = Isnull(@RetencionDgi,0),
        RetencionAlcaldia = Isnull(@RetencionAlcaldia,0),
        TotalOrden = Isnull(@TotalCordoba,0),
		RestantePago = @TotalCordoba - Pagado
    WHERE OrdenId = @IdOrden;

    -- Devolver los totales en un SELECT
    SELECT @Subtotal AS Subtotal,
           @IVA AS IVA,
           @DescuentoAdicional AS Descuento,
           @RetencionDgi AS RetencionDgi,
           @RetencionAlcaldia AS RetencionAlcaldia,
           @TotalCordoba AS TotalCordoba,
           Round(@TotalDolar,2) AS TotalDolar;
END

alter PROCEDURE sp_ObtenerOrdenesCreditoPorSucursal
    @idSucursal NVARCHAR(50),
    @filtro NVARCHAR(100) = NULL
AS
BEGIN
    -- Seleccionar solo las órdenes de crédito activas y que cumplen con las condiciones dadas
    SELECT 
        o.OrdenId,
        o.ClienteId,
        CASE 
            WHEN o.ClienteId = '0' THEN 'CLIENTE MOSTRADOR'
            ELSE c.PNombre + ' ' + ISNULL(c.SNombre, '') + ' ' + ISNULL(c.PApellido, '') + ' ' + ISNULL(c.SAPellido, '')
        END AS NombreCliente,
        o.FechaRealizacion,
        o.OrdenProceso,
        o.PagoProceso,
        o.TotalOrden,
        o.Pagado,
        o.FechaCredito,
        o.CantidadPagos,
        o.FrecuenciaPagos,
        o.MontoCredito,
        o.RestantePago
    FROM 
        Ordenes o
    LEFT JOIN 
        Clientes c ON o.ClienteId = c.IdCliente
    WHERE 
        o.SucursalId = @idSucursal
        AND o.BitEsCredito = 1 -- Solo órdenes de crédito
        AND o.OrdenProceso = 'Orden Abierta' -- Opcional: filtrar por estado "abierta"
        AND (
            @filtro IS NULL OR
            o.OrdenId LIKE '%' + @filtro + '%' OR
            c.PNombre + ' ' + ISNULL(c.SNombre, '') + ' ' + ISNULL(c.PApellido, '') + ' ' + ISNULL(c.SAPellido, '') LIKE '%' + @filtro + '%'
        )
		order by
		o.FechaCredito
END


--agregar Pagos
alter PROCEDURE sp_AgregarPago
    @OrdenId INT,
    @FormaPago NVARCHAR(255),
    @Pagado DECIMAL(18, 2),
	@MontoTarjeta DECIMAL(18, 2),
    @Cambio DECIMAL(18, 2) = NULL,
    @BancoId INT = NULL,
    @TarjetaId INT = NULL,
    @Total DECIMAL(18, 2) = NULL,
    @NoReferencia NVARCHAR(255) = NULL,
    @FechaPago DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar el pago en la tabla Pagos
        INSERT INTO Pagos (
            OrdenId,
            FormaPago,
            Pagado,
			MontoTarjeta,
            Cambio,
            BancoId,
            TarjetaId,
            Total,
            NoReferencia,
            FechaPago
        )
        VALUES (
            @OrdenId,
            @FormaPago,
            @Pagado,
			@MontoTarjeta,
            @Cambio,
            @BancoId,
            @TarjetaId,
            @Total,
            @NoReferencia,
            ISNULL(@FechaPago, GETDATE())
        );

        -- Actualizar el campo Pagado en la tabla Ordenes
        UPDATE Ordenes
        SET Pagado = ISNULL(Pagado, 0) + (@Total-@MontoTarjeta),
		RestantePago = TotalOrden -(ISNULL(pagado,0)+@Pagado)
        WHERE OrdenId = @OrdenId;

        -- Obtener los valores actuales de Pagado y TotalOrden
        DECLARE @TotalOrden DECIMAL(18, 2);
        DECLARE @NuevoPagado DECIMAL(18, 2);

        SELECT @TotalOrden = TotalOrden, @NuevoPagado = Pagado
        FROM Ordenes
        WHERE OrdenId = @OrdenId;

        -- Determinar y actualizar los estados de PagoProceso y OrdenProceso
        IF @NuevoPagado < @TotalOrden
        BEGIN
            UPDATE Ordenes
            SET PagoProceso = 'En Proceso de Pago'
            WHERE OrdenId = @OrdenId;
        END
        ELSE IF @NuevoPagado >= @TotalOrden
        BEGIN
            UPDATE Ordenes
            SET 
                PagoProceso = 'Totalmente Pagado',
                OrdenProceso = 'Orden Totalmente Pagada'
            WHERE OrdenId = @OrdenId;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        -- Manejo de errores
        THROW;
    END CATCH
END


alter PROCEDURE sp_EliminarPago
    @PagoOrdenId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Obtener el OrdenId del pago a eliminar
        DECLARE @OrdenId INT;
        DECLARE @Pagado DECIMAL(18, 2),
		@montoTarjeta decimal(18,2);

        SELECT @OrdenId = OrdenId, @Pagado = Total, @montoTarjeta = MontoTarjeta
        FROM Pagos
        WHERE PagoOrdenId = @PagoOrdenId;

        -- Eliminar el pago de la tabla Pagos
        DELETE FROM Pagos
        WHERE PagoOrdenId = @PagoOrdenId;

        -- Actualizar el campo Pagado en la tabla Ordenes
        UPDATE Ordenes
        SET Pagado = ISNULL(Pagado, 0) - ISNULL((@Pagado-@MontoTarjeta), 0),
		RestantePago = Isnull(RestantePago,0) + ISNULL((@Pagado-@MontoTarjeta), 0)
        WHERE OrdenId = @OrdenId;

        -- Verificar si quedan pagos asociados a la orden
        IF NOT EXISTS (
            SELECT 1
            FROM Pagos
            WHERE OrdenId = @OrdenId
        )
        BEGIN
            -- Si no hay pagos, actualizar los estados
            UPDATE Ordenes
            SET 
                PagoProceso = 'Sin Pagos',
                OrdenProceso = 'Orden Abierta',
                Pagado = 0
            WHERE OrdenId = @OrdenId;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        -- Manejo de errores
        THROW;
    END CATCH
END
