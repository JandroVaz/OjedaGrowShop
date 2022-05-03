using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class OJEDAContext : DbContext
    {
        public OJEDAContext()
        {
        }

        public OJEDAContext(DbContextOptions<OJEDAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CMetodoPago> CMetodoPagos { get; set; }
        public virtual DbSet<Carrito> Carritos { get; set; }
        public virtual DbSet<CarruselImg> CarruselImgs { get; set; }
        public virtual DbSet<Mascota> Mascotas { get; set; }
        public virtual DbSet<Orden> Ordens { get; set; }
        public virtual DbSet<OrdenDetalle> OrdenDetalles { get; set; }
        public virtual DbSet<ProductosCampo> ProductosCampos { get; set; }
        public virtual DbSet<ProductosMascotum> ProductosMascota { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=netindio.synology.me;Port=5400;Username=admin;Password=3444;Database=ojeda_db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<CMetodoPago>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_c_metodo_pago");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Nombremetodo)
                    .HasMaxLength(1)
                    .HasColumnName("nombremetodo")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_carrito");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(1)
                    .HasColumnName("cantidad")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Idiusuario)
                    .HasMaxLength(1)
                    .HasColumnName("idiusuario")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Idproducto)
                    .HasMaxLength(1)
                    .HasColumnName("idproducto")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<CarruselImg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_carrusel_img");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Nombreimg)
                    .HasMaxLength(1)
                    .HasColumnName("nombreimg")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Ruta)
                    .HasMaxLength(1)
                    .HasColumnName("ruta")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_mascotas");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(1)
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Raza)
                    .HasMaxLength(1)
                    .HasColumnName("raza")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Tipomascota)
                    .HasMaxLength(1)
                    .HasColumnName("tipomascota")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_orden");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Idmetodopago)
                    .HasMaxLength(1)
                    .HasColumnName("idmetodopago")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Idusuario)
                    .HasMaxLength(1)
                    .HasColumnName("idusuario")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Total)
                    .HasMaxLength(1)
                    .HasColumnName("total")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<OrdenDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_orden_detalle");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(1)
                    .HasColumnName("cantidad")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Idorden)
                    .HasMaxLength(1)
                    .HasColumnName("idorden")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Idproducto)
                    .HasMaxLength(1)
                    .HasColumnName("idproducto")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Precio)
                    .HasMaxLength(1)
                    .HasColumnName("precio")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ProductosCampo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_productos_campo");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(1)
                    .HasColumnName("categoria")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1)
                    .HasColumnName("descripcion")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1)
                    .HasColumnName("imagen")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Nombrepro)
                    .HasMaxLength(1)
                    .HasColumnName("nombrepro")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Precio)
                    .HasMaxLength(1)
                    .HasColumnName("precio")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ProductosMascotum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_productos_mascota");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(1)
                    .HasColumnName("categoria")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1)
                    .HasColumnName("descripcion")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1)
                    .HasColumnName("imagen")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Nombrepro)
                    .HasMaxLength(1)
                    .HasColumnName("nombrepro")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Precio)
                    .HasMaxLength(1)
                    .HasColumnName("precio")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_user");

                entity.Property(e => e.Correo)
                    .HasMaxLength(1)
                    .HasColumnName("correo")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .HasColumnName("id")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Name)
                    .HasMaxLength(1)
                    .HasColumnName("name")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Password)
                    .HasMaxLength(1)
                    .HasColumnName("password")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Rol)
                    .HasMaxLength(1)
                    .HasColumnName("rol")
                    .HasDefaultValueSql("NULL::character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
