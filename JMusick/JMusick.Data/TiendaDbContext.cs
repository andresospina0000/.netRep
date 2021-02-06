using System;
using JMusick.Data.Configuracion;
using JMusick.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JMusick.Data
{
    public class TiendaDbContext : DbContext
    {
        public TiendaDbContext()
        {
        }

        public TiendaDbContext(DbContextOptions<TiendaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleOrden> DetallesOrdens { get; set; }
        public virtual DbSet<Orden> Ordenes { get; set; }
        public virtual DbSet<Perfil> Perfiles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new DetalleOrdenConfiguracion());

            modelBuilder.ApplyConfiguration(new OrdenConfiguracion());

            modelBuilder.ApplyConfiguration(new PerfilConfiguracion());

            modelBuilder.ApplyConfiguration(new ProductoConfiguracion());

            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());


        }

      
    }
}
