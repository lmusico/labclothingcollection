using labclothingcollection.Models;
using Microsoft.EntityFrameworkCore;

namespace labclothingcollection.Context
{
    public class labclothingcollectionContext : DbContext
    {
        public labclothingcollectionContext(DbContextOptions options) : base(options)
        {
        }

        public labclothingcollectionContext() { }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                MockUsuarios.usuario
                );
        }
        public virtual DbSet<Colecao> Colecoes { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }

    }
}
