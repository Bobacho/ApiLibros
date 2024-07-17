using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiLibros.Models
{

    public partial class ProyectosLibrosContext : DbContext
    {
        public ProyectosLibrosContext()
        {
        }

        public ProyectosLibrosContext(DbContextOptions<ProyectosLibrosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }

        public virtual DbSet<Carrito> Carritos { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<ComprobantePago> ComprobantePagos { get; set; }

        public virtual DbSet<Libro> Libros { get; set; }

        public virtual DbSet<LibroCaracteristica> LibroCaracteristicas { get; set; }

        public virtual DbSet<LibroCarrito> LibroCarritos { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=ConnectionStrings:LibrosConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__EBE80EA152006CFC");

                entity.ToTable("Administrador");

                entity.Property(e => e.IdAdministrador).HasColumnName("idAdministrador");
                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
                entity.Property(e => e.Privilegios)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("privilegios");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Administr__idUsu__267ABA7A");
            });
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.IdCarrito).HasName("PK__Carrito__7AF85448FE2AE02F");

                entity.ToTable("Carrito");

                entity.Property(e => e.IdCarrito).HasColumnName("idCarrito");
                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");
                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Carrito__idClien__2C3393D0");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE38343FBC");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");
                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("direccion");
                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
                entity.Property(e => e.MetodoPago)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("metodoPago");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Cliente__idUsuar__29572725");
            });

            modelBuilder.Entity<ComprobantePago>(entity =>
            {
                entity.HasKey(e => e.IdComprobante).HasName("PK__Comproba__BF4D8CF345C0E890");

                entity.ToTable("ComprobantePago");

                entity.Property(e => e.IdComprobante).HasColumnName("idComprobante");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");
                entity.Property(e => e.FechaPago).HasColumnName("fechaPago");
                entity.Property(e => e.IdCarrito).HasColumnName("idCarrito");
                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("monto");
                entity.Property(e => e.Ruc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("RUC");

                entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.ComprobantePagos)
                    .HasForeignKey(d => d.IdCarrito)
                    .HasConstraintName("FK__Comproban__idCar__2F10007B");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro).HasName("PK__Libro__5BC0F0263160F54C");

                entity.ToTable("Libro");

                entity.Property(e => e.IdLibro).HasColumnName("idLibro");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.IdLibroCaracteristicas).HasColumnName("idLibroCaracteristicas");
                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.HasOne(d => d.IdLibroCaracteristicasNavigation).WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdLibroCaracteristicas)
                    .HasConstraintName("FK__Libro__idLibroCa__33D4B598");
            });

            modelBuilder.Entity<LibroCaracteristica>(entity =>
            {
                entity.HasKey(e => e.IdLibroCaracteristicas).HasName("PK__LibroCar__6531E52311FBF385");

                entity.Property(e => e.IdLibroCaracteristicas).HasColumnName("idLibroCaracteristicas");
                entity.Property(e => e.Autor)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("autor");
                entity.Property(e => e.Categoria)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("categoria");
                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("descuento");
                entity.Property(e => e.ImagenUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("imagenUrl");
                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");
                entity.Property(e => e.Titulo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<LibroCarrito>(entity =>
            {
                entity.HasKey(e => e.IdLibroCarrito).HasName("PK__LibroCar__CB7ADF010A8777E3");

                entity.ToTable("LibroCarrito");

                entity.Property(e => e.IdLibroCarrito).HasColumnName("idLibroCarrito");
                entity.Property(e => e.IdCarrito).HasColumnName("idCarrito");
                entity.Property(e => e.IdLibro).HasColumnName("idLibro");

                entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.LibroCarritos)
                    .HasForeignKey(d => d.IdCarrito)
                    .HasConstraintName("FK__LibroCarr__idCar__36B12243");

                entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.LibroCarritos)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK__LibroCarr__idLib__37A5467C");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6AF7144F0");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
                entity.Property(e => e.Contrasena)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");
                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
