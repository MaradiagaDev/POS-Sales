--PROCEDIMIENTOS ALMACENADOS
cREATE PROCEDURE SP_LoginUser
    @UserName NVARCHAR(50),
    @Password NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    -- Generar el hash de la contrase�a ingresada
    DECLARE @ClaveHash VARBINARY(MAX);
	Declare @userId nvarchar(50)
    SET @ClaveHash = HASHBYTES('SHA2_256', @Password);

    -- Verificar si el usuario y contrase�a son v�lidos
    IF NOT EXISTS (
        SELECT 1 
        FROM Usuario 
        WHERE Usuario = @UserName AND ClaveUsuario = @ClaveHash
    )
    BEGIN
        SELECT 'Usuario o contrase�a incorrectos.' AS Mensaje;
        RETURN;
    END

    -- Verificar si el usuario est� habilitado (Estado = 'Activo')
    DECLARE @Estado NVARCHAR(50);
    SELECT @Estado = Estado,
	@userId = IdUsuario
    FROM Usuario
    WHERE Usuario = @UserName;

    IF @Estado <> 'Activo'
    BEGIN
        SELECT 'El usuario est� inactivo.' AS Mensaje;
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

    -- Si todo es correcto, devolver mensaje de �xito
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

    -- Generar un hash de la contrase�a con un algoritmo SHA2_256
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

    -- Si el IdCliente es NULL, significa que es una creaci�n
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


CREATE PROCEDURE [dbo].[sp_ObtenerClientesFiltrados]
    @FiltroPor INT, -- 0 = ID, 1 = Nombre completo, 2 = C�dula
    @FiltroValor NVARCHAR(255), -- Valor a filtrar
    @IdSucursal NVARCHAR(50), -- ID de la sucursal para filtrar
    @PageNumber INT = 1, -- P�gina actual
    @PageSize INT = 10 -- N�mero de registros por p�gina
AS
BEGIN
    SET NOCOUNT ON;

    -- Variables para el c�lculo de paginaci�n
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
    DECLARE @TotalRows INT;

    -- Filtrado de clientes con ID de sucursal
    IF @FiltroPor = 0
    BEGIN
        SELECT @TotalRows = COUNT(*) 
        FROM [dbo].[Clientes]
        WHERE CAST(IdCliente AS NVARCHAR) = @FiltroValor 
        AND IdSucursal = @IdSucursal;

        SELECT * 
        FROM [dbo].[Clientes]
        WHERE CAST(IdCliente AS NVARCHAR) = @FiltroValor 
        AND IdSucursal = @IdSucursal
        ORDER BY IdCliente DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END
    ELSE IF @FiltroPor = 1
    BEGIN
        SELECT @TotalRows = COUNT(*) 
        FROM [dbo].[Clientes]
        WHERE (PNombre + ' ' + SNombre + ' ' + PApellido + ' ' + SAPellido) LIKE '%' + @FiltroValor + '%'
        AND IdSucursal = @IdSucursal;

        SELECT * 
        FROM [dbo].[Clientes]
        WHERE (PNombre + ' ' + SNombre + ' ' + PApellido + ' ' + SAPellido) LIKE '%' + @FiltroValor + '%'
        AND IdSucursal = @IdSucursal
        ORDER BY IdCliente DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END
    ELSE IF @FiltroPor = 2
    BEGIN
        SELECT @TotalRows = COUNT(*) 
        FROM [dbo].[Clientes]
        WHERE Cedula LIKE '%' + @FiltroValor + '%'
        AND IdSucursal = @IdSucursal;

        SELECT * 
        FROM [dbo].[Clientes]
        WHERE Cedula LIKE '%' + @FiltroValor + '%'
        AND IdSucursal = @IdSucursal
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