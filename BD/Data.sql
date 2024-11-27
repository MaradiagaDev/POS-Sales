--CORRER DATA
exec SP_SaveOrUpdateUser '','rmaradiaga','Facil123$','Activo',1

INSERT INTO [dbo].[Sucursal] ([IdSucursal], [NombreSucursal], [Direccion], [Telefono], [Estado], [FechaCreo], [FechaActualizo])
VALUES 
('SUC001', 'Sucursal Central', 'Avenida Principal #123, Ciudad Principal', '555-1234', 'Activo', GETDATE(), NULL),
('SUC002', 'Sucursal Norte', 'Calle Norte #45, Ciudad Norte', '555-5678', 'Activo', GETDATE(), NULL),
('SUC003', 'Sucursal Este', 'Boulevard Este #98, Ciudad Este', '555-9101', 'Inactivo', GETDATE(), NULL),
('SUC004', 'Sucursal Oeste', 'Plaza Oeste, Local 12, Ciudad Oeste', '555-1122', 'Activo', GETDATE(), NULL),
('SUC005', 'Sucursal Sur', 'Carretera Sur Km 5, Ciudad Sur', '555-3344', 'Activo', GETDATE(), NULL);


INSERT INTO [dbo].[UsuarioSucursal] (IdUsuario, IdSucursal)
VALUES 
('1438ECF3-D8A0-491B-94D4-EB859FCE6C0C', 'SUC001'), -- Usuario U001 asignado a la Sucursal Centro
('1438ECF3-D8A0-491B-94D4-EB859FCE6C0C', 'SUC002') -- Usuario U002 asignado a la Sucursal Norte

insert into Almacenes values ('A001','Almacen Mostrador',1,'S001','Sucursal Central','Activo')