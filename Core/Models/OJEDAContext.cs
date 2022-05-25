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

        public virtual DbSet<Carrito> Carritos { get; set; }
        public virtual DbSet<CarritoProducto> CarritoProductos { get; set; }
        public virtual DbSet<Mascotum> Mascota { get; set; }
        public virtual DbSet<MetodoPago> MetodoPagos { get; set; }
        public virtual DbSet<Orden> Ordens { get; set; }
        public virtual DbSet<OrdenDetalle> OrdenDetalles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductoCampo> ProductoCampos { get; set; }
        public virtual DbSet<ProductoMascotum> ProductoMascota { get; set; }
        public virtual DbSet<TipoProducto> TipoProductos { get; set; }
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

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("carrito");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user");
            });

            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.HasKey(e => new { e.IdProducto, e.IdCarrito })
                    .HasName("PK_public.carrito_producto");

                entity.ToTable("carrito_producto");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");

                entity.Property(e => e.CantidadProducto).HasColumnName("cantidad_producto");

                entity.HasOne(d => d.IdCarritoNavigation)
                    .WithMany(p => p.CarritoProductos)
                    .HasForeignKey(d => d.IdCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_carrito");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.CarritoProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carrito_producto");
            });

            modelBuilder.Entity<Mascotum>(entity =>
            {
                entity.ToTable("mascota");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.Raza).HasColumnName("raza");

                entity.Property(e => e.TipoMascota).HasColumnName("tipo_mascota");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.ToTable("metodo_pago");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.NombreMetodo).HasColumnName("nombre_metodo");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("orden");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IdMetodoPago).HasColumnName("id_metodo_pago");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdMetodoPagoNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.IdMetodoPago)
                    .HasConstraintName("metodo_pago");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("user");
            });

            modelBuilder.Entity<OrdenDetalle>(entity =>
            {
                entity.ToTable("orden_detalle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.OrdenDetalles)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orden");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.OrdenDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("producto_campo");

                entity.HasOne(d => d.IdProducto1)
                    .WithMany(p => p.OrdenDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("producto_mascota");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.TipoProducto).HasColumnName("tipo_producto");

                entity.HasOne(d => d.TipoProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.TipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipo_producto");
            });

            modelBuilder.Entity<ProductoCampo>(entity =>
            {
                entity.ToTable("producto_campo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.NombrePro).HasColumnName("nombre_pro");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<ProductoMascotum>(entity =>
            {
                entity.ToTable("producto_mascota");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.NombreProducto).HasColumnName("nombre_producto");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.ToTable("tipo_producto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("correo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
