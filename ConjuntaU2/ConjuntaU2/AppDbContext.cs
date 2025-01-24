using ConjuntaU2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConjuntaU2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }

    }
}
