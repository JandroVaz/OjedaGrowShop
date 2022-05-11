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
                entity.HasNoKey();

                entity.ToTable("carrito");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");
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
