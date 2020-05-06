using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MGI_Maritima.Models
{
    public class InventarioContext: DbContext
    {
       

        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).IsRequired();
            });
        }
        public DbSet<Articulo> articulos { set; get; }
        public DbSet<Precio>  precios { set; get; }
        public DbSet<Almacen>  almacens { set; get; }
        public DbSet<Inventario>  inventarios { set; get; }
        public DbSet<LogInventario> logInventarios { get; set; }


    }
}
