using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class NeoCobranzaContext : DbContext
    {
        public NeoCobranzaContext()
        {
        }

        public NeoCobranzaContext(DbContextOptions<NeoCobranzaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AjustesInventario> AjustesInventario { get; set; }
        public virtual DbSet<Almacenes> Almacenes { get; set; }
        public virtual DbSet<AuditoriaSistema> AuditoriaSistema { get; set; }
        public virtual DbSet<Bancos> Bancos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ComprasInventario> ComprasInventario { get; set; }
        public virtual DbSet<ConfigFacturacion> ConfigFacturacion { get; set; }
        public virtual DbSet<ConfigInventario> ConfigInventario { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Imagenes> Imagenes { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<LotesProducto> LotesProducto { get; set; }
        public virtual DbSet<Mermas> Mermas { get; set; }
        public virtual DbSet<MotivosCancelacion> MotivosCancelacion { get; set; }
        public virtual DbSet<OrdenDetalle> OrdenDetalle { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<RelAlmacenDetalle> RelAlmacenDetalle { get; set; }
        public virtual DbSet<RelAlmacenProducto> RelAlmacenProducto { get; set; }
        public virtual DbSet<RelBancoTipo> RelBancoTipo { get; set; }
        public virtual DbSet<RelProductoSucursales> RelProductoSucursales { get; set; }
        public virtual DbSet<RelProveedorProducto> RelProveedorProducto { get; set; }
        public virtual DbSet<RolPermisos> RolPermisos { get; set; }
        public virtual DbSet<RolUsuario> RolUsuario { get; set; }
        public virtual DbSet<Salas> Salas { get; set; }
        public virtual DbSet<ServiciosEstadares> ServiciosEstadares { get; set; }
        public virtual DbSet<Sucursales> Sucursales { get; set; }
        public virtual DbSet<TipoCambio> TipoCambio { get; set; }
        public virtual DbSet<TipoServicios> TipoServicios { get; set; }
        public virtual DbSet<TipoTarjeta> TipoTarjeta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.1.165;Database=NeoCobranza;UID=cobranzanew;PWD=12345678;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AjustesInventario>(entity =>
            {
                entity.HasKey(e => e.AjusteId);

                entity.Property(e => e.TipoProducto).HasMaxLength(50);
            });

            modelBuilder.Entity<Almacenes>(entity =>
            {
                entity.HasKey(e => e.AlmacenId);

                entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");

                entity.Property(e => e.Estatus).HasMaxLength(50);

                entity.Property(e => e.NombreAlmacen).HasMaxLength(100);

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            });

            modelBuilder.Entity<AuditoriaSistema>(entity =>
            {
                entity.HasKey(e => e.IdAuditoria);

                entity.Property(e => e.Campo).HasMaxLength(50);

                entity.Property(e => e.Fecha).HasMaxLength(50);

                entity.Property(e => e.Nivel)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sector).HasMaxLength(50);

                entity.Property(e => e.Tipo).HasMaxLength(50);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Bancos>(entity =>
            {
                entity.HasKey(e => e.BancoId);

                entity.Property(e => e.BancoId).HasColumnName("BancoID");

                entity.Property(e => e.Banco).HasMaxLength(100);

                entity.Property(e => e.Estado).HasMaxLength(50);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D5946642123EB7A3");

                entity.ToTable("Clientes", "RRHH");

                entity.Property(e => e.Cedula).HasMaxLength(255);

                entity.Property(e => e.Celular).HasMaxLength(50);

                entity.Property(e => e.Departamento).HasMaxLength(100);

                entity.Property(e => e.Direccion).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.EstadoCivil)
                    .HasColumnName("Estado Civil")
                    .HasMaxLength(255);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.FechaNac).HasColumnType("date");

                entity.Property(e => e.NoRuc).HasMaxLength(50);

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasMaxLength(400);

                entity.Property(e => e.Pais)
                    .HasColumnName("pais")
                    .HasMaxLength(100);

                entity.Property(e => e.Papellido)
                    .HasColumnName("PApellido")
                    .HasMaxLength(255);

                entity.Property(e => e.Pnombre)
                    .HasColumnName("PNombre")
                    .HasMaxLength(255);

                entity.Property(e => e.Profesion).HasMaxLength(255);

                entity.Property(e => e.Sapellido)
                    .HasColumnName("SAPellido")
                    .HasMaxLength(255);

                entity.Property(e => e.Sexo).HasMaxLength(255);

                entity.Property(e => e.Snombre)
                    .HasColumnName("SNombre")
                    .HasMaxLength(255);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<ComprasInventario>(entity =>
            {
                entity.HasKey(e => e.CompraId);

                entity.Property(e => e.CompraId).HasColumnName("CompraID");

                entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");

                entity.Property(e => e.CostoTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.SucursalId)
                    .HasColumnName("SucursalID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            });

            modelBuilder.Entity<ConfigFacturacion>(entity =>
            {
                entity.Property(e => e.ConfigFacturacionId).HasColumnName("ConfigFacturacionID");

                entity.Property(e => e.Serie).HasMaxLength(5);

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            });

            modelBuilder.Entity<ConfigInventario>(entity =>
            {
                entity.Property(e => e.ConfigInventarioId).HasColumnName("ConfigInventarioID");

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NombreComercial).HasMaxLength(200);

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Ruc)
                    .HasColumnName("RUC")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<Imagenes>(entity =>
            {
                entity.HasKey(e => e.IdImagen)
                    .HasName("PK__Imagenes__B42D8F2A06CD04F7");

                entity.ToTable("Imagenes", "RECURSOS");

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.Property(e => e.InventarioId).HasColumnName("InventarioID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            });

            modelBuilder.Entity<LotesProducto>(entity =>
            {
                entity.HasKey(e => e.LoteId);

                entity.Property(e => e.LoteId)
                    .HasColumnName("LoteID")
                    .HasMaxLength(200);

                entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");

                entity.Property(e => e.CompraId).HasColumnName("CompraID");

                entity.Property(e => e.CostoU).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Expira).HasMaxLength(50);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.FechaExpiracion).HasColumnType("date");

                entity.Property(e => e.Producto).HasMaxLength(200);

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Mermas>(entity =>
            {
                entity.HasKey(e => e.MermaId);

                entity.Property(e => e.MermaId).HasColumnName("MermaID");

                entity.Property(e => e.FechaRealizacion).HasColumnType("datetime");

                entity.Property(e => e.Identificador).HasMaxLength(500);

                entity.Property(e => e.LoteId)
                    .HasColumnName("LoteID")
                    .HasMaxLength(200);

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MotivosCancelacion>(entity =>
            {
                entity.HasKey(e => e.MotivoCancelacionId);

                entity.Property(e => e.MotivoCancelacionId).HasColumnName("MotivoCancelacionID");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Motivo).HasMaxLength(100);
            });

            modelBuilder.Entity<OrdenDetalle>(entity =>
            {
                entity.Property(e => e.OrdenDetalleId).HasColumnName("OrdenDetalleID");

                entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasKey(e => e.OrdenId);

                entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

                entity.Property(e => e.CambioDolar).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FechaRealizacion).HasColumnType("datetime");

                entity.Property(e => e.Iva)
                    .HasColumnName("IVA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrdenProceso).HasMaxLength(50);

                entity.Property(e => e.Pagado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PagoProceso).HasMaxLength(50);

                entity.Property(e => e.RestantePago).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RetencionAlcaldia).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RetencionDgi)
                    .HasColumnName("RetencionDGI")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalaMesa).HasMaxLength(50);

                entity.Property(e => e.Serie).HasMaxLength(50);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

                entity.Property(e => e.TotalOrden).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__E8B631AF72C60C4A");

                entity.ToTable("Proveedores", "OPERATIVOS");

                entity.Property(e => e.Correo).HasMaxLength(30);

                entity.Property(e => e.Direccion).HasMaxLength(200);

                entity.Property(e => e.NoRuc).HasMaxLength(30);

                entity.Property(e => e.NoTelefono)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<RelAlmacenDetalle>(entity =>
            {
                entity.HasKey(e => e.IdRelAlmacenDetalle);

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Modelo).HasMaxLength(50);

                entity.Property(e => e.Serie).HasMaxLength(50);

                entity.Property(e => e.Talla).HasMaxLength(50);
            });

            modelBuilder.Entity<RelAlmacenProducto>(entity =>
            {
                entity.Property(e => e.RelAlmacenProductoId).HasColumnName("RelAlmacenProductoID");
            });

            modelBuilder.Entity<RelBancoTipo>(entity =>
            {
                entity.HasKey(e => e.RelBancoTarjetaTipo);

                entity.Property(e => e.BancoId).HasColumnName("BancoID");

                entity.Property(e => e.TarjetaTipoId).HasColumnName("TarjetaTipoID");
            });

            modelBuilder.Entity<RelProductoSucursales>(entity =>
            {
                entity.Property(e => e.RelProductoSucursalesId).HasMaxLength(50);

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            });

            modelBuilder.Entity<RelProveedorProducto>(entity =>
            {
                entity.HasKey(e => e.RelProductoProveedor);

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            });

            modelBuilder.Entity<RolPermisos>(entity =>
            {
                entity.HasKey(e => e.PermisosId);

                entity.Property(e => e.Caja)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CajaHistorialRecibos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CajaRecibosOficiales)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CatalogoClientes)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CatalogoProveedores)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Catalogos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Contratos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContratosBuscarProforma)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContratosContratosRetirados)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContratosCrearContratos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContratosCrearProforma)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContratosFactura)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContratosGestionCuotas)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContratosInformacionGeneral)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContratosRetiroServicios)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Inventario)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.InventarioInventarioServicios)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.InventarioModificacionesProductos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Opciones)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OpcionesTipoCambio)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Personal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Seguridad)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SeguridadAuditoria)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SeguridadGestionPermisos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SeguridadGestionUsuario)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.VentarRetiros)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ventas)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.VentasBuscarProformas)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.VentasCrearProforma)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.VentasDirectas)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.VentasFacturas)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK__RolUsuar__F92302F13572E547");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Salas>(entity =>
            {
                entity.HasKey(e => e.SalaId);

                entity.Property(e => e.SalaId).HasColumnName("SalaID");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.NombreSala).HasMaxLength(150);

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            });

            modelBuilder.Entity<ServiciosEstadares>(entity =>
            {
                entity.HasKey(e => e.IdEstandar)
                    .HasName("PK__Servicio__BB570ABD4589517F");

                entity.ToTable("Servicios_Estadares", "OPERATIVOS");

                entity.Property(e => e.ClasificacionInventario).HasMaxLength(50);

                entity.Property(e => e.Codigo).HasMaxLength(100);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Expira).HasMaxLength(50);

                entity.Property(e => e.ManejoInventario).HasMaxLength(50);

                entity.Property(e => e.MontoVd).HasColumnName("MontoVD");

                entity.Property(e => e.NombreEstandar).HasMaxLength(100);

                entity.Property(e => e.TipoServicio).HasMaxLength(50);
            });

            modelBuilder.Entity<Sucursales>(entity =>
            {
                entity.HasKey(e => e.SucursalId);

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

                entity.Property(e => e.Correo).HasMaxLength(200);

                entity.Property(e => e.Direccion).HasMaxLength(500);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.NombreSucursal).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoCambio>(entity =>
            {
                entity.HasKey(e => e.IdTasaCambio)
                    .HasName("PK__TipoCamb__E5C307FB7B5B524B");

                entity.ToTable("TipoCambio", "OPERATIVOS");

                entity.Property(e => e.FechaCambio).HasColumnType("datetime");
            });

            modelBuilder.Entity<TipoServicios>(entity =>
            {
                entity.HasKey(e => e.TipoServicionId)
                    .HasName("PK_OPERATIVOS.TipoServicios");

                entity.Property(e => e.TipoServicionId).HasColumnName("TipoServicionID");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Estado).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoTarjeta>(entity =>
            {
                entity.Property(e => e.TipoTarjetaId)
                    .HasColumnName("TipoTarjetaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.NombreTipo).HasMaxLength(100);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios)
                    .HasName("PK__Usuario__AEF9042907F6335A");

                entity.Property(e => e.IdUsuarios).HasColumnName("Id_Usuarios");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Pass).HasMaxLength(100);

                entity.Property(e => e.PrimerApellido).HasMaxLength(100);

                entity.Property(e => e.PrimerNombre).HasMaxLength(100);

                entity.Property(e => e.Rol).HasMaxLength(50);

                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
