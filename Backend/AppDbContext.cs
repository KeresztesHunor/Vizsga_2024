using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class AppDbContext(IConfiguration config) : DbContext()
    {
        IConfiguration config { get; } = config;

        public DbSet<Tema> Tema { get; set; }
        public DbSet<Szavak> Szavak { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("DbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tema>()
                .HasMany(tema => tema._Szavak)
                .WithOne(szavak => szavak._Tema)
                .HasForeignKey(szavak => szavak.TemaId)
                .OnDelete(DeleteBehavior.Restrict)
            ;
        }
    }
}
