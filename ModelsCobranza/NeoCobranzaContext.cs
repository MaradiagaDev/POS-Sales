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

        public virtual DbSet<AuditoriaSistema> AuditoriaSistema { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<RolPermisos> RolPermisos { get; set; }
        public virtual DbSet<RolUsuario> RolUsuario { get; set; }
        public virtual DbSet<TipoCambio> TipoCambio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.1.165;Database=NeoCobranza;UID=sa;PWD=123456;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<TipoCambio>(entity =>
            {
                entity.HasKey(e => e.IdTasaCambio)
                    .HasName("PK__TipoCamb__E5C307FB7B5B524B");

                entity.ToTable("TipoCambio", "OPERATIVOS");

                entity.Property(e => e.FechaCambio).HasColumnType("datetime");
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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
