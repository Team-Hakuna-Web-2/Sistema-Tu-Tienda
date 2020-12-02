namespace Sistema_TuTienda_Lizarraga_Belizario_Loja.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModeloTuTienda")
        {
        }

        public virtual DbSet<CATEGORIA_PRODUCTO> CATEGORIA_PRODUCTO { get; set; }
        public virtual DbSet<DETALLE_CATEGORIA_PRODUCTO> DETALLE_CATEGORIA_PRODUCTO { get; set; }
        public virtual DbSet<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }
        public virtual DbSet<PEDIDO> PEDIDO { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIA_PRODUCTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA_PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA_PRODUCTO>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.CATEGORIA_PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DETALLE_CATEGORIA_PRODUCTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_CATEGORIA_PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_CATEGORIA_PRODUCTO>()
                .HasMany(e => e.CATEGORIA_PRODUCTO)
                .WithRequired(e => e.DETALLE_CATEGORIA_PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DETALLE_PEDIDO>()
                .Property(e => e.CANTIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_PEDIDO>()
                .Property(e => e.SUBTOTAL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PEDIDO>()
                .Property(e => e.NUMERO_PEDIDO)
                .IsUnicode(false);

            modelBuilder.Entity<PEDIDO>()
                .Property(e => e.TOTAL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PEDIDO>()
                .HasMany(e => e.DETALLE_PEDIDO)
                .WithRequired(e => e.PEDIDO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.MARCA)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRECIO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.DETALLE_PEDIDO)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PAIS)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CIUDAD)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);
        }
    }
}
